uniform sampler2D texture;

void main(void)
{
	vec2 texCoord = gl_TexCoord[0].xy;

	gl_FragColor = texture2D(texture, texCoord).rgba + vec4(0.5, 0.5, 0.5, 0);
}