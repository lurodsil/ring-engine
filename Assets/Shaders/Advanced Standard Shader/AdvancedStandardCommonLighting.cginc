#include "AdvancedStandardInput.cginc"
#include "PhotoshopBlendModes.cginc"
#include "ShaderFunctions.cginc"

float4 DetailMask(float2 uv_MainTex)
{
    return tex2D(_DetailMask, uv_MainTex);
}

float4 Albedo(float4 vertexColor, float2 uv_MainTex, float2 uv_DetailAlbedoMap)
{
    float4 mainTex = UNITY_SAMPLE_TEX2D(_MainTex, uv_MainTex) * _Color;
    float3 detail = tex2D(_DetailAlbedoMap, uv_DetailAlbedoMap) * _Color;

    float3 blendTexG = UNITY_SAMPLE_TEX2D_SAMPLER(_BlendTexG, _MainTex, uv_MainTex) * _BlendColorG;
    float3 blendTexB = UNITY_SAMPLE_TEX2D_SAMPLER(_BlendTexB, _MainTex, uv_MainTex) * _BlendColorB;
    float3 blendTexR = VertexBlend(vertexColor, mainTex.rgb, blendTexG, blendTexB);
    float3 blendTex = lerp(mainTex.rgb, blendTexR, _VertexBlend);

    float3 detailedTex = lerp(blendTex, HardLight(blendTex, detail), DetailMask(uv_MainTex).a);

    return float4(detailedTex, mainTex.a);
}

float4 Normal(float2 uv_MainTex)
{
    return tex2D(_BumpMap, uv_MainTex);
}

float4 DetailNormal(float2 uv_DetailAlbedoMap)
{
    return tex2D(_DetailNormalMap, uv_DetailAlbedoMap);
}

float4 Occlusion(float2 uv_MainTex)
{
    return 1 + tex2D(_OcclusionMap, uv_MainTex) - _OcclusionStrength;
}

float4 Emission(float2 uv_MainTex, float3 viewDir, float3 normal, float pulseInterval)
{
    float4 emission = (tex2D(_EmissionMap, uv_MainTex) * _EmissionColor) * Pulse(pulseInterval);
    float4 falloff = tex2D(_FalloffMap, uv_MainTex) * _FalloffColor;
    float4 reflection = tex2D(_ReflectionMap, SphereMap(viewDir, normal)) * _ReflectionColor;

    return emission + reflection + (falloff * Falloff(viewDir, normal, _FalloffThereshold * 10));
}