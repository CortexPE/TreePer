void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
	vec2 uv = fragCoord.xy / iResolution.xy;
	
	// To create the BG pattern
	vec3 wave_color = vec3(0.0);
	
	vec4 vol = vec4(iMusic[0].z, iMusic[1].z, iMusic[2].z, iMusic[3].z);
    vec4 note = vec4(iMusic[0].y, iMusic[1].x, iMusic[2].x, iMusic[3].x);
	// To create the waves
	float wave_width = 0.01;
	uv  = -1.0 + 2.0 * uv;
	uv.y += 0.1;
	for(float i = 0.0; i < 10.0; i++) {
		
		uv.y += (2. + 2. * min(iMusic[0].w,iMusic[1].w))  * min(vol.x,vol.y) * (0.07 * sin(uv.x + i/7.0 + iGlobalTime )) * (length(iMusic[0].xz) * 1.5);
		wave_width = abs((1.2 - dot(vec2(note.x,vol.x),vec2(note.y,vol.y))*iMusic[0].w) / (150.0 * uv.y)) * 0.5;
		wave_color += vec3(wave_width * length(iMusic[0].xz), wave_width * length(iMusic[1].xz), wave_width * length(iMusic[2].xz));
        vol.xyzw = vol.yzwx;
        note.xyzw = vol.yzwx;
	}
	
	
	fragColor = vec4(wave_color, 1.0);
}