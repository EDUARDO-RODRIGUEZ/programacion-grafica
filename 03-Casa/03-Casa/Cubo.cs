using OpenTK;
using System;
using System.Collections.Generic;

namespace _03_Casa
{
    public class Cubo : Objeto
    {
        private Face front, back, right, left, top, bottom;

        public Cubo(Punto origen, float ancho, float alto, float profundidad) : base(origen, ancho, alto, profundidad)
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
            this.top = new Face();
            this.bottom = new Face();
        }
        public override void loadFace()
        {
            front.setColor(new Vector3(1, 0, 0));
            front.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));
            front.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z + profundidad));
            front.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            front.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));

            back.setColor(new Vector3(1, 0, 0));
            back.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));
            back.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z - profundidad));
            back.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));
            back.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));

            right.setColor(new Vector3(0, 1, 0));
            right.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z - profundidad));
            right.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z + profundidad));
            right.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            right.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));

            left.setColor(new Vector3(0, 1, 0));
            left.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));
            left.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));
            left.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));
            left.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));

            top.setColor(new Vector3(0, 0, 1));
            top.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));
            top.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z - profundidad));
            top.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z + profundidad));
            top.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));

            bottom.setColor(new Vector3(0, 0, 1));
            bottom.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));
            bottom.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));
            bottom.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            bottom.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));

            base.faces.Add(front);
            base.faces.Add(back);
            base.faces.Add(right);
            base.faces.Add(left);
            base.faces.Add(top);
            base.faces.Add(bottom);

        }

        public void draw()
        {
            base.draw();
        }

       
    }
}
