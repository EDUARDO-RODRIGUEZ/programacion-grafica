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

namespace _07_CasaObject
{
    public class Objeto : ITransform
    {
        private Dictionary<int, Face> faces;

        private Punto origen;
        private Scene scene;

        private string id;
        private string path;

        public Objeto(Punto origen, String path, String name, Scene scene)
        {
            this.faces = new Dictionary<int, Face>();
            this.id = name;
            this.path = path;
            this.origen = origen;
            this.scene = scene;
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
                Face face = new Face(new Punto(f.origen.x, f.origen.y, f.origen.z), this);
                face.setId(faces.Count);
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

        public Face getFace(int index)
        {
            return faces[index];
        }

        public Scene getScene()
        {
            return this.scene;
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

                SchemaVertice schemaOrigen = new SchemaVertice();
                schemaOrigen.x = f.getOrigen().x;
                schemaOrigen.y = f.getOrigen().y;
                schemaOrigen.z = f.getOrigen().z;
                schemeFace.origen = schemaOrigen;
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

        public void setRespectToObjeto()
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.setRespectToObjeto();
            }
        }


        public void setRespectToScene()
        {
            foreach (KeyValuePair<int, Face> element in faces)
            {
                element.Value.setRespectToScene();
            }
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
