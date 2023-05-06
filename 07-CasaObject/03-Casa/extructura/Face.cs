using _03_Casa.extra;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace _07_CasaObject
{
    public class Face : ITransform
    {
        private int id;
        public List<Vector3> vertices;
        private Vector3 color;
        private Matrix4 mrotate, mscale;
        private Vector3 vtranslate;


        private Punto origenFace;
        private Punto origenObjeto;
        private Punto origenScene;

        private Punto origen;
        private Vector4 origenTransform;
        private String respect;

        public Face(Punto origen, Objeto objeto)
        {
            this.vertices = new List<Vector3>();
            this.color = new Vector3(1, 1, 1);
            this.mrotate = Matrix4.Identity;
            this.mscale = Matrix4.Identity;
            this.vtranslate = new Vector3(0, 0, 0);

            this.origenFace = new Punto(origen.x, origen.y, origen.z);
            this.origenObjeto = objeto.getOrigen();
            this.origenScene = objeto.getScene().getOrigen();

            this.origen = new Punto();
            this.origenTransform = new Vector4(0, 0, 0, 0);

            setRespectFace();
        }


        public void setRespectFace()
        {

            this.origenTransform.X = 0;
            this.origenTransform.Y = 0;
            this.origenTransform.Z = 0;
            this.origenTransform.W = 0;

            this.origen.x = origenScene.x + origenObjeto.x + origenFace.x;
            this.origen.y = origenScene.y + origenObjeto.y + origenFace.y;
            this.origen.z = origenScene.z + origenObjeto.z + origenFace.z;

            this.respect = "face";

        }

        //Cambiar el Origen del Face

        public void setRespectToObjeto()
        {
            this.origenTransform.X = origenFace.x;
            this.origenTransform.Y = origenFace.y;
            this.origenTransform.Z = origenFace.z;
            this.origenTransform.W = 0;

            this.origen.x = origenScene.x + origenObjeto.x;
            this.origen.y = origenScene.y + origenObjeto.y;
            this.origen.z = origenScene.y + origenObjeto.y;

            this.respect = "objeto";
        }

        //Cambiar el Origen del Objeto y Face
        public void setRespectToScene()
        {
            this.origenTransform.X = origenFace.x + origenObjeto.x;
            this.origenTransform.Y = origenFace.y + origenObjeto.y;
            this.origenTransform.Z = origenFace.z + origenObjeto.z;
            this.origenTransform.W = 0;

            this.origen.x = origenScene.x;
            this.origen.y = origenScene.y;
            this.origen.z = origenScene.z;

            this.respect = "scene";
        }


        public void setVertice(Vector3 vertice)
        {
            this.vertices.Add(vertice);
        }

        public void setColor(Vector3 color)
        {
            this.color = color;
        }

        public void drawCenterFace()
        {
            GL.Color3(new Vector3(1, 1, 1));
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(new Vector3(this.origenFace.x + this.origenObjeto.x + this.origenScene.x,
                                   this.origenFace.y + this.origenObjeto.y + this.origenScene.y,
                                   this.origenFace.z + this.origenObjeto.z + this.origenScene.z
                                   ));
            GL.End();
            GL.Color3(color);
        }

        public void draw()
        {
            drawCenterFace();
            
            GL.Begin(PrimitiveType.LineLoop);
            foreach (var vertice in vertices)
            {
                Vector4 transformVertice = (new Vector4(vertice.X, vertice.Y, vertice.Z, 1) + origenTransform) * mscale * mrotate;
                
                transformVertice.X = transformVertice.X + origen.x;
                transformVertice.Y = transformVertice.Y + origen.y;
                transformVertice.Z = transformVertice.Z + origen.z;

                transformVertice += new Vector4(vtranslate, 0);

                GL.Vertex4(transformVertice);
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


            mrotate = Matrix4.CreateRotationX(anglex) * Matrix4.CreateRotationY(angley) * Matrix4.CreateRotationZ(anglez);
            Vector4 tface;
            Vector4 tobjeto;

            switch (this.respect)
            {
                case "objeto":
                    tface = new Vector4(origenFace.x, origenFace.y, origenFace.z, 1) * mrotate;
                    origenFace.x = tface.X;
                    origenFace.y = tface.Y;
                    origenFace.z = tface.Z;
                    break;

                case "scene":
                    tface = new Vector4(origenFace.x, origenFace.y, origenFace.z, 1) * mrotate;
                    tobjeto = new Vector4(origenObjeto.x, origenObjeto.y, origenObjeto.z, 1) * mrotate;
                    origenObjeto.x = tobjeto.X;
                    origenObjeto.y = tobjeto.Y;
                    origenObjeto.z = tobjeto.Z;

                    origenFace.x = tface.X;
                    origenFace.y = tface.Y;
                    origenFace.z = tface.Z;
                    break;
                default:
                    break;

            }

        }

        public void translate(Vector3 translate)
        {
            this.vtranslate = translate;
            //origenObjeto.x = origenObjeto.x + translate.X;
            //origenObjeto.y = origenObjeto.y + translate.Y;
            //origenObjeto.z = origenObjeto.z + translate.Z;
        }

        public void scale(Vector3 scale)
        {

            this.origenFace.x = this.origenFace.x * scale.X;
            this.origenFace.y = this.origenFace.y * scale.Y;
            this.origenFace.z = this.origenFace.z * scale.Z;

            mscale = Matrix4.CreateScale(scale.X, scale.Y, scale.Z);
        }

    }
}
