// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/PhotoshopBlendModes"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_BlendTex("Blend", 2D) = "white" {}
		_Opacity("Opacity", Range(0,1)) = 1
		[Toggle] _Add("Add", Float) = 0
		[Toggle] _Average("Average", Float) = 0
		[Toggle] _ColorBurn("Color Burn", Float) = 0
		[Toggle] _ColorDodge("Color Dodge", Float) = 0
		[Toggle] _Darken("Darken", Float) = 0
		[Toggle] _Difference("Difference", Float) = 0
		[Toggle] _Divide("Divide", Float) = 0
		[Toggle] _Exclusion("Exclusion", Float) = 0
		[Toggle] _Glow("Glow", Float) = 0
		[Toggle] _HardLight("Hard Light", Float) = 0
		[Toggle] _HardMix("Hard Mix", Float) = 0
		[Toggle] _Lighten("Lighten", Float) = 0
		[Toggle] _LinearBurn("Linear Burn", Float) = 0
		[Toggle] _LinearDodge("Linear Dodge", Float) = 0
		[Toggle] _LinearLight("Linear Light", Float) = 0
		[Toggle] _Multiply("Multiply", Float) = 0
		[Toggle] _Negation("Negation", Float) = 0
		[Toggle] _Normal("Normal", Float) = 0
		[Toggle] _Overlay("Overlay", Float) = 0
		[Toggle] _Phoenix("Phoenix", Float) = 0
		[Toggle] _PinLight("Pin Light", Float) = 0
		[Toggle] _Reflect("Reflect", Float) = 0
		[Toggle] _Screen("Screen", Float) = 0
		[Toggle] _SoftLight("Soft Light", Float) = 0
		[Toggle] _Substract("Substract", Float) = 0
		[Toggle] _Subtract("Subtract", Float) = 0
		[Toggle] _VividLight("Vivid Light", Float) = 0
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
			#include "PhotoshopBlendModes.cginc"

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
			sampler2D _BlendTex;
			half _Opacity;

			half _Add;
			half _Average;
			half _ColorBurn;
			half _ColorDodge;
			half _Darken;
			half _Difference;
			half _Divide;
			half _Exclusion;
			half _Glow;
			half _HardLight;
			half _HardMix;
			half _Lighten;
			half _LinearBurn;
			half _LinearDodge;
			half _LinearLight;
			half _Multiply;
			half _Negation;
			half _Normal;
			half _Overlay;
			half _Phoenix;
			half _PinLight;
			half _Reflect;
			half _Screen;
			half _SoftLight;
			half _Substract;
			half _Subtract;
			half _VividLight;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 base = tex2D(_MainTex, i.uv);
				fixed4 blend = tex2D(_BlendTex, i.uv);

				fixed3 normal = lerp(base, Normal(base.rgb, blend.rgb, _Opacity), _Normal);
				fixed3 add = lerp(normal, Add(base.rgb, blend.rgb, _Opacity), _Add);
				fixed3 average = lerp(add, Average(base.rgb, blend.rgb, _Opacity), _Average);
				fixed3 colorBurn = lerp(average, ColorBurn(base.rgb, blend.rgb, _Opacity), _ColorBurn);
				fixed3 colorDodge = lerp(colorBurn, ColorDodge(base.rgb, blend.rgb, _Opacity), _ColorDodge);
				fixed3 darken = lerp(colorDodge, Darken(base.rgb, blend.rgb, _Opacity), _Darken);
				fixed3 difference = lerp(darken, Difference(base.rgb, blend.rgb, _Opacity), _Difference);
				fixed3 divide = lerp(difference, Divide(base.rgb, blend.rgb, _Opacity), _Divide);
				fixed3 exclusion = lerp(divide, Exclusion(base.rgb, blend.rgb, _Opacity), _Exclusion);
				fixed3 reflect = lerp(exclusion, Reflect(base.rgb, blend.rgb, _Opacity), _Reflect);
				fixed3 glow = lerp(reflect, Glow(base.rgb, blend.rgb, _Opacity), _Glow);
				fixed3 overlay = lerp(glow, Overlay(base.rgb, blend.rgb, _Opacity), _Overlay);
				fixed3 hardLight = lerp(overlay, HardLight(base.rgb, blend.rgb, _Opacity), _HardLight);
				fixed3 vividLight = lerp(hardLight, VividLight(base.rgb, blend.rgb, _Opacity), _VividLight);
				fixed3 hardMix = lerp(vividLight, HardMix(base.rgb, blend.rgb, _Opacity), _HardMix);
				fixed3 lighten = lerp(hardMix, Lighten(base.rgb, blend.rgb, _Opacity), _Lighten);
				fixed3 linearBurn = lerp(lighten, LinearBurn(base.rgb, blend.rgb, _Opacity), _LinearBurn);
				fixed3 linearDodge = lerp(linearBurn, LinearDodge(base.rgb, blend.rgb, _Opacity), _LinearDodge);
				fixed3 linearLight = lerp(linearDodge, LinearLight(base.rgb, blend.rgb, _Opacity), _LinearLight);
				fixed3 multiply = lerp(linearLight, Multiply(base.rgb, blend.rgb, _Opacity), _Multiply);
				fixed3 negation = lerp(multiply, Negation(base.rgb, blend.rgb, _Opacity), _Negation);
				fixed3 phoenix = lerp(negation, Phoenix(base.rgb, blend.rgb, _Opacity), _Phoenix);
				fixed3 pinLight = lerp(phoenix, PinLight(base.rgb, blend.rgb, _Opacity), _PinLight);
				fixed3 screen = lerp(pinLight, Screen(base.rgb, blend.rgb, _Opacity), _Screen);
				fixed3 softLight = lerp(screen, SoftLight(base.rgb, blend.rgb, _Opacity), _SoftLight);
				fixed3 substract = lerp(softLight, Substract(base.rgb, blend.rgb, _Opacity), _Substract);
				fixed3 subtract = lerp(substract, Subtract(base.rgb, blend.rgb, _Opacity), _Subtract);

				return fixed4(subtract, base.a * blend.a);
			}
			ENDCG
		}
	}
}
