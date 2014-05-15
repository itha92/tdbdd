namespace DB_Normalization
{
    partial class Normalize
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
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TBKey = new System.Windows.Forms.TextBox();
            this.SetColumns = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listLeft = new System.Windows.Forms.ListBox();
            this.Columns = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listRight = new System.Windows.Forms.ListBox();
            this.listRelaciones = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBLeft = new System.Windows.Forms.TextBox();
            this.TBRight = new System.Windows.Forms.TextBox();
            this.ClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(225, 526);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 44;
            this.button5.Text = "Normalizar Tabla";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Clave Primaria";
            // 
            // TBKey
            // 
            this.TBKey.Location = new System.Drawing.Point(225, 500);
            this.TBKey.Name = "TBKey";
            this.TBKey.Size = new System.Drawing.Size(100, 20);
            this.TBKey.TabIndex = 42;
            this.TBKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBKey_KeyPress);
            // 
            // SetColumns
            // 
            this.SetColumns.Location = new System.Drawing.Point(387, 47);
            this.SetColumns.Name = "SetColumns";
            this.SetColumns.Size = new System.Drawing.Size(87, 20);
            this.SetColumns.TabIndex = 38;
            this.SetColumns.Text = "Ingresar";
            this.SetColumns.UseVisualStyleBackColor = true;
            this.SetColumns.Click += new System.EventHandler(this.SetColumns_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Define -->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listLeft
            // 
            this.listLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLeft.FormattingEnabled = true;
            this.listLeft.ItemHeight = 20;
            this.listLeft.Location = new System.Drawing.Point(73, 143);
            this.listLeft.Name = "listLeft";
            this.listLeft.Size = new System.Drawing.Size(108, 144);
            this.listLeft.TabIndex = 36;
            this.listLeft.SelectedIndexChanged += new System.EventHandler(this.listLeft_SelectedIndexChanged);
            // 
            // Columns
            // 
            this.Columns.Location = new System.Drawing.Point(78, 47);
            this.Columns.Name = "Columns";
            this.Columns.Size = new System.Drawing.Size(303, 20);
            this.Columns.TabIndex = 35;
            this.Columns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Columns_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Columnas";
            // 
            // listRight
            // 
            this.listRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listRight.FormattingEnabled = true;
            this.listRight.ItemHeight = 20;
            this.listRight.Location = new System.Drawing.Point(268, 143);
            this.listRight.Name = "listRight";
            this.listRight.Size = new System.Drawing.Size(108, 144);
            this.listRight.TabIndex = 48;
            this.listRight.SelectedIndexChanged += new System.EventHandler(this.listRight_SelectedIndexChanged);
            // 
            // listRelaciones
            // 
            this.listRelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listRelaciones.FormattingEnabled = true;
            this.listRelaciones.ItemHeight = 25;
            this.listRelaciones.Location = new System.Drawing.Point(129, 324);
            this.listRelaciones.Name = "listRelaciones";
            this.listRelaciones.Size = new System.Drawing.Size(231, 154);
            this.listRelaciones.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 24);
            this.label2.TabIndex = 50;
            this.label2.Text = "Relaciones Funcionales";
            // 
            // TBLeft
            // 
            this.TBLeft.Enabled = false;
            this.TBLeft.Location = new System.Drawing.Point(73, 102);
            this.TBLeft.Name = "TBLeft";
            this.TBLeft.Size = new System.Drawing.Size(108, 20);
            this.TBLeft.TabIndex = 51;
            this.TBLeft.TextChanged += new System.EventHandler(this.TBLeft_TextChanged);
            // 
            // TBRight
            // 
            this.TBRight.Enabled = false;
            this.TBRight.Location = new System.Drawing.Point(268, 102);
            this.TBRight.Name = "TBRight";
            this.TBRight.Size = new System.Drawing.Size(108, 20);
            this.TBRight.TabIndex = 52;
            this.TBRight.TextChanged += new System.EventHandler(this.TBRight_TextChanged);
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(411, 0);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(99, 31);
            this.ClearAll.TabIndex = 53;
            this.ClearAll.Text = "Reiniciar";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 582);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.TBRight);
            this.Controls.Add(this.TBLeft);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listRelaciones);
            this.Controls.Add(this.listRight);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TBKey);
            this.Controls.Add(this.SetColumns);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listLeft);
            this.Controls.Add(this.Columns);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBKey;
        private System.Windows.Forms.Button SetColumns;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listLeft;
        private System.Windows.Forms.TextBox Columns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listRight;
        private System.Windows.Forms.ListBox listRelaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBLeft;
        private System.Windows.Forms.TextBox TBRight;
        private System.Windows.Forms.Button ClearAll;


    }
}

