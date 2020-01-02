Shader "Unlit/basic"
{
    Properties
    {
        _BlurAmount("Blur", Range(0.0001, 0.01)) = 0.0025
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
        LOD 100
        
        GrabPass
        {
            "_MainTex"
        }

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BlurAmount = 0.0025; 

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
                // sample the texture
                half4 sum = 0.0; 
                sum += tex2D(_MainTex, float2(i.uv.x - 5.0 * _BlurAmount, i.uv.y)) * 0.025;
                sum += tex2D(_MainTex, float2(i.uv.x - 4.0 * _BlurAmount, i.uv.y)) * 0.05;
                sum += tex2D(_MainTex, float2(i.uv.x - 3.0 * _BlurAmount, i.uv.y)) * 0.09;
                sum += tex2D(_MainTex, float2(i.uv.x - 2.0 * _BlurAmount, i.uv.y)) * 0.12;
                sum += tex2D(_MainTex, float2(i.uv.x - _BlurAmount, i.uv.y)) * 0.15;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y)) * 0.16;
                sum += tex2D(_MainTex, float2(i.uv.x + _BlurAmount, i.uv.y)) * 0.15;
                sum += tex2D(_MainTex, float2(i.uv.x + 2.0 * _BlurAmount, i.uv.y)) * 0.12;
                sum += tex2D(_MainTex, float2(i.uv.x + 3.0 * _BlurAmount, i.uv.y)) * 0.09;
                sum += tex2D(_MainTex, float2(i.uv.x + 4.0 * _BlurAmount, i.uv.y)) * 0.05;
                sum += tex2D(_MainTex, float2(i.uv.x + 5.0 * _BlurAmount, i.uv.y)) * 0.025;
                
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y - 5.0 * _BlurAmount)) * 0.025;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y - 4.0 * _BlurAmount)) * 0.05;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y - 3.0 * _BlurAmount)) * 0.09;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y - 2.0 * _BlurAmount)) * 0.12;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y - _BlurAmount)) * 0.15;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y)) * 0.16;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y + _BlurAmount)) * 0.15;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y + 2.0 * _BlurAmount)) * 0.12;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y + 3.0 * _BlurAmount)) * 0.09;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y + 4.0 * _BlurAmount)) * 0.05;
                sum += tex2D(_MainTex, float2(i.uv.x, i.uv.y + 5.0 * _BlurAmount)) * 0.025;      
                
                sum *= 0.5;                       
                return sum;
            }
            ENDCG
        }
    }
}
