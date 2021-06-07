// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/RadialBlur" {
	Properties{
		_MainTex ("Texture", 2D) = "white" {}
        _BlurStrength ("", Float) = 0.5
        _BlurWidth ("", Float) = 0.5		
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag		
			#pragma glsl
			
			//#pragma target 3.0
			
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
				//float2 dir : TEXCOORD1;
				//float dist : TEXCOORD2;
			};

			uniform sampler2D _MainTex;
			uniform half _BlurStrength;
			uniform half _BlurWidth;
			uniform half _iWidth;
			uniform half _iHeight;			
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				
				//float2 dir = 0.5 * half2(_iHeight,_iWidth) - o.uv;
				
				//o.dist = sqrt(dir.x*dir.x + dir.y*dir.y);
				
				//o.dir = dir / o.dist;
				return o;
			}
	
	        #define SAMPLES_FLOAT 10.0f
	
			fixed4 frag (v2f i) : SV_Target {
				float2 uv = i.uv;
        		half4 color = tex2D(_MainTex, uv);
       
        		// some sample positions
        		//half samples[10];//
				//samples = half [](-0.08,-0.05,-0.03,-0.02,-0.01,0.01,0.02,0.03,0.05,0.08);
       
        		//vector to the middle of the screen
        		half2 dir = 0.5 * half2 (_iHeight,_iWidth) - uv;
       
        		//distance to center
        		half dist = sqrt (dir.x*dir.x + dir.y*dir.y);
       
        		//normalize direction
       		    dir = dir/dist;
 
				//float2 dir = i.dir;
 				//float dist = i.dist;
				
        		//additional samples towards center of screen				
        		half4 sum = color;
        		for (float n = 0; n < SAMPLES_FLOAT; n++) {
        		    //sum += tex2D(_MainTex, uv + dir * ((n*0.016)-0.08) * _BlurWidth * _iWidth);
        		    sum += tex2D (_MainTex, uv + dir * ((n*0.08) * _BlurWidth) * _iWidth);					
        		}
       
        		sum /= SAMPLES_FLOAT+1;
     
        		//blend original with blur
        		return lerp (color, sum, saturate ((dist / _iWidth) * _BlurStrength));
			}
			ENDCG
		}
	}
}