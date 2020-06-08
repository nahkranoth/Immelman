Shader "Custom/WaterVapor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Alpha ("Alpha", float) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 200
   
        CGPROGRAM
 
        #pragma surface surf Standard fullforwardshadows alpha:fade
        #pragma target 3.0
 
        sampler2D _MainTex;
 
        struct Input {
            float2 uv_MainTex;
        };
 
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float _Alpha;
 
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;
            float dist = 1.-uv.x;
            uv.x -= _Time*160.;
            fixed4 c = tex2D (_MainTex, uv) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a * _Alpha * dist;
        }
        ENDCG
    }
    FallBack "Standard"
}