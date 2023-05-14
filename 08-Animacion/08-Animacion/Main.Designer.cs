
using System.Windows.Forms;

namespace _08_Animacion
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxObjeto = new System.Windows.Forms.ComboBox();
            this.labelObjeto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFace = new System.Windows.Forms.ComboBox();
            this.comboBoxTransform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxObjeto
            // 
            this.comboBoxObjeto.FormattingEnabled = true;
            this.comboBoxObjeto.Location = new System.Drawing.Point(123, 16);
            this.comboBoxObjeto.Name = "comboBoxObjeto";
            this.comboBoxObjeto.Size = new System.Drawing.Size(168, 21);
            this.comboBoxObjeto.TabIndex = 0;
            this.comboBoxObjeto.SelectedValueChanged += new System.EventHandler(this.comboBoxObjeto_SelectedValueChanged);
            // 
            // labelObjeto
            // 
            this.labelObjeto.AutoSize = true;
            this.labelObjeto.Location = new System.Drawing.Point(12, 19);
            this.labelObjeto.Name = "labelObjeto";
            this.labelObjeto.Size = new System.Drawing.Size(43, 13);
            this.labelObjeto.TabIndex = 1;
            this.labelObjeto.Text = "Objetos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caras";
            // 
            // comboBoxFace
            // 
            this.comboBoxFace.FormattingEnabled = true;
            this.comboBoxFace.Location = new System.Drawing.Point(123, 57);
            this.comboBoxFace.Name = "comboBoxFace";
            this.comboBoxFace.Size = new System.Drawing.Size(168, 21);
            this.comboBoxFace.TabIndex = 3;
            // 
            // comboBoxTransform
            // 
            this.comboBoxTransform.FormattingEnabled = true;
            this.comboBoxTransform.Location = new System.Drawing.Point(123, 106);
            this.comboBoxTransform.Name = "comboBoxTransform";
            this.comboBoxTransform.Size = new System.Drawing.Size(168, 21);
            this.comboBoxTransform.TabIndex = 5;
            this.comboBoxTransform.SelectedValueChanged += new System.EventHandler(this.comboBoxTransform_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transformacion";
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(69, 159);
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(222, 45);
            this.trackBarX.TabIndex = 6;
            this.trackBarX.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(69, 219);
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(222, 45);
            this.trackBarY.TabIndex = 7;
            this.trackBarY.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // trackBarZ
            // 
            this.trackBarZ.Location = new System.Drawing.Point(69, 280);
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Size = new System.Drawing.Size(222, 45);
            this.trackBarZ.TabIndex = 8;
            this.trackBarZ.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Z";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(24, 348);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(108, 23);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.comboBoxTransform);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxFace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelObjeto);
            this.Controls.Add(this.comboBoxObjeto);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxObjeto;
        private System.Windows.Forms.Label labelObjeto;
        private System.Windows.Forms.Label label1;
        private ComboBox comboBoxFace;
        private System.Windows.Forms.ComboBox comboBoxTransform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Button buttonStart;
    }
}

