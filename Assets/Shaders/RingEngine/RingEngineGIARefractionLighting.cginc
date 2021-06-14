#include "UnityCG.cginc"
#include "PhotoshopBlendModes.cginc"	
#include "AutoLight.cginc"
#include "RingEngineInput.cginc"
#include "RingEngineFunctions.cginc"
#include "AutoLight.cginc"
#pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

struct v2f
{
	float4 vertexColor : COLOR;
	float4 vertex : SV_POSITION;
	float4 uv : TEXCOORD0;
	float2 uv2 : TEXCOORD1;
	float3 posWorld : TEXCOORD2;
	float3 normalWorld : TEXCOORD3;
	float3 tangentWorld : TEXCOORD4;
	float3 binormalWorld : TEXCOORD5;
	float4 uvgrab : TEXCOORD6;
	UNITY_FOG_COORDS(7)
	SHADOW_COORDS(8)
};

uniform half4 _LightColor0;

sampler2D _GrabTexture;
float4 _GrabTexture_TexelSize;
float4 _MainTex_ST;
float4 _MainTex_TexelSize;
float4 _SpecColor;
float _Cutoff;

#ifndef NORMAL
sampler2D _BumpMap2;
#endif

v2f vert(appdata_full v)
{
	v2f o;
	o.vertexColor = v.color;
	o.vertex = UnityObjectToClipPos(v.vertex);

	float4 uvCoord = float4(0, 0, 0, 0);
	uvCoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
	uvCoord.zw = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
	uvCoord.x += _Time.g * _UVSpeed.x;
	uvCoord.y += _Time.g * _UVSpeed.y;
	uvCoord.z += _Time.g * _UVSpeed.z;
	uvCoord.w += _Time.g * _UVSpeed.w;

	#if UNITY_UV_STARTS_AT_TOP
		uvCoord.y = _MainTex_TexelSize.y < 0 ? 1 - uvCoord.y : uvCoord.y;
		float scale = -1.0;
	#else
		float scale = 1.0;
	#endif

	o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
	o.uvgrab.zw = o.vertex.zw;
	o.uv = uvCoord;
	o.uv2 = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;

	o.posWorld = mul(unity_ObjectToWorld, v.vertex);

	o.normalWorld = normalize(mul(half4(v.normal, 0.0), unity_WorldToObject).xyz);
	o.tangentWorld = normalize(mul(unity_ObjectToWorld, v.tangent).xyz);
	o.binormalWorld = normalize(cross(o.normalWorld, o.tangentWorld) * v.tangent.w);

	UNITY_TRANSFER_FOG(o, o.vertex);
	TRANSFER_SHADOW(o)
	return o;
}

fixed4 frag(v2f i) : SV_Target
{
	fixed3 fragmentToLightSource = _WorldSpaceLightPos0.xyz - i.posWorld.xyz;
	fixed4 lightDirection = fixed4(normalize(lerp(_WorldSpaceLightPos0.xyz, fragmentToLightSource, _WorldSpaceLightPos0.w)), lerp(1.0, 1.0 / length(fragmentToLightSource), _WorldSpaceLightPos0.w));
	fixed3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
	fixed4 lightmap = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv2);
	fixed4 lightmapFinal = fixed4(SoftLight(lightmap.rgb, lightmap.a * _LightColor0), 1.0);

	fixed3 vertexColorMask = fixed3(_VertexColorR, _VertexColorG, _VertexColorB);


	float atten = SHADOW_ATTENUATION(i);

	//Diffuse
	fixed4 mainTex = tex2D(_MainTex, i.uv.xy);
	fixed4 mainTexG = tex2D(_MainTexG, i.uv.xy);
	fixed4 mainTexB = tex2D(_MainTexB, i.uv.xy);
	fixed4 mainTexBlended = VertexBlend(i.vertexColor, mainTex, mainTexG, mainTexB, vertexColorMask);
	fixed4 mainTexPainted = lerp(mainTex, mainTex * i.vertexColor, _VertexColors);
	fixed4 mainTexFinal = lerp(mainTexPainted, mainTexBlended, _VertexBlend) * _Color;

	//Specular
	fixed4 specGlossMap = tex2D(_SpecGlossMap, i.uv.xy) * _SpecColor;

	//Gloss
	fixed4 glossMap = tex2D(_GlossMap, i.uv.xy);
	fixed4 glossMapG = tex2D(_GlossMapG, i.uv.xy);
	fixed4 glossMapB = tex2D(_GlossMapB, i.uv.xy);
	fixed4 glossMapFinal = VertexBlend(i.vertexColor, glossMap, glossMapG, glossMapB, vertexColorMask) * specGlossMap.a * _SpecColor.a * _Glossiness;
	
	//Normal
	fixed4 bumpMapFinal = lerp(tex2D(_BumpMap, i.uv.xy), tex2D(_BumpMap2, i.uv.zw), 0.5);

	fixed4 emissionMap = tex2D(_EmissionMap, i.uv.xy) * _EmissionColor * Pulse(_PulseTime);

	//unpackNormal function
	fixed3 localCoords = float3(2.0 * bumpMapFinal.ag - float2(1.0, 1.0), 1);

	//normal transpose matrix
	float3x3 local2WorldTranspose = float3x3(
		i.tangentWorld,
		i.binormalWorld,
		i.normalWorld
		);

	//calculate normal direction
	fixed3 normalDirection = normalize(mul(localCoords, local2WorldTranspose));

	//Lighting
	//dot product
	half nDotL = saturate(dot(normalDirection, lightDirection.xyz));

	half glossiness = exp2(_Glossiness * 10);

	//Refraction
	#if UNITY_SINGLE_PASS_STEREO
		i.uvgrab.xy = TransformStereoScreenSpaceTex(i.uvgrab.xy, i.uvgrab.w);
	#endif

	// calculate perturbed coordinates
	float2 offset = localCoords * _Distortion * _GrabTexture_TexelSize.xy;
	#ifdef UNITY_Z_0_FAR_FROM_CLIPSPACE //to handle recent standard asset package on older version of unity (before 5.5)
		i.uvgrab.xy = offset * UNITY_Z_0_FAR_FROM_CLIPSPACE(i.uvgrab.z) + i.uvgrab.xy;
	#else
		i.uvgrab.xy = offset * i.uvgrab.z + i.uvgrab.xy;
	#endif

	half4 refraction = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(i.uvgrab));

	fixed3 diffuseReflection = lightDirection.w * _LightColor0.xyz * nDotL;//lightmapFinal.rgb * lightDirection.w * _LightColor0.xyz * nDotL;
	fixed3 specularReflection = diffuseReflection.rgb * specGlossMap.rgb * pow(saturate(dot(reflect(-lightDirection.xyz, normalDirection), viewDirection)), glossiness);

	fixed3 lightingFinal = (1 + diffuseReflection + (specularReflection * specGlossMap.a * glossMapFinal * glossiness)) *  atten; //* lightmapFinal;

	clip(mainTexFinal.a - _Cutoff);

	fixed3 final = (mainTexFinal.rgb * lightingFinal) + emissionMap.rgb; 

	// apply fog
	UNITY_APPLY_FOG(i.fogCoord, final);
	return fixed4(lerp(final.rgb, refraction.rgb, _Refraction), mainTexFinal.a * i.vertexColor.a) ;
}