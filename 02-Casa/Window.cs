using _02_Casa.Graphic;
using _02_Casa.Object;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace _02_Casa
{
    public class Window : GameWindow
    {
        private Camera camera;
        private Matrix4 projection;
        private Vector2i size;
        private int WIDTH;
        private int HEIGHT;
        private Mesh mesh;
        private Mesh techo;
        private Render render;
        public GameObject gameObject;
        public GameObject gameObjectTecho;
        private Shader shader;
        private double time;

        public Window(GameWindowSettings gameWindowSettings, Vector2i size, string title) : base(gameWindowSettings, new NativeWindowSettings()
        {
            Size = size,
            Title = title
        })
        {
            WIDTH = size.X;
            HEIGHT = size.Y;
            projection = Matrix4.CreatePerspectiveFieldOfView(
                    MathHelper.DegreesToRadians(60),
                    (float)WIDTH / (float)HEIGHT,
                    0.01f,
                    1000.0f
            );

            camera = new Camera(new Vector3(0.0f, 0.0f, 3.0f), new Vector3(0.0f, 0.0f, -1.0f), new Vector3(0.0f, 1.0f, 0.0f));

            mesh = new Mesh(new Vertex[] {
                //Cuadrado frente: triangulo
                new Vertex(new Vector3(-0.25f, 0.25f, 0.0f), new Vector3(1,1,0)),
                new Vertex(new Vector3(0.25f, 0.25f, 0.0f), new Vector3(1,1,0)),
                new Vertex(new Vector3(0.25f, -0.3f, 0.0f), new Vector3(1,1,0)),
                new Vertex(new Vector3(-0.25f, -0.3f, 0.0f), new Vector3(1,1,0)),

                //Cuadrado detras: triangulo   
                new Vertex(new Vector3(0.0f, 0.5f, -0.2f), new Vector3(1,1,0)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.2f), new Vector3(1,1,0)),
                new Vertex(new Vector3(0.5f, -0.05f, -0.2f), new Vector3(1,1,0)),
                new Vertex(new Vector3(0.0f, -0.05f, -0.2f), new Vector3(1,1,0)),
                
                //Cuadrado izquierdo: triangulo   
                new Vertex(new Vector3(-0.25f, 0.25f, 0.0f), new Vector3(0.70f,0.46f,0.30f)),
                new Vertex(new Vector3(0.0f, 0.5f, -0.2f), new Vector3(0.70f,0.46f,0.30f)),
                new Vertex(new Vector3(0.0f, -0.05f, -0.2f), new Vector3(0.70f,0.46f,0.30f)),
                new Vertex(new Vector3(-0.25f, -0.3f, 0.0f), new Vector3(0.70f,0.46f,0.30f)),
                
                //Cuadrado dereacho: triangulo   
                new Vertex(new Vector3(0.25f, 0.25f, 0.0f), new Vector3(0.70f,0.46f,0.30f)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.2f), new Vector3(0.70f,0.46f,0.30f)),
                new Vertex(new Vector3(0.5f, -0.05f, -0.2f), new Vector3(0.70f,0.46f,0.30f)),
                new Vertex(new Vector3(0.25f, -0.3f, 0.0f), new Vector3(0.70f,0.46f,0.30f)),

                //Cuadrado inferior: triangulo   
                new Vertex(new Vector3(0.25f, -0.3f, 0.0f), new Vector3(0.92f,0.60f,0.30f)),
                new Vertex(new Vector3(-0.25f, -0.3f, 0.0f), new Vector3(0.92f,0.60f,0.30f)),
                new Vertex(new Vector3(0.5f, -0.05f, -0.2f), new Vector3(0.92f,0.60f,0.30f)),
                new Vertex(new Vector3(0.0f, -0.05f, -0.2f), new Vector3(0.92f,0.60f,0.30f)),
                
                //Cuadrado superior: triangulo   
                new Vertex(new Vector3(0.25f, 0.25f, 0.0f), new Vector3(0.92f,0.60f,0.30f)),
                new Vertex(new Vector3(-0.25f, 0.25f, 0.0f), new Vector3(0.92f,0.60f,0.30f)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.2f), new Vector3(0.92f,0.60f,0.30f)),
                new Vertex(new Vector3(0.0f, 0.5f, -0.2f), new Vector3(0.92f,0.60f,0.30f)),
            }, new int[] {
                //Cuadrado Frontal
                0, 1, 2, //Primer Trinagulo
                0, 2, 3, //Segundo Trinagulo
                //Cuadrado Trasero
                4, 5, 6,
                4, 6, 7,
                //Cuadrado Izquierdo
                8, 9, 10,
                8, 10, 11,
                //Cuadrado Derecho
                12, 13, 14,
                12, 14, 15,
                //Cuadrado Inferior
                16, 17, 18,
                17, 18, 19,
                //Cuadrado Superior
                20, 21, 22,
                21, 22, 23
            });

            techo = new Mesh(new Vertex[]{
                //Trinagulo frente
                new Vertex(new Vector3(0.25f, 0.25f, 0.0f), new Vector3(0, 0, 1)),
                new Vertex(new Vector3(-0.25f, 0.25f, 0.0f), new Vector3(0, 0, 1)),
                new Vertex(new Vector3(0.0f, 0.5f, 0.0f), new Vector3(0, 0, 1)),
        
                //Trinagulo atras
                new Vertex(new Vector3(0.0f, 0.5f, -0.2f), new Vector3(0, 0, 1)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.2f), new Vector3(0, 0, 1)),
                new Vertex(new Vector3(0.25F, 0.75f, -0.2f), new Vector3(0, 0, 1)),
        
                //cuadrado diagonal derecho
                new Vertex(new Vector3(0.0f, 0.5f, 0.0f), new Vector3(1, 0, 0)),
                new Vertex(new Vector3(0.25F, 0.75f, -0.2f), new Vector3(1, 0, 0)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.2f), new Vector3(1, 0, 0)),
                new Vertex(new Vector3(0.25f, 0.25f, 0.0f), new Vector3(1, 0, 0)),

                new Vertex(new Vector3(0.0f, 0.5f, 0.0f), new Vector3(1, 0, 0)),
                new Vertex(new Vector3(-0.25f, 0.25f, 0.0f), new Vector3(1, 0, 0)),
                new Vertex(new Vector3(0.0f, 0.5f, -0.2f), new Vector3(1, 0, 0)),
                new Vertex(new Vector3(0.25F, 0.75f, -0.2f), new Vector3(1, 0, 0)),

            }, new int[] {
                0, 1, 2,
                3, 4, 5,
                6, 7, 8,
                6, 8, 9,
                10,11,12,
                10,13,12
             });

            gameObject = new GameObject(new Vector3(0, 0, -1), new Vector3(0, 0, 0), new Vector3(1, 1, 1), mesh);
            gameObjectTecho = new GameObject(new Vector3(0, 0, -1), new Vector3(0, 0, 0), new Vector3(1, 1, 1), techo);
        }

        protected override void OnLoad()
        {
            // GL.PolygonMode(MaterialFace.FrontAndBack,PolygonMode.Line);
            base.OnLoad();
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            shader = new Shader("shader/shader.vert", "shader/shader.frag");
            render = new Render(this, shader);
            mesh.create();
            techo.create();
            shader.create();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                camera.setFront();
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                camera.setBack();
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                camera.setLeft();
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                camera.setRight();
            }
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                camera.setDown();
            }
            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                camera.setUp();
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            render.renderMesh(gameObject, camera);
            render.renderMesh(gameObjectTecho, camera);
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUnload()
        {
            mesh.destroy();
            techo.destroy();
            shader.destroy();
            base.OnUnload();
        }

        public Matrix4 getProjection()
        {
            return this.projection;
        }

    }
}