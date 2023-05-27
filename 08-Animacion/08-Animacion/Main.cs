using _08_Animacion;
using _08_Animacion.animacion;
using _08_Animacion.extra;
using _08_Animacion.extructura;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_Animacion
{
    public partial class Main : Form
    {

        private Game game;
        private Scene scene;
        private Libreto libreto;

        private float minRotate = -180f;
        private float maxRotate = 180f;

        private float minTraslate = -5f;
        private float maxTraslate = 5f;

        private float minScale = 0f;
        private float maxScale = 4f;

        public Main()
        {
            InitializeComponent();
            loadOpengl();
            loadConfigMain();
        }


        private void loadOpengl()
        {
            scene = new Scene(new Punto(0, 0, 0));
            libreto = new Libreto(scene);
            Objeto casa1 = new Objeto(new Punto(-10, 0, 0), "objetos\\casa.json", "casa1", scene);
            casa1.loadJson();

            scene.addObject(casa1);
            Thread opengl = new Thread(runOpengl);
            opengl.Start();

        }

        private void runOpengl()
        {
            game = new Game(800, 500, "App Animacion");
            game.setScene(scene);
            game.Run(30.0);
        }

        public void loadConfigMain()
        {
            this.comboBoxObjeto.DataSource = scene.getObjects().Keys.Prepend("Escenario").ToList();
            this.comboBoxTransform.DataSource = new List<string> { "Rotacion", "Traslacion", "Escalado" };
            showFace();
        }

        public void showFace()
        {
            string key = this.comboBoxObjeto.SelectedItem.ToString();
            if (key.Equals("Escenario"))
            {
                comboBoxFace.Enabled = false;
                comboBoxFace.DataSource = null;
            }
            else
            {
                comboBoxFace.Enabled = true;
                comboBoxFace.DataSource = scene.getObject(key).getFaces().Keys.Prepend("Objeto").ToList();
            }
        }

        private void comboBoxObjeto_SelectedValueChanged(object sender, EventArgs e)
        {
            showFace();
        }

        private void comboBoxTransform_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBoxTransform.SelectedItem.ToString())
            {
                case "Rotacion":
                    setSliderTrackBar(minRotate, maxRotate);
                    break;
                case "Traslacion":
                    setSliderTrackBar(minTraslate, maxTraslate);
                    break;
                case "Escalado":
                    setSliderTrackBar(minScale, maxScale);
                    break;
            }
        }

        public void setSliderTrackBar(float minValue, float maxValue)
        {
            trackBarX.Minimum = (int)minValue;
            trackBarX.Maximum = (int)maxValue;
            trackBarY.Minimum = (int)minValue;
            trackBarY.Maximum = (int)maxValue;
            trackBarZ.Minimum = (int)minValue;
            trackBarZ.Maximum = (int)maxValue;
            if (comboBoxTransform.SelectedItem.ToString().Equals("Escalado"))
            {
                trackBarX.Value = 1;
                trackBarY.Value = 1;
                trackBarZ.Value = 1;
                return;
            }
            trackBarX.Value = 0;
            trackBarY.Value = 0;
            trackBarZ.Value = 0;
        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            string objetoSelected = comboBoxObjeto.SelectedItem.ToString();
            string transformSelected = comboBoxTransform.SelectedItem.ToString();
            string faceSelected;

            Vector3 coordinates = new Vector3(trackBarX.Value, trackBarY.Value, trackBarZ.Value);

            if (transformSelected.Equals("Rotacion"))
            {
                if (objetoSelected.Equals("Escenario"))
                {
                    game.getScene().rotate(coordinates);
                    return;
                }

                Objeto objeto = scene.getObject(objetoSelected);

                faceSelected = comboBoxFace.SelectedItem.ToString();

                if (faceSelected.Equals("Objeto"))
                {
                    objeto.rotate(coordinates);
                    return;
                }

                Face face = objeto.getFace(faceSelected);
                face.rotate(coordinates);
                return;
            }


            if (transformSelected.Equals("Traslacion"))
            {
                if (objetoSelected.Equals("Escenario"))
                {
                    game.getScene().translate(coordinates);
                    return;
                }

                Objeto objeto = scene.getObject(objetoSelected);
                faceSelected = comboBoxFace.SelectedItem.ToString();

                if (faceSelected.Equals("Objeto"))
                {
                    objeto.translate(coordinates);
                    return;
                }
                Face face = objeto.getFace(faceSelected);
                face.translate(coordinates);
                return;
            }


            if (transformSelected.Equals("Escalado"))
            {

                if (objetoSelected.Equals("Escenario"))
                {
                    game.getScene().scale(coordinates);
                    return;
                }
                Objeto objeto = scene.getObject(objetoSelected);
                faceSelected = comboBoxFace.SelectedItem.ToString();

                if (faceSelected.Equals("Objeto"))
                {
                    objeto.scale(coordinates);
                    return;
                }
                Face face = objeto.getFace(faceSelected);
                face.scale(coordinates);
                return;
            }

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            libreto.run();
        }
    }
}
