void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    vec2 p = (fragCoord.xy * 2.0 - iResolution.xy) / min(iResolution.x, iResolution.y);
    
    vec3 destColor = vec3(0.0);
	float avg = (((length(iMusic[0].xz) + length(iMusic[1].xz) + length(iMusic[2].xz) + length(iMusic[3].xz)) / 4.) * 3.) * 0.01;
    for(float i = 0.0; i < 30.; i++){
        vec2 q = p + vec2(cos(iGlobalTime + i * 3.14 / 15.), sin(iGlobalTime + i * 3.14 / 15.)) * 0.7 * cos(iGlobalTime);
        destColor.x += (avg / length(q)) * length(iMusic[0].xz);
        destColor.y += (avg / length(q)) * length(iMusic[1].xz);
        destColor.z += (avg / length(q)) * length(iMusic[2].xz);
    }
    
    fragColor = vec4(destColor.r, destColor.g, destColor.b, 1.0);
}