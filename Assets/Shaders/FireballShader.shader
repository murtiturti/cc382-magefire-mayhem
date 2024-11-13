Shader "Custom/AnimatedFireballWithColorChange"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 0.5, 0, 1)  // Orange base color
        _TimeSpeed ("Time Speed", Float) = 1.0
        _NoiseIntensity ("Noise Intensity", Float) = 0.1
        _DisplacementAmount ("Displacement Amount", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            Tags { "LightMode" = "Always" } // Unlit, no lighting
            Blend SrcAlpha OneMinusSrcAlpha  // Transparency blending

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Shader properties (uniforms)
            uniform float _TimeSpeed;          // Speed of time-based animation
            uniform float _NoiseIntensity;     // Strength of the noise effect
            uniform float _DisplacementAmount; // Strength of the vertex displacement
            uniform float4 _BaseColor;         // Base color (orange)

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };

            // Perlin-like noise function for flickering effect
            float snoise(float3 v)
            {
                // Simple noise generation (you can replace with better noise if needed)
                float3 i = floor(v + (v.x + v.y + v.z) / 3.0);  // Create index for the noise grid
                float3 x0 = v - i + (i.x + i.y + i.z) / 3.0;  // Adjust position

                // Compute the noise output
                float3 g = step(x0.yzx, x0.xyz);  
                return dot(g, x0);  // Return noise value
            }

            // Vertex displacement function (to add some dynamic surface movement)
            float3 DisplaceVertex(float3 position, float time)
            {
                float noise = snoise(position * 5.0 + time * 0.5);  // Apply noise to displace
                return position + normalize(position) * noise * _DisplacementAmount;  // Displace along the normal
            }

            // Vertex shader: Apply displacement to the vertices
            v2f vert(appdata v)
            {
                v2f o;
                float time = _Time.y * _TimeSpeed;  // Time-based animation
                float3 displacedPosition = DisplaceVertex(v.vertex.xyz, time);  // Apply displacement

                o.pos = UnityObjectToClipPos(float4(displacedPosition, 1.0));  // Transform to clip space
                o.normal = v.normal;  // Pass the normal to the fragment shader
                return o;
            }

            // Fragment shader: Interpolate from orange to yellow based on noise
            half4 frag(v2f i) : SV_Target
            {
                // Apply Perlin-like noise to the fragment (flickering effect)
                float noise = snoise(i.pos.xyz * 10.0 + _Time.y * 0.2);  // Animated noise

                // Interpolate between orange and yellow
                float3 orange = float3(1.0, 0.5, 0.0);  // RGB color for orange
                float3 yellow = float3(1.0, 1.0, 0.0); // RGB color for yellow

                // Use noise to blend between orange and yellow
                float lerpFactor = 0.5 + 0.5 * noise;  // Map noise to a value between 0 and 1
                float3 finalColor = lerp(orange, yellow, lerpFactor);  // Interpolate color based on noise

                return half4(finalColor, 1.0);  // Return the final color
            }

            ENDCG
        }
    }

    // Fallback shader if not supported
    Fallback "Unlit/Color"
}
