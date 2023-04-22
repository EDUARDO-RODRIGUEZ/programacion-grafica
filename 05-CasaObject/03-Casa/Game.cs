using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace _04_CasaObject
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

            Objeto casa1 = new Objeto(new Punto(0, 0, 0), 5, 5, 5, "objetos\\casa.txt");
            Objeto auto1 = new Objeto(new Punto(50, 0, 0), 3, 3, 3, "objetos\\auto.txt");
            Objeto casa2 = new Objeto(new Punto(0, 0, -40), 5, 5, 5, "objetos\\casa.txt");
            Objeto auto2 = new Objeto(new Punto(50, 0, -40), 3, 3, 3, "objetos\\auto.txt");
            casa1.loadFace();
            auto1.loadFace();
            casa2.loadFace();
            auto2.loadFace();
            scene.addObject(casa1);
            scene.addObject(auto1);
            scene.addObject(casa2);
            scene.addObject(auto2);

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
            GL.Rotate(radio, 0, 1, 0);

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