using _08_Animacion.extra;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace _08_Animacion.extructura
{
    public class Face : ITransform
    {
        private string id;
        public List<Vector3> vertices;
        private Vector3 color;
        private Matrix4 mrotate, mscale;
        private Vector3 vtranslate;


        private Punto origenFace;
        private Punto origenObjeto;
        private Punto origenScene;
        private bool sumaFace = true;
        private string select = "face";


        public Face(Punto origen, Objeto objeto)
        {
            this.vertices = new List<Vector3>();
            this.color = new Vector3(1, 1, 1);
            this.mrotate = Matrix4.Identity;
            this.mscale = Matrix4.Identity;
            this.vtranslate = new Vector3(0, 0, 0);
            this.origenFace = origen;
            this.origenObjeto = objeto.getOrigen();
            this.origenScene = objeto.getScene().getOrigen();
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
            GL.Begin(PrimitiveType.LineLoop);
            foreach (var vertice in vertices)
            {
                Vector4 vertice4 = new Vector4(vertice, 1);
                if (select.Equals("objeto"))
                {
                    vertice4.X = vertice4.X + origenFace.x;
                    vertice4.Y = vertice4.Y + origenFace.y;
                    vertice4.Z = vertice4.Z + origenFace.z;
                }
                else if (select.Equals("scene"))
                {
                    vertice4.X = vertice4.X + origenFace.x + origenObjeto.x;
                    vertice4.Y = vertice4.Y + origenFace.y + origenObjeto.y;
                    vertice4.Z = vertice4.Z + origenFace.z + origenObjeto.z;
                }

                vertice4 = vertice4 * mscale * mrotate;

                if (sumaFace)
                {
                    vertice4.X += origenFace.x;
                    vertice4.Y += origenFace.y;
                    vertice4.Z += origenFace.z;
                }

                vertice4 += new Vector4(vtranslate, 0);

                GL.Vertex4(vertice4);
            }
            GL.End();
            GL.Flush();
        }


        public string getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public Punto getOrigen()
        {
            return this.origenFace;
        }

        public void rotateRespectScene(Vector3 rotate)
        {
            float anglex = MathHelper.DegreesToRadians(rotate.X);
            float angley = MathHelper.DegreesToRadians(rotate.Y);
            float anglez = MathHelper.DegreesToRadians(rotate.Z);

            mrotate = Matrix4.CreateRotationX(anglex) * Matrix4.CreateRotationY(angley) * Matrix4.CreateRotationZ(anglez);
            select = "scene";
            sumaFace = false;
        }

        public void rotateRespectObject(Vector3 rotate)
        {
            float anglex = MathHelper.DegreesToRadians(rotate.X);
            float angley = MathHelper.DegreesToRadians(rotate.Y);
            float anglez = MathHelper.DegreesToRadians(rotate.Z);

            mrotate = Matrix4.CreateRotationX(anglex) * Matrix4.CreateRotationY(angley) * Matrix4.CreateRotationZ(anglez);
            select = "objeto";
            sumaFace = false;
        }

        public void rotate(Vector3 rotate)
        {
            float anglex = MathHelper.DegreesToRadians(rotate.X);
            float angley = MathHelper.DegreesToRadians(rotate.Y);
            float anglez = MathHelper.DegreesToRadians(rotate.Z);
            mrotate = Matrix4.CreateRotationX(anglex) * Matrix4.CreateRotationY(angley) * Matrix4.CreateRotationZ(anglez);
            
            select = "face";
            sumaFace = true;
        }


        public void translate(Vector3 translate)
        {
            this.vtranslate = translate;
        }

        public void scale(Vector3 scale)
        {
            mscale = Matrix4.CreateScale(scale.X, scale.Y, scale.Z);
        }


    }
}
