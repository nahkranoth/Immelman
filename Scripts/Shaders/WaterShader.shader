Shader "Custom/Water" {
        Properties {
            _EdgeLength ("Edge length", Range(2,50)) = 15
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _DispTex ("Disp Texture", 2D) = "gray" {}
            _NormalMap ("Normalmap", 2D) = "bump" {}
            _Displacement ("Displacement", Range(0, 1.0)) = 0.3
            _Timer ("Time", Range(0, 1.0)) = 0.3
            _ColorMin ("MinColor", color) = (0,0,0,1)
            _ColorMax ("MaxColor", color) = (1,1,1,1)
            _Glossiness ("Smoothness", Range(0,1)) = 0.5
            _Metallic ("Metallic", Range(0,1)) = 0.5
            _YOffset ("YOffset", Range(0,.1)) = 0.
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf Standard vertex:vert tessellate:tessEdge nolightmap
            #pragma target 4.6
            #include "Tessellation.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            float _EdgeLength;

            float4 tessEdge (appdata_full v0, appdata_full v1, appdata_full v2)
            {
                return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
            }

            sampler2D _DispTex;
            float _Displacement;
            float _Timer;
            float _YOffset;

            void vert (inout appdata_full v)
            {
                float displacement = tex2Dlod(_DispTex, float4(v.texcoord.xy + (_Time * _Timer * 0.1) ,0,0)).r * _Displacement;
                v.vertex.xyz += v.normal * displacement;
                v.vertex.y += _YOffset;
            }

            sampler2D _MainTex;
            sampler2D _NormalMap;
            fixed4 _ColorMin;
            fixed4 _ColorMax;
            half _Glossiness;
            half _Metallic;

            struct Input {
                float2 uv_MainTex;
            };

            void surf (Input IN, inout SurfaceOutputStandard o) {
                half4 disp = tex2D (_DispTex, IN.uv_MainTex + (_Time * _Timer * 0.1));
                half3 clr = lerp(_ColorMin, _ColorMax, disp);
                o.Albedo = clr.rgb;
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;
            }

            ENDCG
        }
        FallBack "Diffuse"
    }