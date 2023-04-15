using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa
{
    class Game : GameWindow
    {

        private float radio = 0;
        private Scene scene;
        private Plano plano;
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.47f, 0.32f, 0.23f, 1);
            scene = new Scene();
            plano = new Plano(new Punto(), 100, 100, 100);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            GL.Rotate(radio, 0.1, 1, 0);

            plano.draw();
            scene.draw();

            radio += 1f;
            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-100, 100, -100, 100, -100, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.Disable(EnableCap.DepthTest);
            base.OnUnload(e);
        }
    }
}