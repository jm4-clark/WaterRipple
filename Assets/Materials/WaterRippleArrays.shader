﻿Shader "Custom/WaterRippleShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Scale ("Scale", float) = 1
		_Speed ("Speed", float) = 1
		_Frequency ("Frequency", float) = 1
		//_ArraySize ("Array Size", int) = 8
		//_WaveAmplitude[50] ("WaveAmplitude", float) = 0
		//_xImpact[50] ("x Impact", float) = 0
		
		[HideInInspector]_WaveAmplitude1 ("WaveAmplitude1", float) = 0
  [HideInInspector]_WaveAmplitude2 ("WaveAmplitude2", float) = 0
  [HideInInspector]_WaveAmplitude3 ("WaveAmplitude3", float) = 0
  [HideInInspector]_WaveAmplitude4 ("WaveAmplitude4", float) = 0
  [HideInInspector]_WaveAmplitude5 ("WaveAmplitude5", float) = 0
  [HideInInspector]_WaveAmplitude6 ("WaveAmplitude6", float) = 0
  [HideInInspector]_WaveAmplitude7 ("WaveAmplitude7", float) = 0
  [HideInInspector]_WaveAmplitude8 ("WaveAmplitude8", float) = 0
  [HideInInspector]_xImpact1 ("x Impact 1", float) = 0
  [HideInInspector]_zImpact1 ("z Impact 1", float) = 0
  [HideInInspector]_xImpact2 ("x Impact 2", float) = 0
  [HideInInspector]_zImpact2 ("z Impact 2", float) = 0
  [HideInInspector]_xImpact3 ("x Impact 3", float) = 0
  [HideInInspector]_zImpact3 ("z Impact 3", float) = 0
  [HideInInspector]_xImpact4 ("x Impact 4", float) = 0
  [HideInInspector]_zImpact4 ("z Impact 4", float) = 0
  [HideInInspector]_xImpact5 ("x Impact 5", float) = 0
  [HideInInspector]_zImpact5 ("z Impact 5", float) = 0
  [HideInInspector]_xImpact6 ("x Impact 6", float) = 0
  [HideInInspector]_zImpact6 ("z Impact 6", float) = 0
  [HideInInspector]_xImpact7 ("x Impact 7", float) = 0
  [HideInInspector]_zImpact7 ("z Impact 7", float) = 0
  [HideInInspector]_xImpact8 ("x Impact 8", float) = 0
  [HideInInspector]_zImpact8 ("z Impact 8", float) = 0
  [HideInInspector]_Distance1 ("Distance1", float) = 0
  [HideInInspector]_Distance2 ("Distance2", float) = 0
  [HideInInspector]_Distance3 ("Distance3", float) = 0
  [HideInInspector]_Distance4 ("Distance4", float) = 0
  [HideInInspector]_Distance5 ("Distance5", float) = 0
  [HideInInspector]_Distance6 ("Distance6", float) = 0
  [HideInInspector]_Distance7 ("Distance7", float) = 0
  [HideInInspector]_Distance8 ("Distance8", float) = 0
  
	}
	SubShader {
		Tags { "RenderType"="Opaque"}// "Queue"="Gemoetry+1" "ForceNoShadowCasting"="True" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma target 4.0

		sampler2D _MainTex;
		sampler2D _BumpMap;
		half _Glossiness;
		half _Metallic;
		float _Scale, _Speed, _Frequency;
		half4 _Color;
		//int _ArraySize;
		//float _WaveAmplitude[50];
		//float _OffsetX[50], _OffsetZ[50];
		//float _Distance[50];
		//float _xImpact[50], _zImpact[50];
		float _WaveAmplitude1, _WaveAmplitude2, _WaveAmplitude3, _WaveAmplitude4, _WaveAmplitude5, _WaveAmplitude6, _WaveAmplitude7, _WaveAmplitude8;
		float _OffsetX1, _OffsetZ1, _OffsetX2, _OffsetZ2, _OffsetX3, _OffsetZ3, _OffsetX4, _OffsetZ4, _OffsetX5, _OffsetZ5, _OffsetX6, _OffsetZ6, _OffsetX7, _OffsetZ7, _OffsetX8, _OffsetZ8;
		float _Distance1, _Distance2 , _Distance3, _Distance4, _Distance5, _Distance6, _Distance7, _Distance8;
		float _xImpact1, _zImpact1, _xImpact2, _zImpact2, _xImpact3, _zImpact3, _xImpact4, _zImpact4, _xImpact5, _zImpact5, _xImpact6, _zImpact6, _xImpact7, _zImpact7, _xImpact8, _zImpact8;

		struct Input {
			float2 uv_MainTex;
			 float uv_BumpMap;
			float3 customValue;
		};

		void vert( inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			//_ArraySize = 50;
			half offsetvert = ((v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z)); //ripple
			half offsetvert2 = v.vertex.x + v.vertex.z; //diagonal waves
			half offsetvert3 = v.vertex.x; //horizontal waves

			half value0 = _Scale * sin(_Time.w * _Speed  + offsetvert2 * _Frequency );

			//half value[50];
			//for (int i = 0; i < _ArraySize; i++)
			//{
			//	value[i] = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX[i]) + (v.vertex.z * _OffsetZ[i]));
			//}
			
			half value1 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX1) + (v.vertex.z * _OffsetZ1));
			half value2 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX2) + (v.vertex.z * _OffsetZ2));
			half value3 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX3) + (v.vertex.z * _OffsetZ3));
			half value4 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX4) + (v.vertex.z * _OffsetZ4));
			half value5 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX5) + (v.vertex.z * _OffsetZ5));
			half value6 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX6) + (v.vertex.z * _OffsetZ6));
			half value7 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX7) + (v.vertex.z * _OffsetZ7));
			half value8 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert + (v.vertex.x * _OffsetX8) + (v.vertex.z * _OffsetZ8));
			
			
			v.vertex.y += value0;
			v.normal.y += value0;
			o.customValue = value0;

			float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

			
		
		for (int i = 0; i < _ArraySize; i++)
		{
			if (sqrt(pow(worldPos.x - _xImpact[i], 2) + pow(worldPos.z - _zImpact[i], 2)) < _Distance[i])
			{
				v.vertex.y += value[i] * _WaveAmplitude[i];
				v.normal.y += value[i] * _WaveAmplitude[i];
				o.customValue +=  value[i] * _WaveAmplitude[i];
			}
		}
		
		/*
		if (sqrt(pow(worldPos.x - _xImpact[0], 2) + pow(worldPos.z - _zImpact[0], 2)) < _Distance[0])
		{
			v.vertex.y += value[0] * _WaveAmplitude1;
			v.normal.y += value[0] * _WaveAmplitude1;	
			o.customValue += value[0] * _WaveAmplitude1;	
		}

		
		
			
		}

		
		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			 o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_MainTex) * 0.2);
			 o.Normal.y += IN.customValue;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
