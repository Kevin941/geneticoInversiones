using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geneticoInversiones
{
    public partial class Form1 : Form
    {
        classIndividuoInversiones[] poblacion;
        public OpenFileDialog dialogoParaArchivo = new OpenFileDialog();
        public string connectionString = "";
        public int cantidadDeInversionistas = 0;
        static Random r = new Random();
        DataTable tablaInversiones = new DataTable();
        string pathArchivoExcelOrigen = "";
        public int porcentajeAceptado = 0;
        public int porcentajeMutacion = 0;
        public int porcentajeCruce = 0;
        public int tamañoPoblacion = 0;
        public int iteraciones = 0;
        public classIndividuoInversiones []mejoresIndividuosPorIteracion; 
        public Form1()
        {
            InitializeComponent();
        }

        private void ordenarPoblacion()
        {
            classIndividuoInversiones temporal = new classIndividuoInversiones(tablaInversiones, cantidadDeInversionistas); 

            for (int write = 0; write < poblacion.Length; write++)
            {
                for (int sort = 0; sort < poblacion.Length - 1; sort++)
                {
                    poblacion[sort].obtenerEvaluacion(); 
                    poblacion[sort+1].obtenerEvaluacion(); 

                    if (poblacion[sort].evaluacion < poblacion[sort + 1].evaluacion)
                    {
                        temporal = poblacion[sort + 1];
                        poblacion[sort + 1] = poblacion[sort];
                        poblacion[sort] = temporal;
                    }
                }
            }
        }

        private void crearProblacion(int cantidad)
        {
            poblacion = new classIndividuoInversiones[cantidad];
            for (int x = 0; x < poblacion.Length; x++)
            {
                poblacion[x] = new classIndividuoInversiones(tablaInversiones, cantidadDeInversionistas);
                poblacion[x].crearIndividuo(); 
                poblacion[x].llenarIndividuoAleatoriamente();
                poblacion[x].obtenerEvaluacion(); 
            }
        }

        private void realizarCruces(int porcentajeCruces, int porcentajeAceptado)
        {
            int limiteDelCicloAceptado= Convert.ToInt32(Math.Floor(Convert.ToDouble(poblacion.Length) * Convert.ToDouble(porcentajeAceptado / 100.0f)));
            int limiteDelCicloCruces = Convert.ToInt32(Math.Floor(Convert.ToDouble(limiteDelCicloAceptado) * Convert.ToDouble(porcentajeCruces / 100.0f)));
            for (int x = 0; x < limiteDelCicloCruces; x++)
            {
                if ((x + 1) < poblacion.Length)
                {

                    int puntoDeCruce = r.Next(0, poblacion[x].genes.Length); 
                    realizarCruce(poblacion[x], poblacion[x + 1], puntoDeCruce);
                    poblacion[x].obtenerEvaluacion();
                    poblacion[x+1].obtenerEvaluacion(); 
                }
            }
        }

        private void regenerarPoblacionDesechada(int porcentajeAceptado)
        {
            int limiteDelCicloDesechado = Convert.ToInt32(Math.Floor(Convert.ToDouble(poblacion.Length) * Convert.ToDouble(porcentajeAceptado / 100.0f)));
            for (int x = porcentajeAceptado; x < poblacion.Length; x++)
            {
                poblacion[x].llenarIndividuoAleatoriamente(); 
            }
        }

        private void realizarMutaciones(int porcentajeMutacion, int porcentajeAceptado)
        {
            int limiteDelCicloAceptado = Convert.ToInt32(Math.Floor(Convert.ToDouble(poblacion.Length) * Convert.ToDouble(porcentajeAceptado / 100.0f)));
            int limiteDelCicloMutaciones = Convert.ToInt32(Math.Floor(Convert.ToDouble(limiteDelCicloAceptado) * Convert.ToDouble(porcentajeMutacion / 100.0f)));
            for (int x = 0; x < limiteDelCicloMutaciones; x++)
            {
                
                poblacion[x].realizarMutacion(r.Next(0, 101));
                poblacion[x].obtenerEvaluacion(); 
            }
        }

        private void obtenerTablaInversionistas()
        {
            getPathExcel();
            if (pathArchivoExcelOrigen == "")
            {
                MessageBox.Show("Selecciona una ruta válida"); 
                return; 
            }
            getTablaInversiones();
            botonCalcularSolucion.Enabled = true; 
        }

        private void botonCalcularSolucion_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); 
            richTextBox1.Text = "" ; 
            try
            {
                porcentajeAceptado = Convert.ToInt16(textBoxPorcentajeAceptado.Text);
                int valor = porcentajeAceptado;
                if ((valor < 0) || (valor > 100))
                {
                    MessageBox.Show("Introduce un valor entre 1 y 100");
                    return;
                }
                porcentajeMutacion = Convert.ToInt16(textBoxPorcentajeMutacion.Text);
                valor = porcentajeMutacion;
                if ((valor < 0) || (valor > 100))
                {
                    MessageBox.Show("Introduce un valor entre 1 y 100");
                    return;
                }
                porcentajeCruce = Convert.ToInt16(textBoxPorcentajeCruce.Text);
                valor = porcentajeCruce;
                if ((valor < 0) || (valor > 100))
                {
                    MessageBox.Show("Introduce un valor entre 1 y 100");
                    return;
                }
                tamañoPoblacion = Convert.ToInt16(textBoxTamañoDePoblacion.Text);
                valor = tamañoPoblacion;
                if ((valor < 0) || (valor > 100))
                {
                    MessageBox.Show("Introduce un valor entre 1 y 100");
                    return;
                }
                iteraciones = Convert.ToInt16(textBoxIteraciones.Text);
                valor = iteraciones;
                if ((valor < 0) || (valor > 100))
                {
                    MessageBox.Show("Introduce un valor entre 1 y 100");
                    return;
                }
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Introduce números válidos. (Enteros del 1 al 100)");
                return; 
            }

             mejoresIndividuosPorIteracion = new classIndividuoInversiones[iteraciones];
             agregarIndicesDeIteracionAComboBox(); 
            
            
            //Primero se genera la población 
            crearProblacion(tamañoPoblacion);

            for (int x = 0; x < iteraciones; x++)
            {

                //Mostramos la poblacion inicial 
                //mostrarPoblacion("Población inicial"); 

                //Se ordena la población de mayor a menor según su función de evaluación para quedarnos con los primeros "n"
                ordenarPoblacion();
                mostrarPoblacion("Poblacion generada ordenada: " + tamañoPoblacion + " individuos");


                //Mutamos un porcentaje de la poblacion
                realizarMutaciones(porcentajeMutacion, porcentajeAceptado);
                //ordenarPoblacion(); 
                mostrarPoblacion("Poblacion ordenada con el " + porcentajeAceptado + " % de la población aceptada y el " + porcentajeMutacion + "% mutado.");

                //Cruzamos un porcentaje determinado de la población 
                realizarCruces(porcentajeCruce, porcentajeAceptado);
                //ordenarPoblacion(); 
                mostrarPoblacion("Poblacion ordenada con el " + porcentajeAceptado + " % de la población aceptada y el " + porcentajeCruce + "% cruzado.");

                //Ahora volvemos a generar de nuevo la población que desechamos. 
                regenerarPoblacionDesechada(porcentajeAceptado);
                // ordenarPoblacion(); 
                mostrarPoblacion("Poblacion ordenada con el " + (100 - porcentajeAceptado) + "% de la población regenerada.");

                ordenarPoblacion();


                //Se crea un nuevo individuo 
                mejoresIndividuosPorIteracion[x] = new classIndividuoInversiones(tablaInversiones, cantidadDeInversionistas);

                mejoresIndividuosPorIteracion[x].crearIndividuo(); 
                //Se copian los genes del mejor individuo
                for (int z = 0; z < mejoresIndividuosPorIteracion[x].genes.Length; z++)
                {
                    mejoresIndividuosPorIteracion[x].genes[z] = poblacion[0].genes[z]; 
                }

                //Se copia la evalación 
                mejoresIndividuosPorIteracion[x].evaluacion = poblacion[0].evaluacion; 

                    
            }            
        }


        public void agregarIndicesDeIteracionAComboBox()
        {
            for (int x = 0; x < iteraciones; x++)
            {
                comboBox1.Items.Add((x+1).ToString()); 
            }
        }
        public void mostrarPoblacion(string letrero)
        {
            
            richTextBox1.Text += letrero + "\n"; 
            for (int x = 0; x < poblacion.Length; x++)
            {
                richTextBox1.Text += poblacion[x].evaluacion + "\t ";

                for (int y = 0; y < poblacion[x].genes.Length; y++)
                {
                    richTextBox1.Text += poblacion[x].genes[y];
                }
                
                richTextBox1.Text += "\n";

            }
            richTextBox1.Text += "\n\n";
        }
        public void getTablaInversiones()
        {
            try
            {
                OleDbConnection conexion = new OleDbConnection();
                getConnectionString();
                conexion.ConnectionString = this.connectionString;
                OleDbCommand comando = new OleDbCommand();
                comando.CommandText = "select * from [Hoja1$]";
                comando.Connection = conexion;
                DataSet setDatos = new DataSet();
                OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(setDatos);
                tablaInversiones = setDatos.Tables[0];
                cantidadDeInversionistas = tablaInversiones.Columns.Count - 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show("Asegurese que la tabla de origen de pedidos se llame 'Cristobal' ");
            }

        }

        public void getConnectionString()
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.pathArchivoExcelOrigen + "; Extended Properties=" + "\"" + "Excel 12.0 Xml;HDR=YES" + "\"";
            return;
        }

        public void realizarCruce(classIndividuoInversiones individuo1, classIndividuoInversiones individuo2, int porcentajePunto)
        {
            int puntoCruce = Convert.ToInt32(Math.Floor(Convert.ToDouble(individuo1.genes.Length) * Convert.ToDouble(porcentajePunto / 100.0f)));
            int[] genesDeApoyo = new int[individuo1.genes.Length];
            for (int x = 0; x < genesDeApoyo.Length; x++)
            {
                genesDeApoyo[x] = individuo1.genes[x];
            }

            for (int x = puntoCruce; x < genesDeApoyo.Length; x++)
            {
                individuo1.genes[x] = individuo2.genes[x];
                individuo2.genes[x] = genesDeApoyo[x]; 
            }
        }

        public string getPathExcel()
        {
            try
            {
                dialogoParaArchivo.Filter = "Excel Files|*.xlsx;";
                //dialogoParaArchivo.InitialDirectory = @"C:\";
                dialogoParaArchivo.Title = "Selección de archivo de pedidos";
                dialogoParaArchivo.CheckFileExists = true;
                dialogoParaArchivo.CheckPathExists = true;



                if (dialogoParaArchivo.ShowDialog() == DialogResult.OK)
                {

                    pathArchivoExcelOrigen = dialogoParaArchivo.FileName;
                    //MessageBox.Show("El path es : " + pathArchivoExcelOrigenPedidos);
                    return pathArchivoExcelOrigen;
                }
                else
                {
                    MessageBox.Show("Error al intentar abrir el archivo de Origen");
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            agregarIndicesDeIteracionAComboBox();
            botonCalcularSolucion.Enabled = false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxMejorGenes.Text = "";
            textBoxMejorEvaluacion.Text = ""; 
            int indiceMejor = 0; 
            try
            {
                indiceMejor = Convert.ToInt16(comboBox1.Text);
                if ((indiceMejor < 1) || (indiceMejor > iteraciones))
                {
                    MessageBox.Show("Introduce un valor existente en las iteraciones");
                    return; 
                }
            }
            catch (Exception ex){
                MessageBox.Show("Introduce un valor existente en las iteraciones");
                return; 
            }

            for (int x = 0; x < mejoresIndividuosPorIteracion[indiceMejor-1].genes.Length; x++)
            {
                textBoxMejorGenes.Text += mejoresIndividuosPorIteracion[indiceMejor-1].genes[x] + ""; 
            }
            textBoxMejorEvaluacion.Text = mejoresIndividuosPorIteracion[indiceMejor - 1].evaluacion.ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Primero obtenemos la tabla de inversionistas desde el excel 
            obtenerTablaInversionistas(); 
        }

       
    }
}
