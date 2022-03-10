Shader "MisShader/EscalaGris"
{
    Properties
    {
        _MainTex("Main Tex",2D) = "white"{}
        _LuminosityAmount("Grayscale Amount",Range(0.0,1.0)) = 1.0
    }
        SubShader
        {
            Pass
            {
                HLSLPROGRAM
                #pragma vertex vertexShader
                #pragma fragment fragmentShader

                #include "unityCG.cginc"
                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed _LuminosityAmount;

                    struct vertexInput
                {
                    float4 vertex:POSITION;
                    float2 uv:TEXCOORD0;
                };

                struct vertexOutput
                {
                    float4 vertex:SV_POSITION;
                    float2 uv:TEXCOORD0;
                };

                vertexOutput vertexShader(vertexInput i)
                {
                    vertexOutput o;
                    o.vertex = UnityObjectToClipPos(i.vertex);
                    o.uv = i.uv;
                    o.uv = TRANSFORM_TEX(i.uv, _MainTex);
                    return o;
                }

                fixed4 fragmentShader(vertexOutput o) :SV_TARGET
                {
                    fixed4 renderTex = tex2D(_MainTex,o.uv);
                float luminosity = 0.299 * renderTex.r +
                                    0.587 * renderTex.g +
                                    0.114 * renderTex.b;
                fixed4 finalColor = lerp(renderTex, luminosity, _LuminosityAmount);
                return finalColor;
                }
                ENDHLSL
            }

        }
            FallBack "Diffuse"
}
