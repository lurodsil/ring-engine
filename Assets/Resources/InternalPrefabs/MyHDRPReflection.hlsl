#ifndef CUSTOM_HDRP_REFLECTION_INCLUDED
#define CUSTOM_HDRP_REFLECTION_INCLUDED

// NÃO inclua Lighting.hlsl ou HDReflection.hlsl

void SampleHDRPReflection_float(
    float3 WorldNormal,
    float3 ViewDirection,
    float Smoothness,
    out float3 ReflectionColor)
{
    float3 reflectVector = reflect(-ViewDirection, normalize(WorldNormal));

    // HDRP já fornece essa função internamente
    ReflectionColor = SAMPLE_TEXTURECUBE_LOD(_SkyTexture, sampler_SkyTexture, reflectVector, (1.0 - Smoothness) * 6).rgb;
}

#endif