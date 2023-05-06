using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CasaObject
{
    public class Punto
    {
        private float ejeX { get; set; }
        private float ejeY { get; set; }
        private float ejeZ { get; set; }

        public float x { get { return ejeX; } set { ejeX = value; } }
        public float y { get { return ejeY; } set { ejeY = value; } }
        public float z { get { return ejeZ; } set { ejeZ = value; } }

        public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }

        public Punto() : this(0, 0, 0) { }

        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }

        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }

    }
}
