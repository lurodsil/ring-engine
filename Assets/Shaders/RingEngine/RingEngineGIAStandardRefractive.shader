Shader "Ring Engine/GIA/Standard Refractive"
{
	Properties
	{
		//Material Settings
		[MaterialEnum(Off,0,Front,1,Back,2)] _Cull("Cull", Int) = 2
		_SelfIllum("Self Illumination", Range(0,1)) = 0
		_PulseTime("Pulsating Light", Range(0,100)) = 0
		_Refraction("Refraction", Range(0,1)) = 0.5
		_Distortion("Distortion", Range(0,128)) = 10
		_UVSpeed("UV Speed", Vector) = (0, 0, 0, 0)
		[Toggle] _VertexBlend("Vertex Blend", Float) = 0
		[Toggle] _VertexColors("Vertex Colors", Float) = 0
		[Toggle] _VertexColorR("Vertex Color Red", Float) = 0
		[Toggle] _VertexColorG("Vertex Color Green", Float) = 0
		[Toggle] _VertexColorB("Vertex Color Blue", Float) = 0

		_Color("Color (RGB), Alpha (A)", Color) = (1, 1, 1, 1)
		_MainTex("Albedo Red (RGB), Alpha (A)", 2D) = "white" {}
		[NoScaleOffset]_MainTexG("Albedo Green (RGB), Alpha (A)", 2D) = "white" {}
		[NoScaleOffset]_MainTexB("Albedo Blue (RGB), Alpha (A)", 2D) = "white" {}

		//_Cutoff("Alpha Cutout", Range(0.0, 1.0)) = 0.33

		_SpecColor("Specular Color (RGB), Smoothness (A)", Color) = (0.2, 0.2, 0.2, 1)
		[NoScaleOffset]_SpecGlossMap("Specular Map (RGB), Smoothness (A)", 2D) = "white" {}

		_Glossiness("Smoothness", Range(0.0, 1.0)) = 0.5
		[NoScaleOffset]_GlossMap("Gloss Map Red (R)", 2D) = "white" {}
		[NoScaleOffset]_GlossMapG("Gloss Map Green (R)", 2D) = "white" {}
		[NoScaleOffset]_GlossMapB("Gloss Map Blue (R)", 2D) = "white" {}

		[NoScaleOffset]_BumpMap("Normal Map (RGB)", 2D) = "bump" {}
		[NoScaleOffset]_BumpMap2("Normal 2 (RGB)", 2D) = "bump" {}
		[NoScaleOffset]_BumpMapG("Normal Map Green (RGB)", 2D) = "bump" {}
		[NoScaleOffset]_BumpMapB("Normal Map Blue (RGB)", 2D) = "bump" {}

		_EmissionColor("Emission Color (RGB)", Color) = (0,0,0)
		[NoScaleOffset]_EmissionMap("Emission Map (RGB)", 2D) = "white" {}
	}

	

	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }

		GrabPass {
			Name "BASE"
			Tags { "LightMode" = "Always" }
		}
		Pass
		{
			Tags{ "LightMode" = "Always" }
			LOD 100
			
			Cull[_Cull]

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "RingEngineGIARefractionLighting.cginc"	
			ENDCG
		}
	}
	FallBack "Diffuse"
	CustomEditor "RingEngineShaderGUI"
}
