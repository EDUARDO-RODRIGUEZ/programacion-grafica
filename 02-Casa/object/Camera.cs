using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace _02_Casa.Object
{
    public class Camera
    {
        private float speed;
        private Vector3 position;
        private Vector3 front;
        private Vector3 up;

        public Camera(Vector3 position, Vector3 front, Vector3 up)
        {
            this.position = position;
            this.front = front;
            this.up = up;
            this.speed = 0.001f;
        }

        public void setRight()
        {
            position += Vector3.Normalize(Vector3.Cross(front, up)) * speed;
        }

        public void setLeft()
        {
            position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed;
        }

        public void setFront()
        {
            position += front * speed;
        }

        public void setBack()
        {
            position -= front * speed;
        }

        public void setUp()
        {
            position -= up * speed;
        }
        public void setDown()
        {
            position += up * speed;
        }

        public Matrix4 getView()
        {
            return Matrix4.LookAt(position, position + front, up);
        }

        public Vector3 getPosition()
        {
            return this.position;
        }

        public Vector3 getFront()
        {
            return this.front;
        }

        public Vector3 getUp()
        {
            return this.up;
        }

    }
}