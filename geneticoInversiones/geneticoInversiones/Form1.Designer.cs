namespace geneticoInversiones
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonCalcularSolucion = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMejorEvaluacion = new System.Windows.Forms.TextBox();
            this.textBoxMejorGenes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxIteraciones = new System.Windows.Forms.TextBox();
            this.textBoxTamañoDePoblacion = new System.Windows.Forms.TextBox();
            this.textBoxPorcentajeCruce = new System.Windows.Forms.TextBox();
            this.textBoxPorcentajeMutacion = new System.Windows.Forms.TextBox();
            this.textBoxPorcentajeAceptado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonCalcularSolucion
            // 
            this.botonCalcularSolucion.Location = new System.Drawing.Point(6, 173);
            this.botonCalcularSolucion.Name = "botonCalcularSolucion";
            this.botonCalcularSolucion.Size = new System.Drawing.Size(427, 41);
            this.botonCalcularSolucion.TabIndex = 1;
            this.botonCalcularSolucion.Text = "Calcular Solución";
            this.botonCalcularSolucion.UseVisualStyleBackColor = true;
            this.botonCalcularSolucion.Click += new System.EventHandler(this.botonCalcularSolucion_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(457, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(580, 470);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(211, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMejorEvaluacion);
            this.groupBox1.Controls.Add(this.textBoxMejorGenes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(36, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 147);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mostrar Mejor Individuo de la Iteración";
            // 
            // textBoxMejorEvaluacion
            // 
            this.textBoxMejorEvaluacion.Location = new System.Drawing.Point(211, 104);
            this.textBoxMejorEvaluacion.Name = "textBoxMejorEvaluacion";
            this.textBoxMejorEvaluacion.Size = new System.Drawing.Size(149, 20);
            this.textBoxMejorEvaluacion.TabIndex = 8;
            // 
            // textBoxMejorGenes
            // 
            this.textBoxMejorGenes.Location = new System.Drawing.Point(40, 104);
            this.textBoxMejorGenes.Name = "textBoxMejorGenes";
            this.textBoxMejorGenes.Size = new System.Drawing.Size(149, 20);
            this.textBoxMejorGenes.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Evaluación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Genes: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Iteración: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(415, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Abrir Archivo de inversiones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxIteraciones);
            this.groupBox2.Controls.Add(this.textBoxTamañoDePoblacion);
            this.groupBox2.Controls.Add(this.textBoxPorcentajeCruce);
            this.groupBox2.Controls.Add(this.textBoxPorcentajeMutacion);
            this.groupBox2.Controls.Add(this.textBoxPorcentajeAceptado);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.botonCalcularSolucion);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 220);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración";
            // 
            // textBoxIteraciones
            // 
            this.textBoxIteraciones.Location = new System.Drawing.Point(202, 124);
            this.textBoxIteraciones.Name = "textBoxIteraciones";
            this.textBoxIteraciones.Size = new System.Drawing.Size(208, 20);
            this.textBoxIteraciones.TabIndex = 6;
            this.textBoxIteraciones.Text = "4";
            // 
            // textBoxTamañoDePoblacion
            // 
            this.textBoxTamañoDePoblacion.Location = new System.Drawing.Point(202, 100);
            this.textBoxTamañoDePoblacion.Name = "textBoxTamañoDePoblacion";
            this.textBoxTamañoDePoblacion.Size = new System.Drawing.Size(208, 20);
            this.textBoxTamañoDePoblacion.TabIndex = 6;
            this.textBoxTamañoDePoblacion.Text = "20";
            // 
            // textBoxPorcentajeCruce
            // 
            this.textBoxPorcentajeCruce.Location = new System.Drawing.Point(202, 74);
            this.textBoxPorcentajeCruce.Name = "textBoxPorcentajeCruce";
            this.textBoxPorcentajeCruce.Size = new System.Drawing.Size(208, 20);
            this.textBoxPorcentajeCruce.TabIndex = 6;
            this.textBoxPorcentajeCruce.Text = "20";
            // 
            // textBoxPorcentajeMutacion
            // 
            this.textBoxPorcentajeMutacion.Location = new System.Drawing.Point(202, 48);
            this.textBoxPorcentajeMutacion.Name = "textBoxPorcentajeMutacion";
            this.textBoxPorcentajeMutacion.Size = new System.Drawing.Size(208, 20);
            this.textBoxPorcentajeMutacion.TabIndex = 6;
            this.textBoxPorcentajeMutacion.Text = "20";
            // 
            // textBoxPorcentajeAceptado
            // 
            this.textBoxPorcentajeAceptado.Location = new System.Drawing.Point(202, 22);
            this.textBoxPorcentajeAceptado.Name = "textBoxPorcentajeAceptado";
            this.textBoxPorcentajeAceptado.Size = new System.Drawing.Size(208, 20);
            this.textBoxPorcentajeAceptado.TabIndex = 6;
            this.textBoxPorcentajeAceptado.Text = "50";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Iteraciones: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tamaño de la población: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Porcentaje de cruce: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Porcentaje de mutación: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porcentaje de población aceptada: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonCalcularSolucion;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxMejorEvaluacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMejorGenes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTamañoDePoblacion;
        private System.Windows.Forms.TextBox textBoxPorcentajeCruce;
        private System.Windows.Forms.TextBox textBoxPorcentajeMutacion;
        private System.Windows.Forms.TextBox textBoxPorcentajeAceptado;
        private System.Windows.Forms.TextBox textBoxIteraciones;
        private System.Windows.Forms.Label label8;
    }
}

