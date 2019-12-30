Shader "Zero/Test"{
    Properties{
        _MainTex("Texture", 2D) = "white"{}
    }
    
    SubShader{
        CGPROGRAM
            #pragma surface surf Lambert
            
            sampler2D _MainTex;
            
            struct Input{
                half2 uv_MainTex;
            };
            
            void surf(Input IN, inout SurfaceOutput OUT){
                OUT.Albedo = tex2D(_MainTex, IN.uv_MainTex);
            }
            
        ENDCG
    }
    
    Fallback "LegasyDiffuse"
}