using _08_Animacion.extra;
using OpenTK;
using System;
using System.Collections.Generic;

namespace _08_Animacion.extructura
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
                element.Value.rotateRespectScene(rotate);
            }
        }

        public void translate(Vector3 translate)
        {
            foreach (KeyValuePair<string, Objeto> element in objetos)
            {
                element.Value.translate(translate);
            }
        }

        public void scale(Vector3 scale)
        {
            foreach (KeyValuePair<string, Objeto> element in objetos)
            {
                element.Value.scale(scale);
            }
        }

        public Dictionary<string, Objeto> getObjects() {
            return objetos;
        }

        public Objeto getObject(string key)
        {
            return objetos[key];
        }

    }
}
