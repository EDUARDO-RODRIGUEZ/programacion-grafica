using OpenTK.Mathematics;

namespace _02_Casa.Graphic
{
    public class Vertex
    {
        private Vector3 position;
        private Vector3 color;

        public Vertex(Vector3 position, Vector3 color)
        {
            this.position = position;
            this.color = color;
        }


        public Vector3 getPosition()
        {
            return this.position;
        }

        public void setPosition(Vector3 position)
        {
            this.position = position;
        }

        public Vector3 getColor()
        {
            return this.color;
        }

        public void setColor(Vector3 color)
        {
            this.color = color;
        }
    }
}