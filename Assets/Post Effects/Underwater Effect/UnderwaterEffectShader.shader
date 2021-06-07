// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Underwater Effect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DistortionMap ("Distortion Map", 2D) = "white" {}
		_USpeed ("U Speed", float) = 0.5
		_VSpeed("V Speed", float) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _DistortionMap;
			half _USpeed;
			half _VSpeed;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uvCoord = i.uv;
				uvCoord.r += _Time.g * _USpeed;
				uvCoord.g += _Time.g * _VSpeed;
				
				half m = 0.1;

				half4 distortionMap = tex2D(_DistortionMap, uvCoord) * m;
				half4 c0 = tex2D(_MainTex, i.uv);
				half4 c1 = tex2D(_MainTex, (i.uv + half2(0.1, 0.05)) - distortionMap);

				half4 c = lerp(c0, c1, 0.5);
				
				return c;
			}
			ENDCG
		}
	}
}
