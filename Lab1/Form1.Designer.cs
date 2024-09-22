namespace Lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dichotomyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dichotomyButton
            // 
            this.dichotomyButton.Location = new System.Drawing.Point(45, 52);
            this.dichotomyButton.Name = "dichotomyButton";
            this.dichotomyButton.Size = new System.Drawing.Size(75, 42);
            this.dichotomyButton.TabIndex = 0;
            this.dichotomyButton.Text = "Метод Дихотомии";
            this.dichotomyButton.UseVisualStyleBackColor = true;
            this.dichotomyButton.Click += new System.EventHandler(this.dichotomyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 497);
            this.Controls.Add(this.dichotomyButton);
            this.Name = "MainForm";
            this.Text = "Приложение";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dichotomyButton;
    }
}

