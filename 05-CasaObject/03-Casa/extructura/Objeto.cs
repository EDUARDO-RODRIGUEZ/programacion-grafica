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
        private string path;

        public Objeto(Punto origen, float ancho, float alto, float profundidad, String path)
        {
            this.faces = new Dictionary<int, Face>();
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.id = Guid.NewGuid().ToString();
            this.path = path;
        }

        public void setFace(Face face)
        {
            faces.Add(face.getId(), face);
        }


        public void loadFace()
        {
            string line = "";
            Face face = new Face();
            face.setId(0);
            TextReader file = new StreamReader(this.path);
            Random r = new Random();
            line = file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("face"))
                {
                    setFace(face);
                    face = new Face();
                    face.setId(faces.Count);
                    face.setColor(new Vector3((float)r.NextDouble(), (float)r.NextDouble(), (float)r.NextDouble()));
                }
                else
                {
                    string[] vertice = line.Split(',');
                    float x = origen.x + float.Parse(vertice[0], CultureInfo.InvariantCulture) * ancho;
                    float y = origen.y + float.Parse(vertice[1], CultureInfo.InvariantCulture) * alto;
                    float z = origen.z + float.Parse(vertice[2], CultureInfo.InvariantCulture) * profundidad;
                    face.setVertice(new Vector3(x, y, z));
                }

            }
            setFace(face);
            file.Close();
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
