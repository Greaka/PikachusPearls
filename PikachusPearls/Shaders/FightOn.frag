uniform sampler2D texture;

uniform float time;

void main(void)
{
	vec2 texCoord = gl_TexCoord[0].xy;

	float alpha = pow(sin(x*4)/2+0.5f, 3);

	gl_FragColor = texture2D(texture, texCoord).rgba - vec4(0,0,0,alpha+0.3f);
}