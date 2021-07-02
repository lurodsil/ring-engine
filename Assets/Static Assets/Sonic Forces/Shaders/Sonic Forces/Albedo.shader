Shader "Sonic Forces/Albedo" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_PRM("PRM", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_EmissionMap("Emission", 2D) = "black" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _PRM;
		sampler2D _EmissionMap;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 albedo = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed4 prm = tex2D(_PRM, IN.uv_MainTex);
			fixed4 emission = tex2D(_EmissionMap, IN.uv_MainTex);
			o.Albedo = albedo.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = prm.r * _Metallic;
			o.Smoothness = prm.g *_Glossiness;
			o.Occlusion = prm.b;
			o.Emission = emission;
			o.Alpha = albedo.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
