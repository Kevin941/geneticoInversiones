using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geneticoInversiones
{
    public class classIndividuoInversiones
    {
        static Random r = new Random();
        public OpenFileDialog dialogoParaArchivo = new OpenFileDialog();
        DataTable tablaInversiones = new DataTable();
        private string pathArchivoExcelOrigen; 
        public double evaluacion;
        int cantidadDeInversionistas; 
        public int[] genes;
        string connectionString;

        public classIndividuoInversiones(DataTable tabla, int cantidad)
        {
            tablaInversiones = tabla;
            cantidadDeInversionistas = cantidad; 
        }
        public void crearIndividuo()
        {
            genes = new int[cantidadDeInversionistas];
            
        }

        


        public void llenarIndividuoAleatoriamente()
        {
            
            for (int x = 0; x < genes.Length; x++)
            {
                
                int numero = r.Next(0, 2);
                
                genes[x] = numero; 

            }
        }
        public void limpiarIndividuo()
        {
            for (int x = 0; x < genes.Length; x++)
            {
                genes[x] = 0; 
            }
        }

        public void setPathExcel(string path)
        {
            pathArchivoExcelOrigen = path; 
        }
        public bool getPathExcelOrigen()
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

                    pathArchivoExcelOrigen= dialogoParaArchivo.FileName;
                    //MessageBox.Show("El path es : " + pathArchivoExcelOrigenPedidos);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al intentar abrir el archivo de Origen");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public void realizarMutacion(int porcentaje)
        {
            int cantidadMutaciones = Convert.ToInt32(Math.Floor(Convert.ToDouble(genes.Length) * Convert.ToDouble(porcentaje / 100.0f)));
            for (int x = 0; x < cantidadMutaciones; x++)
            {
                if (genes[x] == 0)
                {
                    genes[x] = 1; 
                }
                else if (genes[x] == 1)
                {
                    genes[x] = 0; 
                }
            }
        }

        public void obtenerEvaluacion()
        {
            double evaluacionAcumulada = 0; 
            for (int x = 0; x < genes.Length; x++)
            {
                if (genes[x] == 1)
                {
                    evaluacionAcumulada += getValorDeInversion(x);
                }
            }
            evaluacion = evaluacionAcumulada; 
        }

        public Double getValorDeInversion(int x)
        {
            return Convert.ToDouble(tablaInversiones.Rows[0][x+1].ToString()); 
        }
        public void getTablaInversiones()
        {
            try
            {
                OleDbConnection conexion = new OleDbConnection();
                this.getConnectionString();
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
            connectionString= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.pathArchivoExcelOrigen+ "; Extended Properties=" + "\"" + "Excel 12.0 Xml;HDR=YES" + "\"";
            return;
        }
        


        // La clase debe tener los siguientes métodos y atributos: 
        //obtenerEvaluación 
        //realizarCruce (Este método estará afuera de la clase, tomara como parámetro los 2 individuos y los cruzará) 
        //Realizar mutación (Determinar un porcentaje de mutación para mutar esa cantidad de genes y cambiarlos) 
        //Mantener el arreglo de individuos ordenado según su evaluación en todo momento. 
    }
}
