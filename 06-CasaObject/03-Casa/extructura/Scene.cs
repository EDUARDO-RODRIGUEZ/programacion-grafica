using _03_Casa.extra;
using OpenTK;
using System;
using System.Collections.Generic;

namespace _06_CasaObject
{
    public class Scene : ITransform
    {
        private Punto origen;
        private Dictionary<string, Objeto> objetos;

        public Scene(Punto origen)
        {
            this.objetos = new Dictionary<string, Objeto>();
            this.origen = origen;
        }

        public void addObject(Objeto obj)
        {
            this.objetos.Add(obj.getId(), obj);

        }

        public Punto getOrigen()
        {
            return this.origen;
        }

        public void removeObject(Objeto obj)
        {
            this.objetos.Remove(obj.getId());
        }

        public void draw()

        {
            foreach (KeyValuePair<string, Objeto> element in objetos)
            {
                element.Value.draw();
            }
        }

        public void rotate(Vector3 rotate)
        {
            foreach (KeyValuePair<string, Objeto> element in objetos)
            {
                element.Value.rotate(rotate);
            }
        }

        public void translate(Vector3 translate)
        {

        }

        public void scale(Vector3 scale)
        {
            foreach (KeyValuePair<string, Objeto> element in objetos)
            {
                element.Value.scale(scale);
            }
        }
    }
}
