// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skybox/Cubemap Procedural" {
    Properties {
        _SunRadius ("Sun Radius", Range(0.0005, 0.1)) = 0.04
   		_SunIntensity ("Sun Intensity", Range(0, 10)) = 2
    	_SkyDayColor ("Sky Day Color", Color) = (0.5, 0.5, 0.5, 1)
        _HorizonDayColor ("Horizon Day Color", Color) = (0.4, 0.4, 0.4,1)
        _SkyNightColor ("Sky Night Color", Color) = (0,0,0.1254902,1)
        _HorizonNightColor ("Horizon Night Color", Color) = (0.1254902,0.1254902,0.2509804,1)
        _SkyBoxDay ("Sky Box Day", Cube) = "_Skybox" {}
        _ExpositionDay ("Exposition Day", Range(0.2, 2)) = 2
        _SkyBoxNight ("Sky Box Night", Cube) = "_Skybox" {}
        _ExpositionNight ("Exposition Night", Range(0.2, 2)) = 2
        _Layer1 ("Layer 1", Cube) = "_Skybox" {}
        _Layer1Exposition ("Layer 1 Exposition", Range(0, 2)) = 0
        _Layer1Speed ("Layer 1 Speed", float) = 0.0
        _Layer2 ("Layer 2", Cube) = "_Skybox" {}
        _Layer2Exposition ("Layer 2 Exposition", Range(0, 2)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Background"
            "RenderType"="Opaque"
            "PreviewType"="Skybox"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _HorizonDayColor;
            uniform float _SunRadius;
            uniform float _SunIntensity;
            uniform samplerCUBE _SkyBoxDay;
            uniform float4 _SkyDayColor;
            uniform float4 _HorizonNightColor;
            uniform samplerCUBE _SkyBoxNight;
            uniform float4 _SkyNightColor;
            uniform float _ExpositionDay;
            uniform float _ExpositionNight;
            uniform float _Layer2Exposition;
            uniform samplerCUBE _Layer2;
            uniform float _Layer1Exposition;
            uniform samplerCUBE _Layer1;
            uniform float4x4 _SkyBoxDayRot;
            uniform float4x4 _SkyBoxNightRot;  
            uniform float4x4 _Layer1Rot;     
            uniform float4x4 _Layer2Rot;
            uniform float4x4 _Layer3Rot;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
////// Emissive:
                float node_4136 = saturate(dot(lightDirection,float3(0,-1,0)));
                float node_2817 = 0.0;
                float node_7933 = min(node_2817,_SunRadius);
                float node_1476 = (1.0 - (node_7933*node_7933));
                float node_9367 = max(node_2817,_SunRadius);
                float node_9226 = (1.0 - pow((1.0 - max(0,dot(viewDirection,float3(0,-1,0)))),100.0));
                float3 emissive = (saturate((1.0-(1.0-saturate((1.0-(1.0-lerp(lerp((_SkyDayColor.rgb*texCUBE(_SkyBoxDay,mul(_SkyBoxDayRot,viewReflectDirection)).rgb*_ExpositionDay),(_SkyNightColor.rgb*texCUBE(_SkyBoxNight,mul(_SkyBoxNightRot,viewReflectDirection)).rgb*_ExpositionNight),node_4136),lerp(_HorizonDayColor.rgb,_HorizonNightColor.rgb,node_4136),pow((1.0 - max(0,dot(viewDirection,float3(0,-1,0)))),10.0)))*(1.0-(i.vertexColor.rgb*texCUBE(_Layer1,mul(_Layer1Rot,viewReflectDirection)).rgb*_Layer1Exposition)))))*(1.0-(i.vertexColor.rgb*texCUBE(_Layer2,mul(_Layer2Rot,viewReflectDirection)).rgb*_Layer2Exposition))))+(_LightColor0.rgb*pow(saturate((node_9226 + ( (max(0,dot((-1*lightDirection),viewDirection)) - node_1476) * (0.0 - node_9226) ) / ((1.0 - (node_9367*node_9367)) - node_1476))),5.0)*_SunIntensity));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
