using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace _07_CasaObject
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
            plano = new Plano(new Punto(), 100, 100, 100);
            scene = new Scene(new Punto(0, 0, 0));

            Objeto casa1 = new Objeto(new Punto(-10, 0, 0), "objetos\\casa.json", "casa1", scene);
            casa1.loadJson();

            Objeto casa2 = new Objeto(new Punto(10, 0, 0), "objetos\\casa.json", "casa2", scene);
            casa2.loadJson();

            scene.addObject(casa1);
            scene.addObject(casa2);

            //scene.setRespectToScene();
            //scene.rotate(new Vector3(0, 0, 90));

            casa2.setRespectToObjeto();
            casa2.rotate(new Vector3(0, 0, 90));

            Face face0 = casa1.getFace(0);
            face0.setRespectFace();
            face0.rotate(new Vector3(0, 0, 45));

            //casa1.translate(new Vector3(30,0,0));

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
            GL.Ortho(-20, 20, -20, 20, -20, 20);
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