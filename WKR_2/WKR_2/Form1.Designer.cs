namespace WKR_2
{
    partial class main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.deutsch = new System.Windows.Forms.Button();
            this.algorithmGrover = new System.Windows.Forms.Button();
            this.algorithmShora = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deutsch
            // 
            this.deutsch.BackColor = System.Drawing.Color.SteelBlue;
            this.deutsch.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.deutsch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.deutsch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.deutsch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deutsch.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.deutsch.Location = new System.Drawing.Point(122, 87);
            this.deutsch.Name = "deutsch";
            this.deutsch.Size = new System.Drawing.Size(171, 28);
            this.deutsch.TabIndex = 0;
            this.deutsch.Text = "Алгоритм Дойча";
            this.deutsch.UseVisualStyleBackColor = false;
            this.deutsch.Click += new System.EventHandler(this.deutsch_Click);
            // 
            // algorithmGrover
            // 
            this.algorithmGrover.BackColor = System.Drawing.Color.SteelBlue;
            this.algorithmGrover.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.algorithmGrover.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.algorithmGrover.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.algorithmGrover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.algorithmGrover.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.algorithmGrover.Location = new System.Drawing.Point(122, 137);
            this.algorithmGrover.Name = "algorithmGrover";
            this.algorithmGrover.Size = new System.Drawing.Size(171, 28);
            this.algorithmGrover.TabIndex = 1;
            this.algorithmGrover.Text = "Алгоритм Гровера";
            this.algorithmGrover.UseVisualStyleBackColor = false;
            this.algorithmGrover.Click += new System.EventHandler(this.algorithmGrover_Click);
            // 
            // algorithmShora
            // 
            this.algorithmShora.BackColor = System.Drawing.Color.SteelBlue;
            this.algorithmShora.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.algorithmShora.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.algorithmShora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.algorithmShora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.algorithmShora.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.algorithmShora.Location = new System.Drawing.Point(122, 184);
            this.algorithmShora.Name = "algorithmShora";
            this.algorithmShora.Size = new System.Drawing.Size(171, 28);
            this.algorithmShora.TabIndex = 2;
            this.algorithmShora.Text = "Алгоритм Шора";
            this.algorithmShora.UseVisualStyleBackColor = false;
            this.algorithmShora.Click += new System.EventHandler(this.algorithmShora_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.SteelBlue;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.exit.Location = new System.Drawing.Point(343, 265);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(86, 26);
            this.exit.TabIndex = 3;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button1.Location = new System.Drawing.Point(12, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "О программе";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(441, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.algorithmShora);
            this.Controls.Add(this.algorithmGrover);
            this.Controls.Add(this.deutsch);
            this.Name = "main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deutsch;
        private System.Windows.Forms.Button algorithmGrover;
        private System.Windows.Forms.Button algorithmShora;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button button1;
    }
}

