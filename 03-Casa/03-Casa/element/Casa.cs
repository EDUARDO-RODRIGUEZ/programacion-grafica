using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa.element
{
    class Casa : Objeto
    {
        private Face bodyfront, bodyback, bodyright, bodyleft, bodytop, bodybottom;
        private Face rooffront, roofback, roofright, roofleft;
        private Face door;
        private Vector3 bodycolor, roofcolor;


        public Casa(Punto origen, float ancho, float alto, float profundidad) : base(origen, ancho, alto, profundidad)
        {
            createFace();
        }

        public override void createFace()
        {
            this.bodyfront = new Face();
            this.bodyback = new Face();
            this.bodyright = new Face();
            this.bodyleft = new Face();
            this.bodytop = new Face();
            this.bodybottom = new Face();

            this.rooffront = new Face();
            this.roofback = new Face();
            this.roofright = new Face();
            this.roofleft = new Face();

            this.door = new Face();
        }

        public override void loadFace()
        {
            bodyfront.setColor(bodycolor);
            bodyfront.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));
            bodyfront.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z + profundidad));
            bodyfront.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            bodyfront.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));

            bodyback.setColor(bodycolor);
            bodyback.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));
            bodyback.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z - profundidad));
            bodyback.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));
            bodyback.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));

            bodyright.setColor(bodycolor);
            bodyright.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z - profundidad));
            bodyright.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z + profundidad));
            bodyright.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            bodyright.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));

            bodyleft.setColor(bodycolor);
            bodyleft.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));
            bodyleft.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));
            bodyleft.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));
            bodyleft.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));

            bodytop.setColor(bodycolor);
            bodytop.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));
            bodytop.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z - profundidad));
            bodytop.setVertice(new Vector3(origen.x + ancho, origen.y + alto, origen.z + profundidad));
            bodytop.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));

            bodybottom.setColor(bodycolor);
            bodybottom.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z - profundidad));
            bodybottom.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z - profundidad));
            bodybottom.setVertice(new Vector3(origen.x + ancho, origen.y - alto, origen.z + profundidad));
            bodybottom.setVertice(new Vector3(origen.x - ancho, origen.y - alto, origen.z + profundidad));



            rooffront.setColor(roofcolor);
            rooffront.setVertice(new Vector3(origen.x, origen.y + alto + (alto * 2), origen.z + profundidad));
            rooffront.setVertice(new Vector3(origen.x - ancho, origen.y - alto + (alto * 2), origen.z + profundidad));
            rooffront.setVertice(new Vector3(origen.x + ancho, origen.y - alto + (alto * 2), origen.z + profundidad));

            roofback.setColor(roofcolor);
            roofback.setVertice(new Vector3(origen.x, origen.y + alto + (alto * 2), origen.z - profundidad));
            roofback.setVertice(new Vector3(origen.x - ancho, origen.y - alto + (alto * 2), origen.z - profundidad));
            roofback.setVertice(new Vector3(origen.x + ancho, origen.y - alto + (alto * 2), origen.z - profundidad));

            roofright.setColor(roofcolor);
            roofright.setVertice(new Vector3(origen.x, origen.y + alto + (alto * 2), origen.z + profundidad));
            roofright.setVertice(new Vector3(origen.x + ancho, origen.y - alto + (alto * 2), origen.z + profundidad));
            roofright.setVertice(new Vector3(origen.x + ancho, origen.y - alto + (alto * 2), origen.z - profundidad));
            roofright.setVertice(new Vector3(origen.x, origen.y + alto + (alto * 2), origen.z - profundidad));

            roofleft.setColor(roofcolor);
            roofleft.setVertice(new Vector3(origen.x, origen.y + alto + (alto * 2), origen.z + profundidad));
            roofleft.setVertice(new Vector3(origen.x - ancho, origen.y - alto + (alto * 2), origen.z + profundidad));
            roofleft.setVertice(new Vector3(origen.x - ancho, origen.y - alto + (alto * 2), origen.z - profundidad));
            roofleft.setVertice(new Vector3(origen.x, origen.y + alto + (alto * 2), origen.z - profundidad));

            door.setColor(roofcolor);
            door.setVertice(new Vector3(origen.x - (ancho / 4), origen.y - (alto), origen.z + (profundidad + 1)));
            door.setVertice(new Vector3(origen.x - (ancho / 4), origen.y + (alto / 2), origen.z + (profundidad + 1)));
            door.setVertice(new Vector3(origen.x + (ancho / 4), origen.y + (alto / 2), origen.z + (profundidad + 1)));
            door.setVertice(new Vector3(origen.x + (ancho / 4), origen.y - (alto), origen.z + (profundidad + 1)));


            base.faces.Add(bodyfront);
            base.faces.Add(bodyback);
            base.faces.Add(bodyright);
            base.faces.Add(bodyleft);
            base.faces.Add(bodytop);
            base.faces.Add(bodybottom);

            base.faces.Add(rooffront);
            base.faces.Add(roofback);
            base.faces.Add(roofright);
            base.faces.Add(roofleft);

            base.faces.Add(door);
        }

        public void setbodyColor(Vector3 color)
        {
            this.bodycolor = color;
        }

        public void setroofColor(Vector3 color)
        {
            this.roofcolor = color;
        }

        public void draw()
        {
            base.draw();
        }


    }
}
