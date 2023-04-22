using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace _04_CasaObject
{
    public class Face
    {
        private int id;
        public List<Vector3> vertices;
        private Vector3 color;

        public Face()
        {
            vertices = new List<Vector3>();
            color = new Vector3(1, 1, 1);
        }

        public Face(List<Vector3> vertices)
        {
            this.vertices = vertices;
            color = new Vector3(1, 1, 1);
        }


        public void setColor(Vector3 color)
        {
            this.color = color;
        }

        public void setVertice(Vector3 vertice)
        {
            this.vertices.Add(vertice);
        }

        public void draw()
        {
            GL.Color3(color);
            GL.Begin(PrimitiveType.Polygon);
            foreach (var vertice in vertices)
            {
                GL.Vertex3(vertice);
            }
            GL.End();
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }
}
