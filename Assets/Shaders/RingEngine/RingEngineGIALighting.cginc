#include "UnityCG.cginc"
#include "PhotoshopBlendModes.cginc"	
#include "AutoLight.cginc"
#include "RingEngineInput.cginc"
#include "RingEngineFunctions.cginc"

struct v2f
{
	float4 vertexColor : COLOR;
	float4 vertex : SV_POSITION;
	float2 uv : TEXCOORD0;
	float2 uv2 : TEXCOORD1;
	float3 posWorld : TEXCOORD2;
	float3 normalWorld : TEXCOORD3;
	float3 tangentWorld : TEXCOORD4;
	float3 binormalWorld : TEXCOORD5;
	UNITY_FOG_COORDS(6)
};

uniform half4 _LightColor0;

float4 _MainTex_ST;
float4 _MainTex_TexelSize;
float4 _SpecColor;
float _Cutoff;

v2f vert(appdata_full v)
{
	v2f o;
	o.vertexColor = v.color;
	o.vertex = UnityObjectToClipPos(v.vertex);

	float2 uvCoord = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
	uvCoord.r += _Time.g * _USpeed;
	uvCoord.g += _Time.g * _VSpeed;

	#if UNITY_UV_STARTS_AT_TOP
		uvCoord.y = _MainTex_TexelSize.y < 0 ? 1 - uvCoord.y : uvCoord.y;
	#endif

	o.uv = uvCoord;
	o.uv2 = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;

	o.posWorld = mul(unity_ObjectToWorld, v.vertex);

	o.normalWorld = normalize(mul(half4(v.normal, 0.0), unity_WorldToObject).xyz);
	o.tangentWorld = normalize(mul(unity_ObjectToWorld, v.tangent).xyz);
	o.binormalWorld = normalize(cross(o.normalWorld, o.tangentWorld) * v.tangent.w);

	UNITY_TRANSFER_FOG(o, o.vertex);
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

	//Diffuse
	fixed4 mainTex = tex2D(_MainTex, i.uv);
	fixed4 mainTexG = tex2D(_MainTexG, i.uv);
	fixed4 mainTexB = tex2D(_MainTexB, i.uv);
	fixed4 mainTexBlended = VertexBlend(i.vertexColor, mainTex, mainTexG, mainTexB, vertexColorMask);
	fixed4 mainTexPainted = lerp(mainTex, mainTex * i.vertexColor, _VertexColors);
	fixed4 mainTexFinal = lerp(mainTexPainted, mainTexBlended, _VertexBlend) * _Color;

	//Specular
	fixed4 specGlossMap = tex2D(_SpecGlossMap, i.uv) * _SpecColor;

	//Gloss
	fixed4 glossMap = tex2D(_GlossMap, i.uv);
	fixed4 glossMapG = tex2D(_GlossMapG, i.uv);
	fixed4 glossMapB = tex2D(_GlossMapB, i.uv);
	fixed4 glossMapFinal = VertexBlend(i.vertexColor, glossMap, glossMapG, glossMapB, vertexColorMask) * specGlossMap.a * _SpecColor.a * _Glossiness;
	
	//Normal
	fixed4 bumpMap = tex2D(_BumpMap, i.uv);

	fixed4 emissionMap = tex2D(_EmissionMap, i.uv) * _EmissionColor * Pulse(_PulseTime);

	//unpackNormal function
	fixed3 localCoords = float3(2.0 * bumpMap.ag - float2(1.0, 1.0), 1);

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

	fixed3 diffuseReflection = lightmapFinal.rgb * lightDirection.w * _LightColor0.xyz * nDotL;
	fixed3 specularReflection = diffuseReflection.rgb * specGlossMap.rgb * pow(saturate(dot(reflect(-lightDirection.xyz, normalDirection), viewDirection)), glossiness);

	fixed3 lightingFinal = (1 + diffuseReflection + (specularReflection * specGlossMap.a * glossMapFinal * glossiness)) * lightmapFinal;

	clip(mainTexFinal.a - _Cutoff);

	fixed3 final = (mainTexFinal.rgb * lightingFinal.rgb) + emissionMap.rgb;

	// apply fog
	UNITY_APPLY_FOG(i.fogCoord, final);
	return fixed4(final.rgb, mainTexFinal.a * i.vertexColor.a);
}