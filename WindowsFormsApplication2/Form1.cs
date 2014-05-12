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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ListBoxItem lbi = new ListBoxItem(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            listBox1.Items.Add(lbi);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_relacion.Text != "")
            {
                ComboboxItem i;
                List<string> l = new List<string>(txt_relacion.Text.Split(','));
                foreach (string str in l)
                {
                    i = new ComboboxItem();
                    i.text = str;
                    i.val = str;
                    comboBox1.Items.Add(i);
                    comboBox2.Items.Add(i);
                }


                this.button2.Enabled = false;

            }
        }
    }
}
