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

            Objeto casa1 = new Objeto(new Punto(0, 0, 0), 5, 5, 5);
            casa1.setFaces(new Dictionary<int, Face>() {
                {0 , new Face(new List<Vector3>(){
                    new Vector3(-2,2,2),
                    new Vector3(2,2,2),
                    new Vector3(2,-2,2),
                    new Vector3(-2,-2,2),
                })},
                {1,new Face(new List<Vector3>(){
                    new Vector3(-2,2,-2),
                    new Vector3(2,2,-2),
                    new Vector3(2,-2,-2),
                    new Vector3(-2,-2,-2),
                })},
                {2,new Face(new List<Vector3>(){
                    new Vector3(2,2,-2),
                    new Vector3(2,2,2),
                    new Vector3(2,-2,2),
                    new Vector3(2,-2,-2),
                })},
                {3,
                    new Face(new List<Vector3>(){
                    new Vector3(-2,2,-2),
                    new Vector3(-2,2,2),
                    new Vector3(-2,-2,2),
                    new Vector3(-2,-2,-2),
                })},
                {4,
                    new Face(new List<Vector3>(){
                    new Vector3(-2,2,-2),
                    new Vector3(2,2,-2),
                    new Vector3(2,2,2),
                    new Vector3(-2,2,2),
                })},
                {5,
                    new Face(new List<Vector3>(){
                    new Vector3(-2,-2,-2),
                    new Vector3(2,-2,-2),
                    new Vector3(2,-2,2),
                    new Vector3(-2,-2,2),
                })},
                {6,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,2),
                    new Vector3(-2,2,2),
                    new Vector3(2,2,2),
                })},
                {7,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,-2),
                    new Vector3(-2,2,-2),
                    new Vector3(2,2,-2),
                })},
                {8,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,2),
                    new Vector3(2,2,2),
                    new Vector3(2,2,-2),
                    new Vector3(0,6,-2),
                })},
                {9,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,2),
                    new Vector3(-2,2,2),
                    new Vector3(-2,2,-2),
                    new Vector3(0,6,-2),
                })},
                {10,
                    new Face(new List<Vector3>(){
                    new Vector3(-0.5f,-2,2.1f),
                    new Vector3(-0.5f,1,2.1f),
                    new Vector3(0.5f,1,2.1f),
                    new Vector3(0.5f,-2,2.1f),
                })},
            });

            Objeto auto1 = new Objeto(new Punto(50, 0, 0), 3, 3, 3);
            auto1.setFaces(new Dictionary<int, Face>() {
                {0,new Face(new List<Vector3>(){
                new Vector3(-3,1,2),
                new Vector3(3,1,2),
                new Vector3(3,-1,2),
                new Vector3(-3,-1,2),
                })},
                {1,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(3,1,-2),
                new Vector3(3,-1,-2),
                new Vector3(-3,-1,-2),
                })},
                {2,new Face(new List<Vector3>(){
                new Vector3(3,1,-2),
                new Vector3(3,1,2),
                new Vector3(3,-1,2),
                new Vector3(3,-1,-2),
                })},
                {3,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(-3,1,2),
                new Vector3(-3,-1,2),
                new Vector3(-3,-1,-2),
                })},
                {4,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(3,1,-2),
                new Vector3(3,1,2),
                new Vector3(-3,1,2),
                })},
                {5,new Face(new List<Vector3>(){
                new Vector3(-3,-1,-2),
                new Vector3(3,-1,-2),
                new Vector3(3,-1,2),
                new Vector3(-3,-1,2),
                })},
                {6,new Face(new List<Vector3>(){
                new Vector3(-3,1,2),
                new Vector3(-1,2,2),
                new Vector3(-1,2,-2),
                new Vector3(-3,1,-2),
                })},
                {7,new Face(new List<Vector3>(){
                new Vector3(3,1,2),
                new Vector3(1,2,2),
                new Vector3(1,2,-2),
                new Vector3(3,1,-2),
                })},
                {8,new Face(new List<Vector3>(){
                new Vector3(-1,2,-2),
                new Vector3(-1,2,2),
                new Vector3(1,2,2),
                new Vector3(1,2,-2),
                })},
                {9,new Face(new List<Vector3>(){
                new Vector3(-3,1,2),
                new Vector3(-1,2,2),
                new Vector3(1,2,2),
                new Vector3(3,1,2),
                })},
                {10,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(-1,2,-2),
                new Vector3(1,2,-2),
                new Vector3(3,1,-2),
                })},
                {11,new Face(new List<Vector3>(){
                new Vector3(1.4f,-1.4f,2.1f),
                new Vector3(2.1f,-1.05f,2.1f),
                new Vector3(2.1f,-0.35f,2.1f),
                new Vector3(1.4f,0,2.1f),
                new Vector3(0.7f,-0.35f,2.1f),
                new Vector3(0.7f,-1.05f,2.1f),
                })},
                {12,new Face(new List<Vector3>(){
                new Vector3(1.4f,-1.4f,-2.1f),
                new Vector3(2.1f,-1.05f,-2.1f),
                new Vector3(2.1f,-0.35f,-2.1f),
                new Vector3(1.4f,0,-2.1f),
                new Vector3(0.7f,-0.35f,-2.1f),
                new Vector3(0.7f,-1.05f,-2.1f),
                })},
                {13,new Face(new List<Vector3>(){
                new Vector3(-1.4f,-1.4f,2.1f),
                new Vector3(-2.1f,-1.05f,2.1f),
                new Vector3(-2.1f,-0.35f,2.1f),
                new Vector3(-1.4f,0,2.1f),
                new Vector3(-0.7f,-0.35f,2.1f),
                new Vector3(-0.7f,-1.05f,2.1f),
                })},
                {14,new Face(new List<Vector3>(){
                new Vector3(-1.4f,-1.4f,-2.1f),
                new Vector3(-2.1f,-1.05f,-2.1f),
                new Vector3(-2.1f,-0.35f,-2.1f),
                new Vector3(-1.4f,0,-2.1f),
                new Vector3(-0.7f,-0.35f,-2.1f),
                new Vector3(-0.7f,-1.05f,-2.1f),
                })},
            });

            Objeto casa2 = new Objeto(new Punto(0, 0, -40), 5, 5, 5);
            casa2.setFaces(new Dictionary<int, Face>() {
                {0 , new Face(new List<Vector3>(){
                    new Vector3(-2,2,2),
                    new Vector3(2,2,2),
                    new Vector3(2,-2,2),
                    new Vector3(-2,-2,2),
                })},
                {1,new Face(new List<Vector3>(){
                    new Vector3(-2,2,-2),
                    new Vector3(2,2,-2),
                    new Vector3(2,-2,-2),
                    new Vector3(-2,-2,-2),
                })},
                {2,new Face(new List<Vector3>(){
                    new Vector3(2,2,-2),
                    new Vector3(2,2,2),
                    new Vector3(2,-2,2),
                    new Vector3(2,-2,-2),
                })},
                {3,
                    new Face(new List<Vector3>(){
                    new Vector3(-2,2,-2),
                    new Vector3(-2,2,2),
                    new Vector3(-2,-2,2),
                    new Vector3(-2,-2,-2),
                })},
                {4,
                    new Face(new List<Vector3>(){
                    new Vector3(-2,2,-2),
                    new Vector3(2,2,-2),
                    new Vector3(2,2,2),
                    new Vector3(-2,2,2),
                })},
                {5,
                    new Face(new List<Vector3>(){
                    new Vector3(-2,-2,-2),
                    new Vector3(2,-2,-2),
                    new Vector3(2,-2,2),
                    new Vector3(-2,-2,2),
                })},
                {6,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,2),
                    new Vector3(-2,2,2),
                    new Vector3(2,2,2),
                })},
                {7,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,-2),
                    new Vector3(-2,2,-2),
                    new Vector3(2,2,-2),
                })},
                {8,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,2),
                    new Vector3(2,2,2),
                    new Vector3(2,2,-2),
                    new Vector3(0,6,-2),
                })},
                {9,
                    new Face(new List<Vector3>(){
                    new Vector3(0,6,2),
                    new Vector3(-2,2,2),
                    new Vector3(-2,2,-2),
                    new Vector3(0,6,-2),
                })},
                {10,
                    new Face(new List<Vector3>(){
                    new Vector3(-0.5f,-2,2.1f),
                    new Vector3(-0.5f,1,2.1f),
                    new Vector3(0.5f,1,2.1f),
                    new Vector3(0.5f,-2,2.1f),
                })},
            });

            Objeto auto2 = new Objeto(new Punto(50, 0, -40), 3, 3, 3);
            auto2.setFaces(new Dictionary<int, Face>() {
                {0,new Face(new List<Vector3>(){
                new Vector3(-3,1,2),
                new Vector3(3,1,2),
                new Vector3(3,-1,2),
                new Vector3(-3,-1,2),
                })},
                {1,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(3,1,-2),
                new Vector3(3,-1,-2),
                new Vector3(-3,-1,-2),
                })},
                {2,new Face(new List<Vector3>(){
                new Vector3(3,1,-2),
                new Vector3(3,1,2),
                new Vector3(3,-1,2),
                new Vector3(3,-1,-2),
                })},
                {3,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(-3,1,2),
                new Vector3(-3,-1,2),
                new Vector3(-3,-1,-2),
                })},
                {4,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(3,1,-2),
                new Vector3(3,1,2),
                new Vector3(-3,1,2),
                })},
                {5,new Face(new List<Vector3>(){
                new Vector3(-3,-1,-2),
                new Vector3(3,-1,-2),
                new Vector3(3,-1,2),
                new Vector3(-3,-1,2),
                })},
                {6,new Face(new List<Vector3>(){
                new Vector3(-3,1,2),
                new Vector3(-1,2,2),
                new Vector3(-1,2,-2),
                new Vector3(-3,1,-2),
                })},
                {7,new Face(new List<Vector3>(){
                new Vector3(3,1,2),
                new Vector3(1,2,2),
                new Vector3(1,2,-2),
                new Vector3(3,1,-2),
                })},
                {8,new Face(new List<Vector3>(){
                new Vector3(-1,2,-2),
                new Vector3(-1,2,2),
                new Vector3(1,2,2),
                new Vector3(1,2,-2),
                })},
                {9,new Face(new List<Vector3>(){
                new Vector3(-3,1,2),
                new Vector3(-1,2,2),
                new Vector3(1,2,2),
                new Vector3(3,1,2),
                })},
                {10,new Face(new List<Vector3>(){
                new Vector3(-3,1,-2),
                new Vector3(-1,2,-2),
                new Vector3(1,2,-2),
                new Vector3(3,1,-2),
                })},
                {11,new Face(new List<Vector3>(){
                new Vector3(1.4f,-1.4f,2.1f),
                new Vector3(2.1f,-1.05f,2.1f),
                new Vector3(2.1f,-0.35f,2.1f),
                new Vector3(1.4f,0,2.1f),
                new Vector3(0.7f,-0.35f,2.1f),
                new Vector3(0.7f,-1.05f,2.1f),
                })},
                {12,new Face(new List<Vector3>(){
                new Vector3(1.4f,-1.4f,-2.1f),
                new Vector3(2.1f,-1.05f,-2.1f),
                new Vector3(2.1f,-0.35f,-2.1f),
                new Vector3(1.4f,0,-2.1f),
                new Vector3(0.7f,-0.35f,-2.1f),
                new Vector3(0.7f,-1.05f,-2.1f),
                })},
                {13,new Face(new List<Vector3>(){
                new Vector3(-1.4f,-1.4f,2.1f),
                new Vector3(-2.1f,-1.05f,2.1f),
                new Vector3(-2.1f,-0.35f,2.1f),
                new Vector3(-1.4f,0,2.1f),
                new Vector3(-0.7f,-0.35f,2.1f),
                new Vector3(-0.7f,-1.05f,2.1f),
                })},
                {14,new Face(new List<Vector3>(){
                new Vector3(-1.4f,-1.4f,-2.1f),
                new Vector3(-2.1f,-1.05f,-2.1f),
                new Vector3(-2.1f,-0.35f,-2.1f),
                new Vector3(-1.4f,0,-2.1f),
                new Vector3(-0.7f,-0.35f,-2.1f),
                new Vector3(-0.7f,-1.05f,-2.1f),
                })},
            });

            scene.addObject(casa1);
            scene.addObject(casa2);
            scene.addObject(auto1);
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