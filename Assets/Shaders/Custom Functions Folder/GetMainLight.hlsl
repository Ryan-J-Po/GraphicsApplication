float4 _WorldSpaceLightPos0;
float4 _LightColor0;

void GetMainLight_float(out float4 color, out float4 direction)
{
    color = _LightColor0;
    direction = _WorldSpaceLightPos0;
}