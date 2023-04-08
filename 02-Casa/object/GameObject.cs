
using _02_Casa.Graphic;
using OpenTK.Mathematics;

namespace _02_Casa.Object
{
    public class GameObject
    {
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;
        private Mesh mesh;

        public GameObject(Vector3 position, Vector3 rotation, Vector3 scale,Mesh mesh)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.mesh=mesh;
        }

        public Vector3 getPosition()
        {
            return this.position;
        }

        public void setPosition(Vector3 position)
        {
            this.position = position;
        }

        public Vector3 getRotation()
        {
            return this.rotation;
        }

        public void setRotation(Vector3 rotation)
        {
            this.rotation = rotation;
        }

        public Vector3 getScale()
        {
            return this.scale;
        }

        public void setScale(Vector3 scale)
        {
            this.scale = scale;
        }

        public Mesh getMesh()
        {
            return this.mesh;
        }

        public void setMesh(Mesh mesh)
        {
            this.mesh = mesh;
        }

    }
}