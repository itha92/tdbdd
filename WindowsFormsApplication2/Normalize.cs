using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Normalization
{

    public partial class Normalize : Form
    {
        ArrayList Columnas = new ArrayList();
        List<List<String>> Relaciones = new List<List<String>>();
        String PK = "";
        String LeftRelation = "";
        String RightRelation = "";
        List<List<String>> Rs = new List<List<String>>();
        List<String> PKPermutations = new List<String>();//Primary Key Permutations
        String Message2FN = "";
        String Message3FN = "";

        public Normalize()
        {
            InitializeComponent();
        }

        private void SetColumns_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < Columnas.Count; i++)
            {
                listLeft.Items.Add(Columnas[i]);
                listRight.Items.Add(Columnas[i]);   
            }
            
            Columns.Enabled = false;
            SetColumns.Enabled = false;
            
        }

        private void Columns_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !e.KeyChar.ToString().Equals(",");
            
            if (char.IsLetter(e.KeyChar)){
            
                Columnas.Add(e.KeyChar.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (LeftRelation == "" || RightRelation == "")
            {
                MessageBox.Show("Por favor eliga una opcion de cada lista de relaciones");
            }
            else
            {
                listRelaciones.Items.Add(TBLeft.Text + "----->" + TBRight.Text);
                TBLeft.Text = "";
                TBRight.Text = "";
                LeftRelation = LeftRelation.Remove(LeftRelation.Length - 1);
                RightRelation = RightRelation.Remove(RightRelation.Length - 1);


                Boolean Exists = false;

                for (int i = 0; i < Relaciones.Count; i++)
                {
                    if (Relaciones[i][0] == LeftRelation)
                    {
                        Exists = true;
                        Relaciones[i].Add(RightRelation);
                    }

                }

                if (!Exists)
                {
                    List<String> temp = new List<string>();
                    temp.Add(LeftRelation);
                    temp.Add(RightRelation);
                    Relaciones.Add(temp);
                }

                LeftRelation = "";
                RightRelation = "";

            }
            LeftRelation = "";
            RightRelation = "";
            TBLeft.Text = "";
            TBRight.Text = "";
        }

        private void listLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TBLeft.Text.Equals("")){

                TBLeft.Text += listLeft.SelectedItem.ToString();

            }
            else{
                
                TBLeft.Text += ',' + listLeft.SelectedItem.ToString();

            }
        }

        private void listRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TBRight.Text.Equals("")){

                TBRight.Text += listRight.SelectedItem.ToString();

            }
            else{
            
                TBRight.Text += ',' + listRight.SelectedItem.ToString();

            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            Message2FN = "";
            Message3FN = "";
            TBKey.Text = "";   
            PK = "";
            LeftRelation = "";
            RightRelation = "";
            Rs.Clear();
            PKPermutations.Clear();
            Columnas.Clear();
            Relaciones.Clear();
            Columns.Text = "";
            TBLeft.Text = "";
            TBRight.Text = "";
            listLeft.Items.Clear();
            listRight.Items.Clear();
            listRelaciones.Items.Clear();
            Columns.Enabled = true;
            SetColumns.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Normalization2FN();
            Normalization3FN();
            MessageBox.Show(Message2FN + Message3FN);
        }

        private void TBKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            PK += e.KeyChar.ToString();
        }

        private void TBLeft_TextChanged(object sender, EventArgs e)
        {
            LeftRelation += listLeft.SelectedItem;
        }

        private void TBRight_TextChanged(object sender, EventArgs e)
        {
            RightRelation += listRight.SelectedItem;
        }

        private void Normalization2FN() {

            Boolean PKhasDT = false;//Boolean que determina si la primary key tiene dependencias totales
            List<String> temp = new List<string>();

            //-------------------------for que verifica si la llave primaria tiene dependencias totales-------------------------
            for (int i = 0; i < Relaciones.Count; i++){
                if (Relaciones[i][0] == PK)
                {
                    PKhasDT = true;
                    
                    temp.Add(PK);
                    for (int j = 1; j < Relaciones[i].Count; j++)
                    {
                        temp = GetDependencies(temp, Relaciones[i][j]);
                    }
                    Rs.Add(temp);
                }
            }//fin for
            if (!PKhasDT)
            {
                temp = new List<string>();
                temp.Add(PK);
                Rs.Add(temp);
            }//fin if

            //--------------------------For que revisa todas las permutaciones de la PK para ver si hay dependencias no totales-------------------------
            
            Combinations Comb = new Combinations(PK);
            PKPermutations = Comb.GetPermutations();

            for (int i = 0; i < PKPermutations.Count; i++){

                for (int j = 0; j < Relaciones.Count; j++){

                    if(!(PKPermutations[i]==PK)){
                        
                        if (Relaciones[j][0] == PKPermutations[i])
                        {
                            temp = new List<string>();
                            temp.Add(PKPermutations[i]);
                            
                            for (int k = 1; k < Relaciones[j].Count; k++)
                            {
                                temp = GetDependencies(temp, Relaciones[j][k]);

                            }//fin for

                            Rs.Add(temp);

                        }//fin if

                    }//fin if

                }//fin for

            }//fin for


            Message2FN = "-----------SEGUNDA FORMA NORMAL-----------\n";
            for (int i = 0; i < Rs.Count; i++)
            {
                Message2FN += "R" + (i + 1) + " (" + Rs[i][0] + ",";
                for (int j = 1; j < Rs[i].Count; j++)
                {
                    Message2FN += Rs[i][j] + ",";
                }
                Message2FN += ")\n";
            }
            

        }

        private void Normalization3FN(){
            
            List<String> temp = new List<string>();
            Boolean DeleteRS2FN = false;
            Boolean isTrue = false;
            ArrayList DeletePos = new ArrayList();
            String test = "";
            String test2 = "";

            for (int i = 0; i < Rs.Count; i++)
            {
                if(Rs[i].Count>2){

                    for (int K = 1; K < Rs[i].Count; K++)
                    {
                        temp = new List<string>();
                    for (int j = K+1; j < Rs[i].Count; j++)
                    {

                         isTrue = isDependency(Rs[i][K], Rs[i][j]);
                        
                        if(isTrue){
                            
                            if(!DeleteRS2FN){

                                test = Rs[i][K];
                            temp.Add(test);

                            }//fin if
                            test2 = Rs[i][j];
                            temp.Add(test2);
                            DeletePos.Add(j);
                            DeleteRS2FN = true;

                        }//fin if

                    }//fin for
                    if (DeleteRS2FN)
                    {
                        Rs.Add(temp);

                        for (int j = 0; j < DeletePos.Count; j++)
                        {

                            Rs[i].RemoveAt((int)DeletePos[j]);

                        }

                        DeletePos.Clear();
                        temp = new List<string>();
                        DeleteRS2FN = false;
                    }
                    

                        

                    }//fin for

                }//fin if
            }//fin for   

            Message3FN = "-----------TERCERA FORMA NORMAL-----------\n";
            int cont = 0;
            for (int i = 0; i < Rs.Count; i++)
            {
                Message3FN += "R" + (i + 1) + " (" + Rs[i][0] + ",";
                for (int j = 1; j < Rs[i].Count; j++)
                {
                    Message3FN += Rs[i][j] + ",";
                    cont = i + 1;
                }
                Message3FN += ")\n";
            }

        }

        private Boolean isDependency(String CurrentAttribute, String DefinedAttribute) {

            for (int i = 0; i < Relaciones.Count; i++)
            {
                if (Relaciones[i][0] == CurrentAttribute)
                {
                    for (int j = 1; j < Relaciones[i].Count; j++)
                    {
                        if(Relaciones[i][j] == DefinedAttribute){
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private List<String> GetDependencies(List<String> temp, String CurrentAttribute) {

            temp.Add(CurrentAttribute);

            for (int i = 0; i < Relaciones.Count; i++)
            {
                if (Relaciones[i][0] == CurrentAttribute)
                {
                    for (int j = 1; j < Relaciones[i].Count; j++)
                    {
                        temp = GetDependencies(temp, Relaciones[i][j]);
                    }
                }
            }

            return temp;
        }
    }
}
