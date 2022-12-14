Shader "MADFINGER/Transparent/Blinking GodRays" {
	Properties {
		_MainTex ("Base texture", 2D) = "white" {}
		_FadeOutDistNear ("Near fadeout dist", Float) = 10
		_FadeOutDistFar ("Far fadeout dist", Float) = 10000
		_Multiplier ("Color multiplier", Float) = 1
		_Bias ("Bias", Float) = 0
		_TimeOnDuration ("ON duration", Float) = 0.5
		_TimeOffDuration ("OFF duration", Float) = 0.5
		_BlinkingTimeOffsScale ("Blinking time offset scale (seconds)", Float) = 5
		_SizeGrowStartDist ("Size grow start dist", Float) = 5
		_SizeGrowEndDist ("Size grow end dist", Float) = 50
		_MaxGrowSize ("Max grow size", Float) = 2.5
		_NoiseAmount ("Noise amount (when zero, pulse wave is used)", Range(0, 0.5)) = 0
		_Color ("Color", Vector) = (1,1,1,1)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}