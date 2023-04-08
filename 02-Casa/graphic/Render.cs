using _02_Casa.Object;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace _02_Casa.Graphic
{
    public class Render
    {
        public static double time = 0.0;
        private Shader shader;
        private Window window;

        public Render(Window window, Shader shader)
        {
            this.shader = shader;
            this.window = window;
        }

        public void renderMesh(GameObject gameObject, Camera camera)
        {
            GL.BindVertexArray(gameObject.getMesh().getVao());
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, gameObject.getMesh().getIbo());
            shader.bind();
            setProjection();
            setView(camera);
            setModel(gameObject);
            GL.DrawElements(BeginMode.Triangles, gameObject.getMesh().getIndices().Length, DrawElementsType.UnsignedInt, 0);
            shader.unbid();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.DisableVertexAttribArray(1);
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }

        public void setModel(GameObject gameObject)
        {
            time += 0.00001;
            // gameObject.setRotation(new Vector3(gameObject.getRotation().X  ((float)time) , gameObject.getRotation().Y * ((float)time) , gameObject.getRotation().Z * ((float)time)));
            Matrix4 model = Matrix4.Identity;

            // model = model * Matrix4.CreateRotationY((float)time * 13.0f);
            // model = model * Matrix4.CreateRotationZ((float)time * 13.0f);

            model = model * Matrix4.CreateTranslation(gameObject.getPosition());

            model = model * Matrix4.CreateRotationX(gameObject.getRotation().X);
            model = model * Matrix4.CreateRotationY(gameObject.getRotation().Y);
            model = model * Matrix4.CreateRotationZ(gameObject.getRotation().Z);

            model = model * Matrix4.CreateScale(gameObject.getScale());

            shader.setUniform("model", model);
        }

        public void setView(Camera camera)
        {
            shader.setUniform("view", camera.getView());
        }

        public void setProjection()
        {
            shader.setUniform("projection", window.getProjection());
        }

    }
}