namespace Lab1
{
    partial class dichotomyForm
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
            this.pvGraph = new OxyPlot.WindowsForms.PlotView();
            this.function = new System.Windows.Forms.TextBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.FirstIntervalLimitation = new System.Windows.Forms.TextBox();
            this.SecondIntervalLimitation = new System.Windows.Forms.TextBox();
            this.functionLabel = new System.Windows.Forms.Label();
            this.limitationLabel = new System.Windows.Forms.Label();
            this.leftLabel = new System.Windows.Forms.Label();
            this.rightLabel = new System.Windows.Forms.Label();
            this.SetIntervalButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.epsilonBox = new System.Windows.Forms.TextBox();
            this.LimitationBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pvGraph
            // 
            this.pvGraph.Location = new System.Drawing.Point(312, 12);
            this.pvGraph.Name = "pvGraph";
            this.pvGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvGraph.Size = new System.Drawing.Size(476, 413);
            this.pvGraph.TabIndex = 2;
            this.pvGraph.Text = "plotView1";
            this.pvGraph.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvGraph.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvGraph.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // function
            // 
            this.function.Location = new System.Drawing.Point(30, 29);
            this.function.Name = "function";
            this.function.Size = new System.Drawing.Size(276, 20);
            this.function.TabIndex = 3;
            this.function.Text = "x +1";
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(231, 55);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 4;
            this.DrawButton.Text = "Построить";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // FirstIntervalLimitation
            // 
            this.FirstIntervalLimitation.Location = new System.Drawing.Point(30, 125);
            this.FirstIntervalLimitation.Name = "FirstIntervalLimitation";
            this.FirstIntervalLimitation.Size = new System.Drawing.Size(69, 20);
            this.FirstIntervalLimitation.TabIndex = 5;
            this.FirstIntervalLimitation.Text = "-2";
            // 
            // SecondIntervalLimitation
            // 
            this.SecondIntervalLimitation.Location = new System.Drawing.Point(121, 125);
            this.SecondIntervalLimitation.Name = "SecondIntervalLimitation";
            this.SecondIntervalLimitation.Size = new System.Drawing.Size(69, 20);
            this.SecondIntervalLimitation.TabIndex = 6;
            this.SecondIntervalLimitation.Text = "0";
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Location = new System.Drawing.Point(30, 10);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(83, 13);
            this.functionLabel.TabIndex = 7;
            this.functionLabel.Text = "Ваша функция:";
            // 
            // limitationLabel
            // 
            this.limitationLabel.AutoSize = true;
            this.limitationLabel.Location = new System.Drawing.Point(74, 83);
            this.limitationLabel.Name = "limitationLabel";
            this.limitationLabel.Size = new System.Drawing.Size(132, 13);
            this.limitationLabel.TabIndex = 8;
            this.limitationLabel.Text = "Ограничение интервала:";
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Location = new System.Drawing.Point(30, 109);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(39, 13);
            this.leftLabel.TabIndex = 9;
            this.leftLabel.Text = "Левое";
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Location = new System.Drawing.Point(118, 109);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(45, 13);
            this.rightLabel.TabIndex = 10;
            this.rightLabel.Text = "Правое";
            // 
            // SetIntervalButton
            // 
            this.SetIntervalButton.Location = new System.Drawing.Point(221, 122);
            this.SetIntervalButton.Name = "SetIntervalButton";
            this.SetIntervalButton.Size = new System.Drawing.Size(75, 23);
            this.SetIntervalButton.TabIndex = 11;
            this.SetIntervalButton.Text = "Задать";
            this.SetIntervalButton.UseVisualStyleBackColor = true;
            this.SetIntervalButton.Click += new System.EventHandler(this.SetIntervalButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "x +1";
            // 
            // epsilonBox
            // 
            this.epsilonBox.Location = new System.Drawing.Point(30, 181);
            this.epsilonBox.Name = "epsilonBox";
            this.epsilonBox.Size = new System.Drawing.Size(69, 20);
            this.epsilonBox.TabIndex = 13;
            this.epsilonBox.Text = "0,1";
            // 
            // LimitationBox
            // 
            this.LimitationBox.Location = new System.Drawing.Point(30, 235);
            this.LimitationBox.Name = "LimitationBox";
            this.LimitationBox.Size = new System.Drawing.Size(69, 20);
            this.LimitationBox.TabIndex = 14;
            this.LimitationBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Epsilon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Необходимая точность (число знаков после запятой)";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(30, 326);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(69, 20);
            this.resultBox.TabIndex = 17;
            this.resultBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Результат";
            // 
            // dichotomyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LimitationBox);
            this.Controls.Add(this.epsilonBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SetIntervalButton);
            this.Controls.Add(this.rightLabel);
            this.Controls.Add(this.leftLabel);
            this.Controls.Add(this.limitationLabel);
            this.Controls.Add(this.functionLabel);
            this.Controls.Add(this.SecondIntervalLimitation);
            this.Controls.Add(this.FirstIntervalLimitation);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.function);
            this.Controls.Add(this.pvGraph);
            this.Name = "dichotomyForm";
            this.Text = "Метод Дихотомии";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public OxyPlot.WindowsForms.PlotView pvGraph;
        private System.Windows.Forms.TextBox function;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.TextBox FirstIntervalLimitation;
        private System.Windows.Forms.TextBox SecondIntervalLimitation;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Label limitationLabel;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Button SetIntervalButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox epsilonBox;
        private System.Windows.Forms.TextBox LimitationBox;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Label label3;
    }
}