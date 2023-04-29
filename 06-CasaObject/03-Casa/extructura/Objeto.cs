using _03_Casa.extra;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CasaObject
{
    public class Objeto : ITransform
    {
        private Dictionary<int, Face> faces;
        public Punto origen;
        private string id;
        private string path;

        public Objeto(Punto origen, String path)
        {
            this.faces = new Dictionary<int, Face>();
            this.id = Guid.NewGuid().ToString();
            this.path = path;
            this.origen = origen;
        }

        public void setOrigenRespectToScene(Scene scene)
        {
            this.origen.x = this.origen.x + scene.getOrigen().x;
            this.origen.y = this.origen.y + scene.getOrigen().y;
            this.origen.z = this.origen.z + scene.getOrigen().z;
        }

        public void setFace(Face face)
        {
            faces.Add(face.getId(), face);
        }

        public void loadJson()
        {
            Random r = new Random();
            string jsonfile = File.ReadAllText(this.path);
            SchemeObject obj = JsonConvert.DeserializeObject<SchemeObject>(jsonfile);
            foreach (var f in obj.faces)
            {
                Face face = new Face(new Punto(f.origen.x, f.origen.y, f.origen.z));
                face.setId(faces.Count);
                face.setOrigenRespectToObject(this);
                face.setColor(new Vector3((float)r.NextDouble(), (float)r.NextDouble(), (float)r.NextDouble()));
                foreach (var v in f.vertices)
                {
                    face.setVertice(new Vector3(v.x, v.y, v.z));
                }
                setFace(face);
            }
        }

        public string getId()
        {
            return this.id;
        }

        public Punto getOrigen()
        {
            return this.origen;
        }

        public void save(String path)
        {

            SchemeObject scheme = new SchemeObject();
            scheme.faces = new List<SchemeFace>();
            foreach (var element in this.faces)
            {
                Face f = element.Value;
                SchemeFace schemeFace = new SchemeFace();
                schemeFace.vertices = new List<SchemaVertice>();

                SchemaVertice origen = new SchemaVertice();
                origen.x = f.getOrigen().x;
                origen.y = f.getOrigen().y;
                origen.z = f.getOrigen().z;
                schemeFace.origen = origen;
                foreach (var vertice in f.vertices)
                {
                    SchemaVertice sv = new SchemaVertice();
                    sv.x = vertice.X;
                    sv.y = vertice.Y;
                    sv.z = vertice.Z;
                    schemeFace.vertices.Add(sv);
                }
                scheme.faces.Add(schemeFace);
            }
            string jsonOutput = JsonConvert.SerializeObject(scheme);
            File.WriteAllText(path, jsonOutput);
        }

        public void draw()
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.draw();
            }
        }

        public void rotate(Vector3 rotate)
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.rotate(rotate);
            }
        }

        public void translate(Vector3 translate)
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.translate(translate);
            }
        }

        public void scale(Vector3 scale)
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.scale(scale);
            }
        }
    }
}
