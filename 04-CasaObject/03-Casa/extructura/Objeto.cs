using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CasaObject
{
    public class Objeto
    {
        private Dictionary<int, Face> faces;
        public float ancho;
        public float alto;
        public float profundidad;
        public Punto origen;
        private string id;

        public Objeto(Punto origen, float ancho, float alto, float profundidad)
        {
            this.faces = new Dictionary<int, Face>();
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.id = Guid.NewGuid().ToString();
        }

        public void setFace(Face face)
        {
            faces.Add(face.getId(), face);
        }

        public void setFaces(Dictionary<int, Face> faces)
        {
            Random r = new Random();
            foreach (KeyValuePair<int, Face> element in faces)
            {
                Face f = new Face();
                f.setId(element.Key);
                f.setColor(new Vector3((float)r.NextDouble(), (float)r.NextDouble(), (float)r.NextDouble()));
                foreach (var vertice in element.Value.vertices)
                {
                    f.setVertice(new Vector3(origen.x + vertice.X * ancho, origen.y + vertice.Y * alto, origen.z + vertice.Z * profundidad));
                }
                setFace(f);
            }
        }


        public string getId()
        {
            return this.id;
        }


        public void draw()
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.draw();
            }
        }
    }
}
