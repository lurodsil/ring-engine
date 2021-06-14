float3 VertexBlend(float4 vertexColor, float3 red, float3 green, float3 blue)
{
	return lerp(lerp(lerp(red, green, vertexColor.b), blue, vertexColor.r), red, vertexColor.g);
}

float4 VertexBlend(float4 vertexColor, float4 red, float4 green, float4 blue)
{
	return lerp(lerp(lerp(red, green, vertexColor.b), blue, vertexColor.r), red, vertexColor.g);
}

float3 VertexBlend(float4 vertexColor, float3 red, float3 green, float3 blue, float3 vertexColorMask)
{
	float3 paintedRed = lerp(red, red * vertexColor.rgb, vertexColorMask.r);
	float3 paintedGreen = lerp(green, green * vertexColor.rgb, vertexColorMask.g);
	float3 paintedBlue = lerp(blue, blue * vertexColor.rgb, vertexColorMask.b);

	return lerp(lerp(lerp(paintedRed, paintedGreen, vertexColor.b), paintedBlue, vertexColor.r), paintedRed, vertexColor.g);
}

float4 VertexBlend(float4 vertexColor, float4 red, float4 green, float4 blue, float3 vertexColorMask)
{
	float4 paintedRed = lerp(red, red * vertexColor, vertexColorMask.r);
	float4 paintedGreen = lerp(green, green * vertexColor, vertexColorMask.g);
	float4 paintedBlue = lerp(blue, blue * vertexColor, vertexColorMask.b);

	return lerp(lerp(lerp(paintedRed, paintedGreen, vertexColor.b), paintedBlue, vertexColor.r), paintedRed, vertexColor.g);
}

float2 SphereMap(float3 viewDir, float3 normal)
{
	float3 r = reflect(-viewDir, normal);
	r = mul((float3x3)UNITY_MATRIX_MV, r);
	r.z += 1;
	float m = 2 * length(r);
	return r.xy / m + 0.5;
}

float Pulse(float interval)
{
	return 1.0 - clamp(abs(sin(_Time.g * interval)), 0.0, 1.0);
}

float Falloff(float3 viewDir, float3 normal, float thereshold)
{
	return pow(1.0 - saturate(dot(normalize(viewDir), normal)), thereshold);
}