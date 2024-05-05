Shader "Custom/OrangeOutlineShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1, 0.5, 0, 1)
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert

        #include "UnityCG.cginc"

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _OutlineColor;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
            
            fixed4 outlineColor = fixed4(1, 0.5, 0, 1);
            
            o.Emission = outlineColor.rgb;
            
            o.Albedo = baseColor.rgb;
            o.Alpha = baseColor.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
