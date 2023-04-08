#version 330
out vec4 colorpixel;
in vec3 passColor;
void main()
{
    colorpixel = vec4(passColor, 1.0);
}