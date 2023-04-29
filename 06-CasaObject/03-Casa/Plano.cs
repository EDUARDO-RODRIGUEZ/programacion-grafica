using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CasaObject
{
    class Plano
    {
        private float ancho;
        private float alto;
        private float profundidad;
        private Punto origen;

        public Plano(Punto origen, float ancho, float alto, float profundidad)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.origen = origen;
        }

        public void draw()
        {
            PrimitiveType primitiveType = PrimitiveType.Lines;
            GL.Color3(new Vector3(0.3f, 0.3f, 0.3f));
            ejeX(primitiveType);
            ejeY(primitiveType);
            ejeZ(primitiveType);
        }

        public void ejeX(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Vertex3(origen.x + ancho, origen.y, origen.z);
            GL.Vertex3(origen.x - ancho, origen.y, origen.z);
            GL.End();
        }

        public void ejeY(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Vertex3(origen.x, origen.y + alto, origen.z);
            GL.Vertex3(origen.x, origen.y - alto, origen.z);
            GL.End();
        }

        public void ejeZ(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Vertex3(origen.x, origen.y, origen.z + profundidad);
            GL.Vertex3(origen.x, origen.y, origen.z - profundidad);
            GL.End();

        }
    }
}
