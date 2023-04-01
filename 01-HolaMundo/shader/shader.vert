#version 330 core
layout(location = 0) in vec3 vertice;
void main(void)
{
    gl_Position = vec4(vertice, 1.0);
}