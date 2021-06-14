using System;
using UnityEngine;

namespace UnityEditor
{
    internal class RingEngineShaderGUI : ShaderGUI
    {
        private enum CullMode
        {
            Off,
            Front,
            Back
        }

        private static class Styles
        {
            public static GUIContent albedoText = new GUIContent("Albedo", "Albedo (RGB) and Transparency (A)");
            public static GUIContent specMapText = new GUIContent("Specular", "Specular (RGB) and Smoothness (A)");
            public static GUIContent smoothnessText = new GUIContent("Gloss Map", "");
            public static GUIContent normalMapText = new GUIContent("Normal Map", "Normal Map");
            public static GUIContent normalMap2Text = new GUIContent("Normal Map 2", "Normal Map 2");
            public static GUIContent occlusionText = new GUIContent("Occlusion", "Occlusion (R)");
            public static GUIContent emissionText = new GUIContent("Emission", "Emission (RGB)");
            public static GUIContent falloffText = new GUIContent("Falloff", "Falloff (RGB)");
            public static GUIContent reflectionText = new GUIContent("Reflection", "Reflection (RGB)");

            public static string whiteSpaceString = " ";
            public static string materialSettingsString = "Material Settings";
            public static string cullModeString = "Cull Mode";
            public static string primaryMapsString = "Main Maps";
            public static string uvSettingsString = "UV Settings";
            public static string uvAnimationString = "UV Animation Settings";
            public static readonly string[] blendNames = Enum.GetNames(typeof(CullMode));
            public static readonly string[] renderNames = Enum.GetNames(typeof(RenderMode));
        }

        MaterialProperty cullMode = null;
        MaterialProperty selfIllum = null;
        MaterialProperty pulseTime = null;
        MaterialProperty uSpeed = null;
        MaterialProperty vSpeed = null;
        MaterialProperty uvSpeed = null;
        MaterialProperty vertexBlend = null;
        MaterialProperty vertexColors = null;
        MaterialProperty vertexColorR = null;
        MaterialProperty vertexColorG = null;
        MaterialProperty vertexColorB = null;
        MaterialProperty color = null;
        MaterialProperty mainTex = null;
        MaterialProperty mainTexG = null;
        MaterialProperty mainTexB = null;
        MaterialProperty cutoff = null;
        MaterialProperty specColor = null;
        MaterialProperty specMap = null;
        MaterialProperty smoothness = null;
        MaterialProperty glossMap = null;
        MaterialProperty glossMapG = null;
        MaterialProperty glossMapB = null;
        MaterialProperty bumpMap = null;
        MaterialProperty bumpMap2 = null;
        MaterialProperty occlusionStrength = null;
        MaterialProperty occlusionMap = null;
        MaterialProperty emissionColor = null;
        MaterialProperty emissionMap = null;
        MaterialProperty falloffColor = null;
        MaterialProperty falloffMap = null;
        MaterialProperty reflectionStrength = null;
        MaterialProperty reflection = null;
        MaterialProperty refraction = null;
        MaterialProperty distortion = null;

        MaterialEditor m_MaterialEditor;

        bool blend;
        bool paint;
        bool paintR;
        bool paintG;
        bool paintB;

        int curentSelection;

        float t;

