using OpenTK.Graphics.OpenGL;

namespace _02_Casa.Graphic
{
    public class Mesh
    {
        private Vertex[] vertices;
        private int[] indices;
        private int vao;
        private int vbo;
        private int ibo;
        private int cbo;

        public Mesh(Vertex[] vertices, int[] indices)
        {
            this.vertices = vertices;
            this.indices = indices;
        }

        public void create()
        {
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            float[] position = new float[vertices.Length * 3];
            float[] color = new float[vertices.Length * 3];

            for (int i = 0; i < vertices.Length; i++)
            {
                position[i * 3] = vertices[i].getPosition().X;
                position[i * 3 + 1] = vertices[i].getPosition().Y;
                position[i * 3 + 2] = vertices[i].getPosition().Z;

                color[i * 3] = vertices[i].getColor().X;
                color[i * 3 + 1] = vertices[i].getColor().Y;
                color[i * 3 + 2] = vertices[i].getColor().Z;
            }

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, position.Length * sizeof(float), position, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            cbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, cbo);
            GL.BufferData(BufferTarget.ArrayBuffer, color.Length * sizeof(float), color, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            ibo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            GL.BindVertexArray(0);
        }

        public void destroy()
        {
            GL.DeleteBuffer(vbo);
            GL.DeleteBuffer(cbo);
            GL.DeleteBuffer(ibo);
            GL.DeleteVertexArray(vao);
        }

        public Vertex[] getVertices()
        {
            return this.vertices;
        }
        public int[] getIndices()
        {
            return this.indices;
        }
        public int getVao()
        {
            return this.vao;
        }
        public int getVbo()
        {
            return this.vbo;
        }
        public int getIbo()
        {
            return this.ibo;
        }
        public int getCbo()
        {
            return this.cbo;
        }
    }
}