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
            this.SuspendLayout();
            // 
            // deutsch
            // 
            this.deutsch.BackColor = System.Drawing.Color.Gainsboro;
            this.deutsch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deutsch.Location = new System.Drawing.Point(70, 45);
            this.deutsch.Name = "deutsch";
            this.deutsch.Size = new System.Drawing.Size(160, 40);
            this.deutsch.TabIndex = 0;
            this.deutsch.Text = "Алгоритм Дойча";
            this.deutsch.UseVisualStyleBackColor = false;
            this.deutsch.Click += new System.EventHandler(this.deutsch_Click);
            // 
            // algorithmGrover
            // 
            this.algorithmGrover.Location = new System.Drawing.Point(70, 120);
            this.algorithmGrover.Name = "algorithmGrover";
            this.algorithmGrover.Size = new System.Drawing.Size(160, 23);
            this.algorithmGrover.TabIndex = 1;
            this.algorithmGrover.Text = "Алгоритм Гровера";
            this.algorithmGrover.UseVisualStyleBackColor = true;
            this.algorithmGrover.Click += new System.EventHandler(this.algorithmGrover_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(541, 358);
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

    }
}

