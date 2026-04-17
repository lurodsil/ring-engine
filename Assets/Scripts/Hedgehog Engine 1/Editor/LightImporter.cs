using UnityEngine;
using UnityEditor;
using System.IO;
using System.Net;
using System;

public class LightFolderImporter
{
    [MenuItem("Tools/Hedgehog Engine 1/Import .light Files")]
    public static void ImportLightFolder()
    {
        string folderPath = EditorUtility.OpenFolderPanel("Select Folder With .light Files", "", "");

        if (string.IsNullOrEmpty(folderPath))
            return;

        string[] files = Directory.GetFiles(folderPath, "*.light", SearchOption.TopDirectoryOnly);

        if (files.Length == 0)
        {
            Debug.LogWarning("No .light files found in folder.");
            return;
        }

        GameObject parent = new GameObject("Imported_Lights");

        int success = 0;

        foreach (string file in files)
        {
            try
            {
                GameObject lightGO = ImportSingleLight(file);
                if (lightGO != null)
                {
                    lightGO.transform.parent = parent.transform;
                    success++;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to import {file} : {e.Message}");
            }
        }

        Debug.Log($"Imported {success} lights successfully.");
    }

    static GameObject ImportSingleLight(string path)
    {
        using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
        {
            // Header
            uint fileSize = ReadUInt32BE(br);
            uint rootNodeType = ReadUInt32BE(br);
            uint offsetFinalTable = ReadUInt32BE(br);
            uint rootNodeOffset = ReadUInt32BE(br);
            uint offsetFinalTableAbs = ReadUInt32BE(br);
            uint padding = ReadUInt32BE(br);

            uint lightType = ReadUInt32BE(br);

            string fileName = Path.GetFileNameWithoutExtension(path);
            GameObject lightGO = new GameObject(fileName);
            Light unityLight = lightGO.AddComponent<Light>();

            if (lightType == 0)
            {
                // Directional
                Vector3 direction = ReadVector3BE(br);
                Vector3 rgb = ReadVector3BE(br);

                unityLight.type = LightType.Directional;
                unityLight.color = new Color(rgb.x, rgb.y, rgb.z, 1f);
                unityLight.intensity = 1f;

                lightGO.transform.rotation = Quaternion.LookRotation(direction.normalized);
            }
            else if (lightType == 1)
            {
                // Omni
                Vector3 position = ReadVector3BE(br);
                Vector3 rgb = ReadVector3BE(br);

                uint unknown1 = ReadUInt32BE(br);
                uint unknown2 = ReadUInt32BE(br);
                uint unknown3 = ReadUInt32BE(br);

                float range = ReadFloatBE(br);
                float falloff = ReadFloatBE(br);

                unityLight.type = LightType.Point;
                unityLight.color = new Color(rgb.x, rgb.y, rgb.z, 1f);
                unityLight.intensity = 1f;
                unityLight.range = range * 10;

                lightGO.transform.position = position;
            }
            else
            {
                Debug.LogWarning($"Unknown light type in file {fileName}");
                UnityEngine.Object.DestroyImmediate(lightGO);
                return null;
            }

            return lightGO;
        }
    }

    static uint ReadUInt32BE(BinaryReader br)
    {
        return (uint)IPAddress.NetworkToHostOrder(br.ReadInt32());
    }

    static float ReadFloatBE(BinaryReader br)
    {
        byte[] bytes = br.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
            System.Array.Reverse(bytes);

        return System.BitConverter.ToSingle(bytes, 0);
    }

    static Vector3 ReadVector3BE(BinaryReader br)
    {
        return new Vector3(
            ReadFloatBE(br),
            ReadFloatBE(br),
            ReadFloatBE(br)
        );
    }
}
