using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa.element
{
    class Auto : Objeto
    {
        private Face bodyfront, bodyback, bodyright, bodyleft, bodytop, bodybottom;
        private Face rooffront, roofback, roofright, roofleft, rooftop;
        private Face tirefrontright, tirefrontleft, tirebackright, tirebackleft;
        private Vector3 bodycolor;

        public Auto(Punto origen, float ancho, float alto, float profundidad) : base(origen, ancho, alto, profundidad)
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
            this.rooftop = new Face();

            this.tirefrontright = new Face();
            this.tirefrontleft = new Face();
            this.tirebackright = new Face();
            this.tirebackleft = new Face();
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

            rooffront.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z + profundidad));
            rooffront.setVertice(new Vector3(origen.x - (ancho / 2), origen.y + alto * 2, origen.z + profundidad));
            rooffront.setVertice(new Vector3(origen.x - (ancho / 2), origen.y + alto * 2, origen.z - profundidad));
            rooffront.setVertice(new Vector3(origen.x - ancho, origen.y + alto, origen.z - profundidad));



            tirefrontright.setColor(new Vector3(0, 0, 0));
            Punto fr = new Punto(origen.x + (ancho / 2), origen.y - alto, origen.z + profundidad + 1);
            for (int i = 0; i <= 360; i++)
            {
                float angle = (float)(i * 3.14 / 180);
                float x = (float)(alto / 2 * Math.Cos(angle));
                float y = (float)(alto / 2 * Math.Sin(angle));
                tirefrontright.setVertice(new Vector3(x + fr.x, y + fr.y, fr.z));
            }

            tirefrontleft.setColor(new Vector3(0, 0, 0));
            Punto fl = new Punto(origen.x + (ancho / 2), origen.y - alto, origen.z - profundidad - 1);
            for (int i = 0; i <= 360; i++)
            {
                float angle = (float)(i * 3.14 / 180);
                float x = (float)(alto / 2 * Math.Cos(angle));
                float y = (float)(alto / 2 * Math.Sin(angle));
                tirefrontleft.setVertice(new Vector3(x + fl.x, y + fl.y, fl.z));
            }


            tirebackright.setColor(new Vector3(0, 0, 0));
            Punto br = new Punto(origen.x - (ancho / 2), origen.y - alto, origen.z + profundidad + 1);
            for (int i = 0; i <= 360; i++)
            {
                float angle = (float)(i * 3.14 / 180);
                float x = (float)(alto / 2 * Math.Cos(angle));
                float y = (float)(alto / 2 * Math.Sin(angle));
                tirebackright.setVertice(new Vector3(x + br.x, y + br.y, br.z));
            }

            tirebackleft.setColor(new Vector3(0, 0, 0));
            Punto bl = new Punto(origen.x - (ancho / 2), origen.y - alto, origen.z - profundidad - 1);
            for (int i = 0; i <= 360; i++)
            {
                float angle = (float)(i * 3.14 / 180);
                float x = (float)(alto / 2 * Math.Cos(angle));
                float y = (float)(alto / 2 * Math.Sin(angle));
                tirebackleft.setVertice(new Vector3(x + bl.x, y + bl.y, bl.z));
            }

            base.faces.Add(bodyfront);
            base.faces.Add(bodyback);
            base.faces.Add(bodyright);
            base.faces.Add(bodyleft);
            base.faces.Add(bodytop);
            base.faces.Add(bodybottom);

            base.faces.Add(rooffront);

            base.faces.Add(tirefrontright);
            base.faces.Add(tirefrontleft);
            base.faces.Add(tirebackright);
            base.faces.Add(tirebackleft);
        }

        public void setbodyColor(Vector3 color)
        {
            this.bodycolor = color;
        }

        public void draw()
        {
            base.draw();
        }

    }
}