        public void FindProperties(MaterialProperty[] props)
        {
            cullMode = FindProperty("_Cull", props);
            selfIllum = FindProperty("_SelfIllum", props);
            pulseTime = FindProperty("_PulseTime", props);
            uSpeed = FindProperty("_USpeed", props, false);
            vSpeed = FindProperty("_VSpeed", props, false);
            uvSpeed = FindProperty("_UVSpeed", props, false);
            vertexBlend = FindProperty("_VertexBlend", props);
            vertexColors = FindProperty("_VertexColors", props);
            vertexColorR = FindProperty("_VertexColorR", props);
            vertexColorG = FindProperty("_VertexColorG", props);
            vertexColorB = FindProperty("_VertexColorB", props);
            color = FindProperty("_Color", props);
            mainTex = FindProperty("_MainTex", props);
            mainTexG = FindProperty("_MainTexG", props);
            mainTexB = FindProperty("_MainTexB", props);
            cutoff = FindProperty("_Cutoff", props, false);
            specColor = FindProperty("_SpecColor", props);
            specMap = FindProperty("_SpecGlossMap", props);
            smoothness = FindProperty("_Glossiness", props);
            glossMap = FindProperty("_GlossMap", props);
            glossMapG = FindProperty("_GlossMapG", props);
            glossMapB = FindProperty("_GlossMapB", props);
            bumpMap = FindProperty("_BumpMap", props);
            bumpMap2 = FindProperty("_BumpMap2", props, false);
            occlusionStrength = FindProperty("_OcclusionStrength", props, false);
            occlusionMap = FindProperty("_OcclusionMap", props, false);
            emissionColor = FindProperty("_EmissionColor", props);
            emissionMap = FindProperty("_EmissionMap", props);
            falloffColor = FindProperty("_FalloffColor", props, false);
            falloffMap = FindProperty("_FalloffMap", props, false);
            reflectionStrength = FindProperty("_ReflectionStrength", props, false);
            reflection = FindProperty("_Reflection", props, false);
            refraction = FindProperty("_Refraction", props, false);
            distortion = FindProperty("_Distortion", props, false);
        }

        void OnEnable()
        {

        }

        [Obsolete]
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
        {
            FindProperties(props);

            m_MaterialEditor = materialEditor;

            Material material = materialEditor.target as Material;

            ShaderPropertiesGUI(material);

            if (bumpMap.textureValue == null)
            {
                material.DisableKeyword("NORMALMAP");
            }
            else
            {
                material.EnableKeyword("NORMALMAP");
            }
        }

