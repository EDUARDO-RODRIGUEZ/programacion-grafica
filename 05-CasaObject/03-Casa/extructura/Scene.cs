using OpenTK;
using System;
using System.Collections.Generic;

namespace _04_CasaObject
{
    class Scene
    {
        private Dictionary<string, Objeto> objetos;

        public Scene()
        {
            this.objetos = new Dictionary<string, Objeto>();
        }

        public void addObject(Objeto obj)
        {
            this.objetos.Add(obj.getId(), obj);
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

    }
}
