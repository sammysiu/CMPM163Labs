// code for fragment shader 2
uniform sampler2D texture2;
varying vec2 vUv;
void main() {
    vec2 green = vec2(1.0/3.0, 1.0/3.0);
    vec2 red = mod(vUv, green);
    gl_FragColor = texture2D(texture2, red);
}