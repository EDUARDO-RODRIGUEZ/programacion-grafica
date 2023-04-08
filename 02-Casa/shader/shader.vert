#version 330 core
layout(location = 0) in vec3 vertice;
layout(location = 1) in vec3 color;

out vec3 passColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    gl_Position = model * view * projection * vec4(vertice.x,vertice.y,vertice.z, 1.0);
    passColor = vec3(color);
}