using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa
{
    class Triangulo : Objeto
    {
        private Face front, back, right, left;

        public Triangulo(Punto origen, float ancho, float alto, float profundidad) : base(origen, ancho, alto, profundidad)
        {
            createFace();
            loadFace();
        }

        public override void createFace()
        {
            this.front = new Face();
            this.back = new Face();
            this.right = new Face();
            this.left = new Face();
        }

        public override void loadFace()
        {
            front.setVertice(new Vector3(origen.x, origen.y + alto, origen.z + profundidad));
            front.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));
            front.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));

            back.setVertice(new Vector3(origen.x, origen.y + alto, origen.z - profundidad));
            back.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));
            back.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));

            right.setVertice(new Vector3(origen.x, origen.y + alto, origen.z + profundidad));
            right.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            right.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));
            right.setVertice(new Vector3(origen.x, origen.y + alto, origen.z - profundidad));

            left.setVertice(new Vector3(origen.x, origen.y + alto, origen.z + profundidad));
            left.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));
            left.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));
            left.setVertice(new Vector3(origen.x, origen.y + alto, origen.z - profundidad));

            base.setFace(front);
            base.setFace(back);
            base.setFace(right);
            base.setFace(left);
        }

        public void draw()
        {
            base.draw();
        }
    }
}
