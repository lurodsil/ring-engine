using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class MaterialTextureReader
{
    private const int BASE_OFFSET = 0x18;

    public static List<string> GetTextureNames(string path)
    {
        List<string> textureNames = new();

        using var fs = File.OpenRead(path);
        using var reader = new BinaryReader(fs);

        long fileLength = reader.BaseStream.Length;

        uint ReadUInt32BE()
        {
            var b = reader.ReadBytes(4);
            Array.Reverse(b);
            return BitConverter.ToUInt32(b, 0);
        }

        string ReadStringAt(uint offset)
        {
            long pos = offset + BASE_OFFSET;

            if (pos <= 0 || pos >= fileLength)
                return null;

            long original = reader.BaseStream.Position;
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);

            List<byte> bytes = new();
            byte c;

            while (reader.BaseStream.Position < fileLength &&
                   (c = reader.ReadByte()) != 0)
            {
                bytes.Add(c);
            }

            reader.BaseStream.Seek(original, SeekOrigin.Begin);

            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        // ===== HEADER =====

        reader.BaseStream.Seek(0x18, SeekOrigin.Begin); // root node

        reader.ReadUInt32(); // type1
        reader.ReadUInt32(); // type2

        uint texsetOffset = ReadUInt32BE();
        uint textureOffset = ReadUInt32BE();

        reader.ReadUInt32(); // unknown

        byte totalMaterials = reader.ReadByte();
        reader.ReadBytes(2);
        byte totalTextures = reader.ReadByte();

        reader.ReadUInt32(); // material table
        reader.ReadUInt32();
        reader.ReadUInt32();

        // ===== TEXTURE TABLE =====

        reader.BaseStream.Seek(textureOffset + BASE_OFFSET, SeekOrigin.Begin);

        for (int i = 0; i < totalTextures; i++)
        {
            uint texOffset = ReadUInt32BE();
            long texPos = texOffset + BASE_OFFSET;

            if (texPos <= 0 || texPos >= fileLength)
                continue;

            reader.BaseStream.Seek(texPos, SeekOrigin.Begin);

            uint nameOffset = ReadUInt32BE();
            reader.ReadUInt32(); // unknown
            reader.ReadUInt32(); // type offset

            string texName = ReadStringAt(nameOffset);

            if (!string.IsNullOrEmpty(texName))
                textureNames.Add(texName);
        }

        return textureNames;
    }
}
