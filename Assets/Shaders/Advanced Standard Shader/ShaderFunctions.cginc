float3 VertexBlend(float4 vertexColor, float3 red, float3 green, float3 blue)
{
    return lerp(lerp(lerp(green, blue, vertexColor.b), red, vertexColor.r), green, vertexColor.g);
}

float4 VertexBlend(float4 vertexColor, float4 red, float4 green, float4 blue)
{
    return lerp(lerp(lerp(green, blue, vertexColor.b), red, vertexColor.r), green, vertexColor.g);
}

float2 SphereMap(float3 viewDir, float3 normal)
{
	float3 r = reflect(-viewDir, normal);
	r = mul((float3x3)UNITY_MATRIX_MV, r);
	r.z += 1;
	float m = 2 * length(r);
	return r.xy / m + 0.5;
}

float Pulse(float speed)
{
	return 1 - clamp(abs(sin(_Time.g * speed)), 0, 1);
}

float Falloff(float3 viewDir, float3 normal, float thereshold)
{
	return pow(1.0 - saturate(dot(normalize(viewDir), normal)), thereshold);
}
 