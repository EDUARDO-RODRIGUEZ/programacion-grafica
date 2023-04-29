using _03_Casa.extra;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace _06_CasaObject
{
    public class Face : ITransform
    {
        private int id;
        public List<Vector3> vertices;
        private Vector3 color;
        private Matrix3 mrotate, mscale;
        private Vector3 vtranslate;
        private Punto origen;

        public Face(Punto origen)
        {
            this.vertices = new List<Vector3>();
            this.color = new Vector3(1, 1, 1);
            this.mrotate = Matrix3.Identity;
            this.mscale = Matrix3.Identity;
            this.vtranslate = new Vector3(0, 0, 0);
            this.origen = origen;
        }

        public void setOrigenRespectToObject(Objeto obj)
        {
            this.origen.x = this.origen.x + obj.getOrigen().x;
            this.origen.y = this.origen.y + obj.getOrigen().y;
            this.origen.z = this.origen.z + obj.getOrigen().z;
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
            GL.Begin(PrimitiveType.Polygon);
            foreach (var vertice in vertices)
            {
                Vector3 transformVertice = vertice * mscale * mrotate;
                transformVertice = transformVertice + vtranslate;

                transformVertice.X = transformVertice.X + origen.x;
                transformVertice.Y = transformVertice.Y + origen.y;
                transformVertice.Z = transformVertice.Z + origen.z;

                GL.Vertex3(transformVertice);
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

        public Punto getOrigen()
        {
            return this.origen;
        }

        public void rotate(Vector3 rotate)
        {
            float anglex = MathHelper.DegreesToRadians(rotate.X);
            float angley = MathHelper.DegreesToRadians(rotate.Y);
            float anglez = MathHelper.DegreesToRadians(rotate.Z);
            mrotate = Matrix3.CreateRotationX(anglex) * Matrix3.CreateRotationY(angley) * Matrix3.CreateRotationZ(anglez);
        }

        public void translate(Vector3 translate)
        {
            this.vtranslate = translate;
        }

        public void scale(Vector3 scale)
        {
            mscale = Matrix3.CreateScale(scale.X, scale.Y, scale.Z);
        }

    }
}
