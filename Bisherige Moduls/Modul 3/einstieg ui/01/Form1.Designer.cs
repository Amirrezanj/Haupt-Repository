namespace _01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Zahl1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            Zahl2 = new TextBox();
            Ergebnis = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // Zahl1
            // 
            Zahl1.AutoSize = true;
            Zahl1.Location = new Point(111, 154);
            Zahl1.Name = "Zahl1";
            Zahl1.Size = new Size(36, 15);
            Zahl1.TabIndex = 1;
            Zahl1.Text = "Zahl1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(64, 189);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(136, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(400, 154);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Zahl2";
            // 
            // Zahl2
            // 
            Zahl2.Location = new Point(345, 189);
            Zahl2.Name = "Zahl2";
            Zahl2.Size = new Size(136, 23);
            Zahl2.TabIndex = 4;
            // 
            // Ergebnis
            // 
            Ergebnis.AutoSize = true;
            Ergebnis.Location = new Point(256, 345);
            Ergebnis.Name = "Ergebnis";
            Ergebnis.Size = new Size(0, 15);
            Ergebnis.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(206, 261);
            button1.Name = "button1";
            button1.Size = new Size(106, 57);
            button1.TabIndex = 6;
            button1.Text = "BerechneGGt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(Ergebnis);
            Controls.Add(Zahl2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(Zahl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GGTB;
        private Label Zahl1;
        private TextBox textBox1;
        private Label label2;
        private TextBox Zahl2;
        private Label Ergebnis;
        private Button button1;
    }
}
