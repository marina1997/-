namespace WKR_2
{
    partial class algorithm_Shora
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 168);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 241);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button1.Location = new System.Drawing.Point(143, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label1.Location = new System.Drawing.Point(382, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(179, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Алгоритм Шора";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.MaximumSize = new System.Drawing.Size(550, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(518, 40);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дано составное число N, необходимо определить произведением каких простых чисел о" +
    "но является";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.label4.Location = new System.Drawing.Point(8, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Введите число, котороее надо разложить";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.label5.Location = new System.Drawing.Point(8, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Введите количество кубитов";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.SteelBlue;
            this.back.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.back.Location = new System.Drawing.Point(12, 304);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(92, 27);
            this.back.TabIndex = 8;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.SteelBlue;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.exit.Location = new System.Drawing.Point(412, 304);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(92, 27);
            this.exit.TabIndex = 9;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.SteelBlue;
            this.button_clear.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button_clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button_clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button_clear.Location = new System.Drawing.Point(276, 304);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(92, 27);
            this.button_clear.TabIndex = 10;
            this.button_clear.Text = "Очистить";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.label6.Location = new System.Drawing.Point(330, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Результат разложения";
            // 
            // algorithm_Shora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(527, 343);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.back);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "algorithm_Shora";
            this.Text = "algorithm_Shora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label6;
    }
}