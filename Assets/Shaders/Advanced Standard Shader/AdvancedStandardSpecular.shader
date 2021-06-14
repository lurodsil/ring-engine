Shader "Advanced Standard (Specular Setup)"{
	Properties {

		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo", 2D) = "white" {}

		[ToggleOff] _VertexBlend("Vertex Blend", Float) = 0.0

		_BlendColorG("Color", Color) = (1,1,1,1)
		_BlendTexG("Albedo (RGB)", 2D) = "white" {}
		_BlendColorB("Color", Color) = (1,1,1,1)
		_BlendTexB("Albedo (RGB)", 2D) = "white" {}
		
		_Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5

		_Glossiness("Smoothness", Range(0.0, 1.0)) = 0.5
		_GlossMap ("Smoothness Map", 2D) = "white" {}
		_GlossMapScale("Smoothness Scale", Range(0.0, 1.0)) = 1.0
		[Enum(Specular Alpha,0,Albedo Alpha,1)] _SmoothnessTextureChannel ("Smoothness texture channel", Float) = 0
		
        _SpecColor("Specular", Color) = (0.2,0.2,0.2)
        _SpecGlossMap("Specular", 2D) = "white" {}

		[ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
		[ToggleOff] _GlossyReflections("Glossy Reflections", Float) = 1.0

		_BumpScale("Scale", Float) = 1.0
		[Normal] _BumpMap("Normal Map", 2D) = "bump" {}

		_OcclusionStrength("Strength", Range(0.0, 1.0)) = 1.0
		_OcclusionMap("Occlusion", 2D) = "white" {}

		_EmissionColor("Color", Color) = (0,0,0)
		_EmissionMap("Emission", 2D) = "white" {}

		_FalloffColor("Falloff Color", Color) = (0,0,0)
		_FalloffMap("Falloff Map", 2D) = "white" {}
		_FalloffThereshold("Falloff Thereshold", Range(0.05, 1.0)) = 0.3

		_ReflectionColor("Color", Color) = (0,0,0)
		_ReflectionMap("Reflection", 2D) = "black" {}

		_DetailMask("Detail Mask", 2D) = "white" {}

		_DetailAlbedoMap("Detail Albedo x2", 2D) = "grey" {}
		_DetailNormalMapScale("Scale", Float) = 1.0
		[Normal] _DetailNormalMap("Normal Map", 2D) = "bump" {}	

		[Enum(UV0,0,UV1,1)] _UVSec ("UV Set for secondary textures", Float) = 0	

		_UVSpeed ("UV Speed", Vector) = (0,0,0,0)
		_PulseSpeed ("Pulse Speed", Float) = 0

		// Blending state
		[HideInInspector] _Mode ("__mode", Float) = 0.0
		[HideInInspector] _SrcBlend ("__src", Float) = 1.0
		[HideInInspector] _DstBlend ("__dst", Float) = 0.0
		[HideInInspector] _ZWrite ("__zw", Float) = 1.0
		[HideInInspector] _AlphaToMask ("__am", Float) = 1.0

		[Enum(Off,0,Front,1,Back,2)] _Cull("__cull", Int) = 2
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		Blend [_SrcBlend] [_DstBlend]
		ZWrite [_ZWrite]
		Cull [_Cull]
		AlphaToMask [_AlphaToMask]
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf StandardSpecular fullforwardshadows keepalpha

		#include "AdvancedStandardCommonLighting.cginc"

        #pragma shader_feature_local _NORMALMAP
        #pragma shader_feature_local _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
        #pragma shader_feature _EMISSION
        #pragma shader_feature_local _SPECGLOSSMAP
        #pragma shader_feature_local _DETAIL_MULX2
        #pragma shader_feature_local _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
        #pragma shader_feature_local _SPECULARHIGHLIGHTS_OFF
        #pragma shader_feature_local _GLOSSYREFLECTIONS_OFF

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.0

		sampler2D _SpecGlossMap;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_DetailAlbedoMap;
			float4 vertexColor : COLOR;
			float3 viewDir;
			float3 worldPos;
			float4 screenPos;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandardSpecular o) 
		{
			IN.uv_MainTex += _Time.g * _UVSpeed.xy;
			IN.uv_DetailAlbedoMap += _Time.g * _UVSpeed.zw;				

			float4 albedo = Albedo(IN.vertexColor, IN.uv_MainTex, IN.uv_DetailAlbedoMap);
			o.Albedo = albedo;
			
			fixed4 specGlossMap = tex2D(_SpecGlossMap, IN.uv_MainTex) * _SpecColor;	
			fixed4 glossMap = tex2D(_GlossMap, IN.uv_MainTex);

			#ifdef _SPECGLOSSMAP
				o.Specular = specGlossMap.rgb * _SpecColor;
				#ifdef _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
					o.Smoothness = _GlossMapScale * albedo.a * glossMap.r;
				#else
					o.Smoothness = _GlossMapScale * specGlossMap.a * glossMap.r;
				#endif
			#else
				o.Specular = _SpecColor;
				#ifdef _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
					o.Smoothness = _Glossiness * albedo.a * glossMap.r;
				#else
					o.Smoothness = _Glossiness * glossMap.r;
				#endif
			#endif				

			#ifdef _NORMALMAP
				float3 normal = UnpackNormal(Normal(IN.uv_MainTex));
				float3 detailNormal = UnpackNormal(DetailNormal(IN.uv_DetailAlbedoMap));
				o.Normal = lerp(normal, Add(normal, detailNormal), DetailMask(IN.uv_MainTex).a);
			#endif
			

			o.Occlusion = Occlusion(IN.uv_MainTex);

			#ifdef _EMISSION
				o.Emission = Emission(IN.uv_MainTex, IN.viewDir, o.Normal, _PulseSpeed);
			#endif

			o.Alpha = albedo.a * IN.vertexColor.a;
		}
		ENDCG		
	}
	FallBack "Standard"
	CustomEditor "AdvancedStandardShaderGUI"
}
