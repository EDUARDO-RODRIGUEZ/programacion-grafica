using _03_Casa.element;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa
{
    class Scene
    {
        private List<Objeto> objetos;

        public Scene()
        {
            this.objetos = new List<Objeto>();
            loadObject();
        }

        public void loadObject() {
            Casa casa1 = new Casa(new Punto(), 10, 10, 10);
            casa1.setbodyColor(new Vector3(0.2f,0.2f,0.2f));
            casa1.setroofColor(new Vector3(0.8f,0.2f,0.2f));
            casa1.loadFace();

            /*
            Casa casa2 = new Casa(new Punto(0, 0, -40), 10, 10, 10);
            casa2.setbodyColor(new Vector3(0.7f, 0.5f, 02f));
            casa2.setroofColor(new Vector3(0.9f, 0.6f, 0.2f));
            casa2.loadFace();

            Auto auto1 = new Auto(new Punto(50, 0, 0), 5, 2, 3);
            auto1.loadFace();
            auto1.setbodyColor(new Vector3(0.1f,0.3f,0.1f));

            Auto auto2 = new Auto(new Punto(50, 0, -40), 5, 2, 3);
            auto2.setbodyColor(new Vector3(0.4f, 0.2f, 0.1f));
            auto2.loadFace();

            this.objetos.Add(casa1);
            this.objetos.Add(casa2);
            this.objetos.Add(auto1);
            this.objetos.Add(auto2);
            */

            this.objetos.Add(casa1);
        }

        public void draw()
        {
            foreach (var obj in objetos)
            {
                obj.draw();
            }
        }

    }
}
