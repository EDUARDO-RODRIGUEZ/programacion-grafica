using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa
{
    public abstract class Objeto
    {
        protected List<Face> faces;
        protected float ancho;
        protected float alto;
        protected float profundidad;
        protected Punto origen;

        public Objeto(Punto origen, float ancho, float alto, float profundidad)
        {
            this.faces = new List<Face>();
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
        }

        public abstract void createFace();
        
        public abstract void loadFace();

        public void setFace(Face face)
        {
            faces.Add(face);
        }


        public void draw()
        {
            foreach (var face in faces)
            {
                GL.Begin(PrimitiveType.Polygon);
                face.draw();
                GL.End();
            }
        }
    }
}
