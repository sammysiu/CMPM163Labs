uniform vec3 colorC;
uniform vec3 colorD;
varying vec3 vUv;

void main() {
    // gl_FragColor = vec4(0.0, 0.0, 1.0, 1.0); //rgba, return blue
    gl_FragColor = vec4(mix(colorC, colorD, vUv.y), 1.0); // interpolate between c and d
}