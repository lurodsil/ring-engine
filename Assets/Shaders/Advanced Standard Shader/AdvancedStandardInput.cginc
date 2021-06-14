//Common Samplers
UNITY_DECLARE_TEX2D(_MainTex);
UNITY_DECLARE_TEX2D_NOSAMPLER(_BlendTexG);
UNITY_DECLARE_TEX2D_NOSAMPLER(_BlendTexB);
sampler2D _GlossMap;
sampler2D _BumpMap;
sampler2D _EmissionMap;
sampler2D _FalloffMap;
sampler2D _ReflectionMap;
sampler2D _DetailAlbedoMap;
sampler2D _DetailNormalMap;
sampler2D _DetailMask;
sampler2D _OcclusionMap;

//Common Values
half _Glossiness;
half _GlossMapScale;
half _OcclusionStrength;
half _BumpScale;
half _FalloffThereshold;
half _VertexBlend;
half _PulseSpeed;
float4 _UVSpeed;

//Common Colors
float4 _Color;
float4 _BlendColorG;
float4 _BlendColorB;
float4 _EmissionColor;
float4 _FalloffColor;
float4 _ReflectionColor;