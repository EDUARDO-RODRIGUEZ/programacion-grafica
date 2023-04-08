using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace _02_Casa.Graphic
{
    public class Shader
    {
        private int programId;
        private int vertexId;
        private int fragmentId;
        private String vertexfile;
        private String fragmentfile;
        private String vertexPath;
        private String fragmentPath;

        public Shader(String vertexPath, String fragmentPath)
        {
            this.vertexPath = vertexPath;
            this.fragmentPath = fragmentPath;
        }

        public void create()
        {
            vertexfile = File.ReadAllText(vertexPath);
            vertexId = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexId, vertexfile);
            CompileShader(vertexId);

            fragmentfile = File.ReadAllText(fragmentPath);
            fragmentId = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentId, fragmentfile);
            CompileShader(fragmentId);

            programId = GL.CreateProgram();
            GL.AttachShader(programId, vertexId);
            GL.AttachShader(programId, fragmentId);
            LinkProgram(programId);
        }


        private static void LinkProgram(int program)
        {
            GL.LinkProgram(program);
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
            {
                throw new Exception($"Error occurred whilst linking Program({program})");
            }
        }

        private static void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
            }
        }

        public void destroy()
        {
            GL.DetachShader(programId, vertexId);
            GL.DetachShader(programId, fragmentId);
            GL.DeleteShader(vertexId);
            GL.DeleteShader(fragmentId);
            GL.DeleteProgram(programId);
        }

        public void bind()
        {
            GL.UseProgram(programId);
        }

        public void unbid()
        {
            GL.UseProgram(0);
        }

        public int getUniformLocation(string uniformName)
        {
            return GL.GetUniformLocation(programId, uniformName);
        }

        public void setUniform(string uniformName, float value)
        {
            GL.Uniform1(getUniformLocation(uniformName), value);
        }

        public void setUniform(string uniformName, int value)
        {
            GL.Uniform1(getUniformLocation(uniformName), value);
        }

        public void setUniform(string uniformName, bool value)
        {
            GL.Uniform1(getUniformLocation(uniformName), value ? 1 : 0);
        }

        public void setUniform(string uniformName, Vector2 value)
        {
            GL.Uniform2(getUniformLocation(uniformName), value.X, value.Y);
        }

        public void setUniform(string uniformName, Vector3 value)
        {
            GL.Uniform3(getUniformLocation(uniformName), value.X, value.Y, value.Z);
        }

        public void setUniform(string uniformName, Matrix4 value)
        {
            GL.UniformMatrix4(getUniformLocation(uniformName), true, ref value);
        }

    }
}