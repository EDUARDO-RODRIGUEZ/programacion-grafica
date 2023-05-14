using _08_Animacion.extructura;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace _08_Animacion.animacion
{
    public class Libreto
    {
        private List<Accion> actions;
        private Scene scene;

        public Libreto(Scene scene)
        {
            actions = new List<Accion>();
            this.scene = scene;
            loadActions();
        }

        public void loadActions()
        {
            actions.Add(Accion.DeserializeJsonFile("animacion\\animacionCasa.json"));
        }

        public void run()
        {
            foreach (var action in actions)
            {
                Objeto objeto = scene.getObject(action.nameObject);
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = action.timeStart*1000;
                timer.AutoReset = false;
                timer.Elapsed += (sender, e) => animate(sender, e, objeto);
                timer.Enabled = true;
            }
        }

        private void animate(object sender, ElapsedEventArgs e, Objeto objeto)
        {
            int time = 0;
            float salto = 0;
            float angle = 0;
            while (true)
            {
                salto += 0.1f;
                time += 100;
                angle += 10;
                objeto.rotate(new Vector3(0, angle, 0));
                objeto.translate(new Vector3(salto, 0, 0));
                if (time >= 10000)
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }
    }
}
