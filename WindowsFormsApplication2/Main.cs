using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Normalizar;
using System.Net;
using System.IO;
using DB_Normalization;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int contador_entidades = 0;
        public int[][] matriz;
        public List<string> entidades;
        private List<Nodo> relaciones;
        public bool creada = false;

        public List<string> relationships;
        string attr2 = " ";

        private void button1_Click(object sender, EventArgs e)
        {

            if (!txt_df1.Text.Contains(comboBox1.SelectedItem.ToString()))
            {
                txt_df1.Text += comboBox1.SelectedItem + ",";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_relacion.Text != "")
            {
                ComboboxItem i;
                entidades = new List<string>(txt_relacion.Text.Split(','));
                foreach (string str in entidades)
                {
                    i = new ComboboxItem();
                    i.text = str;
                    i.val = str;
                    comboBox1.Items.Add(i);
                    comboBox2.Items.Add(i);
                }

                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 1;
                
                this.button2.Enabled = false;
                relaciones = new List<Nodo>();
                relationships = new List<string>();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!txt_df2.Text.Contains(comboBox2.SelectedItem.ToString()))
            {
                txt_df2.Text += comboBox2.SelectedItem + ",";
            }

            //string tmp = txt_df2.Text;
            //tmp = comboBox2.SelectedItem + ",";
            //txt_df2.Text += tmp ;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
             //--------------------------------------------------------------------

            string[] attr_tmp = txt_relacion.Text.Split(',');

            attr_tmp = txt_df1.Text.Split(',');

            for (int j = 0; j < attr_tmp.Length; j++)
            {
                attr2 += attr_tmp[j] + " ";
            }

            Console.WriteLine(attr2);

            attr2 += "-> ";

            attr_tmp = txt_df2.Text.Split(',');

            for (int j = 0; j < attr_tmp.Length; j++)
            {
                attr2 += attr_tmp[j] + "";
            }

            attr2 += ",";
            Console.WriteLine(attr2);


            //-----------------------------------------------------------------------
            listBox1.Items.Add(txt_df1.Text.Remove(txt_df1.Text.Length - 1, 1) + "->" + txt_df2.Text.Remove(txt_df2.Text.Length - 1, 1));
            
            
            contador_entidades++;

            Nodo n = new Nodo();
            n.l_izq = new List<string>(txt_df1.Text.Remove(txt_df1.Text.Length - 1, 1).Split(','));
            n.l_der = new List<string>(txt_df2.Text.Remove(txt_df2.Text.Length - 1, 1).Split(','));


            relaciones.Add(n);

            txt_df1.Text = "";
            txt_df2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Cierre_Transitivo();
            
            //Habilitar_botones(false);
           
            //if (!this.creada)
            //{
            //    int size = entidades.Count;
            //    matriz = new int[contador_entidades][];

            //    for (int k = 0; k < matriz.Length; k++)
            //    {
            //        matriz[k] = new int[size];
            //    }
            //}
            //this.creada = true;

            ////llenar matriz con 1

            //int index1 = 0;
            //int index2 = 0;

            //foreach (Nodo n in relaciones)
            //{
            //    index1 = relaciones.IndexOf(n);
            //    foreach (string s in n.l_izq)
            //    {
            //        index2 = entidades.IndexOf(s);
            //        matriz[index1][index2] = 1;
            //    }
            //    foreach (string s in n.l_der)
            //    {
            //        index2 = entidades.IndexOf(s);
            //        matriz[index1][index2] = 1;
            //    }
            //}


            //ImprimirMatriz(matriz);


        }

        //imprimir matriz

        public void ImprimirMatriz(int[][] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
              
                for (int j = 0; j < m[0].Length; j++)
                {

                    Console.Write("[" + m[i][j] + "]");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Habilitar_botones(true);
        }

        /**limpiar el form dependiendo de la accion
         * Si solo se quieren desactivar los botones se llama:
         * Habilitar_botones(false);
         * si se quiere limipiar todo:
         * Habilitar_botones(true);
         */

        public void Habilitar_botones(bool habilitar)
        {
            button1.Enabled = habilitar;
            button2.Enabled = habilitar;
            button9.Enabled = habilitar;
            button10.Enabled = habilitar;
            comboBox1.Enabled = habilitar;
            comboBox2.Enabled = habilitar;

            if (habilitar)
            {
                txt_df1.Text = "";
                txt_df2.Text = "";
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                listBox1.Items.Clear();
                txt_relacion.Text = "";

                creada = false;
                entidades = new List<string>();
            }
        }

        public void Cierre_Transitivo()
        {

            string[] attr_tmp = txt_relacion.Text.Split(',');
            string attr = "";
            for (int j = 0; j < attr_tmp.Length; j++)
            {
                attr += attr_tmp[j] + " ";
            }

            // A C -> B, C -> D E, B -> A

            //string arr2 = txt_df1.Text.Remove(txt_df1.Text.Length - 1, 1) + "->" + txt_df2.Text.Remove(txt_df2.Text.Length - 1, 1);
            
            //attr_tmp = txt_df1.Text.Remove(txt_df1.Text.Length - 1, 1).Split(',');

            //for (int j = 0; j < attr_tmp.Length; j++)
            //{
            //    attr2 += attr_tmp[j] + " ";
            //}

            //attr2 += "-> ";

            //attr_tmp = txt_df2.Text.Remove(txt_df2.Text.Length - 1, 1).Split(',');

            //for (int j = 0; j < attr_tmp.Length; j++)
            //{
            //    attr2 += attr_tmp[j] + " ";
            //}

            attr2 = attr2.Remove(attr2.Length - 1, 1);
            
            try
            {
                string url = "http://www.koffeinhaltig.com/fds/kandidatenschluessel.php?attrs=" + attr + "&fds=" + attr2 + "&language=en";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream resStream = response.GetResponseStream();

                StreamReader sr = new StreamReader(resStream);

                string sLine = "";
                string resp = "";
                int i = 0;
                int cont = 0;
                while (sLine != null)
                {
                    i++;
                    sLine = sr.ReadLine();
                    if (sLine != null)
                    {
                        cont++;
                        //Console.WriteLine(i+":"+  sLine);
                        resp += sLine + "\n";
                    }
                }

                string respuesta = resp.Split('\n')[resp.Split('\n').Length - 6].Substring(28);

                MessageBox.Show(respuesta.Remove(respuesta.Length - 13), "Llaves candidatas");
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error, por favor intente de nuevo");
            }

            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Normalize n = new Normalize();
            n.ShowDialog(this);
        }
    
    }
}
