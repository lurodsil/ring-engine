//Material Settings
//Self Illumination - Main texture will be added to emission multiplied by this value.
float _SelfIllum;
//Pulsating Lights - Interval time of pulse. Used for blink lights;
float _PulseTime;
//UV Animation - UV speed will be set by these values.
float _USpeed;
float _VSpeed;
float4 _UVSpeed;
//Vertex Blend - Vertex Colors will work as a mask for the RGB texture maps. Affect main texture, gloss map and normal map.
float _VertexBlend;
//Vertex Colors - Main texture will be multiplied by the color of the vertex. Works only if Vertex Blend is disabled.
float _VertexColors;
//Vertex Colors - The corresponding texture will be multiplied by the color of the vertex masked by current channel of the texture. Works only if Vertex Blend is enabled.
float _VertexColorR;
float _VertexColorG;
float _VertexColorB;

//Standard Inputs
float4 _Color;
sampler2D _MainTex;
//float4 _SpecColor;
sampler2D _SpecGlossMap;
float _Glossiness;
sampler2D _GlossMap;

sampler2D _BumpMap;

float _OcclusionStrength;
sampler2D _OcclusionMap;
float4 _EmissionColor;
sampler2D _EmissionMap;
float4 _FalloffColor;
sampler2D _FalloffMap;
float _ReflectionStrength;
sampler2D _Reflection;

//Blend Inputs
//If Vertex Blend is enabled main texture will be the red channel so we will create input for the green and blue channels.
sampler2D _MainTexG;
sampler2D _MainTexB;
//If Vertex Blend is enabled gloss map will be the red channel so we will create input for the green and blue channels.
sampler2D _GlossMapG;
sampler2D _GlossMapB;
float _Refraction;
float _Distortion;