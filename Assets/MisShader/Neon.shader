Shader "MisShader/Neon"
{
    Properties
    {
        _Color("Main Color",Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _Holograma("Holograma",2D) = "white" {}
        _MySliderValue("Wave",Range(0,50)) = 5

    }
        SubShader
        {
            Tags { "RenderType" = "Opaque"
                    "Queue" = "Transparent"
            }

               Blend SrcAlpha One

            Pass
            {
               HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                CBUFFER_START(UnityPerMaterial)
                    float4 _Color;
                    float4 _MainTex_ST;
                    float _MySliderValue;
                CBUFFER_END

                    struct vertexInput
                {
                    float4 position:POSITION;
                    float2 uv:TEXCOORD0;
                    float2 huv:TEXCOORD1;
                };

                struct vertexOutput
                {
                    float4 position:SV_POSITION;
                    float2 uv:TEXCOORD0;
                    float2 huv:TEXCOORD1;
                };

                TEXTURE2D(_MainTex);
                TEXTURE2D(_Holograma);
                SAMPLER(sampler_MainTex);
                SAMPLER(sampler_Holograma);

                vertexOutput vert(vertexInput i)
                {
                    vertexOutput o;
                    o.position = TransformObjectToHClip(i.position.xyz);
                    o.uv = TRANSFORM_TEX(i.uv, _MainTex);
                    o.huv = i.uv;
                    return o;
                }

                float4 frag(vertexOutput o) :SV_TARGET
                {
                    half4 baseTex = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex,o.uv) * _Color;
                    half4 holo = SAMPLE_TEXTURE2D(_Holograma, sampler_Holograma, o.uv);
                    baseTex.a = abs(tan(o.uv.y * _MySliderValue * _Time));
                    return baseTex * holo;
                }

                ENDHLSL

            }
        }
}
