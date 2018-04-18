namespace WKR
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deutsch
            // 
            this.deutsch.BackColor = System.Drawing.Color.Gainsboro;
            this.deutsch.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.deutsch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deutsch.Location = new System.Drawing.Point(168, 108);
            this.deutsch.Name = "deutsch";
            this.deutsch.Size = new System.Drawing.Size(171, 28);
            this.deutsch.TabIndex = 0;
            this.deutsch.Text = "Алгоритм Дойча";
            this.deutsch.UseVisualStyleBackColor = false;
            this.deutsch.Click += new System.EventHandler(this.deutsch_Click);
            // 
            // algorithmGrover
            // 
            this.algorithmGrover.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.algorithmGrover.Location = new System.Drawing.Point(168, 171);
            this.algorithmGrover.Name = "algorithmGrover";
            this.algorithmGrover.Size = new System.Drawing.Size(171, 28);
            this.algorithmGrover.TabIndex = 1;
            this.algorithmGrover.Text = "Алгоритм Гровера";
            this.algorithmGrover.UseVisualStyleBackColor = true;
            this.algorithmGrover.Click += new System.EventHandler(this.algorithmGrover_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button1.Location = new System.Drawing.Point(168, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Алгоритм Шора";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button2.Location = new System.Drawing.Point(12, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "О программе";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button3.Location = new System.Drawing.Point(427, 323);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(541, 358);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.algorithmGrover);
            this.Controls.Add(this.deutsch);
            this.Name = "main";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.SystemColors.WindowFrame;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deutsch;
        private System.Windows.Forms.Button algorithmGrover;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

    }
}

