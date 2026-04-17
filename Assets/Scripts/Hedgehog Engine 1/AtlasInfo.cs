public class AtlasInfo
{
    public struct AtlasInfoHeader
    {
        public char padding;
        public byte texturesAmount; // How many DDS files it needs to load
        public char addPadding;
    }

    // Read this for textures_amount times after reading sub_texture_info
    public struct TextureHeader
    {
        public byte textureNameSize; // How many chars the texture name has
        public char[] textureName; // DDS texture name (without the .dds extension), non-null terminated
        public byte subTextureSize; // How many subtextures are in this file
        public char padding;
    }

    // Read the next structure structure for sub_texture_size times
    public struct SubTextureInfo
    {
        public byte subtextureNameSize; // How many chars the subtexture name has
        public char[] subtextureName; // non-null terminated string, internal name of the texture this gia data belongs to in the terrain(or perhaps the object)

        // Real width of the texture in pixels = total_width/(2^(width - 1))
        // Real height of the texture in pixels = total_height/(2^(height - 1))
        public byte width;
        public byte height;

        // Map [0..255] to [0.0..1.0], to get the absolute coordinate of the sub-texture(top-left corner)
        // Since textures only works in powers of two, this should give you perfect precision
        public byte x;
        public byte y;
    }
}
