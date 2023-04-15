using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;


namespace _03_Casa
{
    public class Face
    {
        private List<Vector3> vertices;
        private Vector3 color;

        public Face()
        {
            vertices = new List<Vector3>();
            color = new Vector3(1, 1, 1);
        }

        public void setVertice(Vector3 vertice)
        {
            this.vertices.Add(vertice);
        }

        public void setColor(Vector3 color)
        {
            this.color = color;
        }

        public void draw()
        {
            GL.Color3(color);
            foreach (var vertice in vertices)
            {
                GL.Vertex3(vertice);
            }
        }
    }
}