        [Obsolete]
        public void ShaderPropertiesGUI(Material material)
        {
            // Use default labelWidth
            EditorGUIUtility.labelWidth = 0f;

            // Detect any changes to the material
            EditorGUI.BeginChangeCheck();
            {
                blend = vertexBlend.floatValue == 0 ? false : true;

                paint = vertexColors.floatValue == 0 ? false : true;

                paintR = vertexColorR.floatValue == 0 ? false : true;

                paintG = vertexColorG.floatValue == 0 ? false : true;

                paintB = vertexColorB.floatValue == 0 ? false : true;

                GUILayout.Label(Styles.materialSettingsString, EditorStyles.boldLabel);

                CullModePopup();

                m_MaterialEditor.RangeProperty(selfIllum, "Self Illumination");

                m_MaterialEditor.RangeProperty(pulseTime, "Light Frequency");

                if (refraction != null)
                {
                    m_MaterialEditor.RangeProperty(refraction, "Refraction");
                }

                if (distortion != null)
                {
                    m_MaterialEditor.RangeProperty(distortion, "Distortion");
                }

                GUILayout.Label("Vertex Colors Settings", EditorStyles.boldLabel);

                blend = EditorGUILayout.Toggle("Vertex Blend", blend);

                if (!blend)
                {
                    paint = EditorGUILayout.Toggle("Paint RGB Channels", paint);
                }
                else
                {
                    paintR = EditorGUILayout.Toggle("Paint Red Channel", paintR);

                    paintG = EditorGUILayout.Toggle("Paint Green Channel", paintG);

                    paintB = EditorGUILayout.Toggle("Paint Blue Channel", paintB);
                }

                GUILayout.Label(Styles.primaryMapsString, EditorStyles.boldLabel);

                curentSelection = GUILayout.SelectionGrid(curentSelection, new string[3] { "R", "G", "B" }, 3);

                //EditorGUILayout.Separator();
                EditorGUILayout.Space();

                switch (curentSelection)
                {
                    case 0:
                        m_MaterialEditor.TexturePropertySingleLine(Styles.albedoText, mainTex, color);

                        if (cutoff != null)
                        {
                            m_MaterialEditor.RangeProperty(cutoff, "Alpha cutoff");
                        }

                        m_MaterialEditor.TexturePropertySingleLine(Styles.specMapText, specMap, specColor);

                        m_MaterialEditor.TexturePropertySingleLine(Styles.smoothnessText, glossMap, smoothness);

                        m_MaterialEditor.TexturePropertySingleLine(Styles.normalMapText, bumpMap);

                        if (bumpMap2 != null)
                        {
                            m_MaterialEditor.TexturePropertySingleLine(Styles.normalMap2Text, bumpMap2);
                        }


                        if (occlusionMap != null)
                        {
                            m_MaterialEditor.TexturePropertySingleLine(Styles.occlusionText, occlusionMap, occlusionMap.textureValue != null ? occlusionStrength : null);
                        }
                        m_MaterialEditor.TexturePropertyWithHDRColor(Styles.emissionText, emissionMap, emissionColor, new ColorPickerHDRConfig(0f, 99f, 1 / 99f, 3f), false);

                        if (emissionMap.textureValue != null && emissionColor.colorValue == Color.black)
                        {
                            emissionColor.colorValue = Color.white;
                        }

                        if (falloffMap != null)
                        {
                            m_MaterialEditor.TexturePropertySingleLine(Styles.falloffText, falloffMap, falloffColor);

                            if (falloffMap.textureValue != null && falloffColor.colorValue == new Color(0, 0, 0, 0.2f))
                            {
                                falloffColor.colorValue = new Color(1, 1, 1, 0.2f);
                            }
                        }

                        if (reflection != null)
                        {
                            m_MaterialEditor.TexturePropertySingleLine(Styles.reflectionText, reflection, reflection.textureValue != null ? reflectionStrength : null);

                            if (reflection.textureValue == null)
                            {
                                reflectionStrength.floatValue = 0;
                            }
                        }


                        break;
                    case 1:
                        m_MaterialEditor.TexturePropertySingleLine(Styles.albedoText, mainTexG);

                        m_MaterialEditor.TexturePropertySingleLine(Styles.smoothnessText, glossMapG);

                        //m_MaterialEditor.TexturePropertySingleLine(Styles.normalMapText, bumpMapG);
                        break;
                    case 2:
                        m_MaterialEditor.TexturePropertySingleLine(Styles.albedoText, mainTexB);

                        m_MaterialEditor.TexturePropertySingleLine(Styles.smoothnessText, glossMapB);

                        //m_MaterialEditor.TexturePropertySingleLine(Styles.normalMapText, bumpMapB);
                        break;
                }

                GUILayout.Label(Styles.uvSettingsString, EditorStyles.boldLabel);

                m_MaterialEditor.TextureScaleOffsetProperty(mainTex);

                GUILayout.Label(Styles.uvAnimationString, EditorStyles.boldLabel);

                if (uSpeed != null)
                {
                    m_MaterialEditor.FloatProperty(uSpeed, "U Speed");
                }

                if (vSpeed != null)
                {
                    m_MaterialEditor.FloatProperty(vSpeed, "V Speed");
                }

                if (uvSpeed != null)
                {
                    m_MaterialEditor.VectorProperty(uvSpeed, "UV Speed");
                }

                vertexBlend.floatValue = blend ? 1 : 0;

                vertexColors.floatValue = paint ? 1 : 0;

                vertexColorR.floatValue = paintR ? 1 : 0;

                vertexColorG.floatValue = paintG ? 1 : 0;

                vertexColorB.floatValue = paintB ? 1 : 0;
            }
        }

        void DrawNodeWindow()
        {
            GUI.DragWindow();
        }

        void CullModePopup()
        {
            EditorGUI.showMixedValue = cullMode.hasMixedValue;
            var mode = (CullMode)cullMode.floatValue;

            EditorGUI.BeginChangeCheck();
            mode = (CullMode)EditorGUILayout.Popup(Styles.cullModeString, (int)mode, Styles.blendNames);
            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo("Cull Mode");
                cullMode.floatValue = (float)mode;
            }

            EditorGUI.showMixedValue = false;
        }
    }
}
