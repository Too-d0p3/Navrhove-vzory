namespace Desktop_App
{
    partial class SalaryView
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
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.Doklad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(234, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(554, 426);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // Doklad
            // 
            this.Doklad.Location = new System.Drawing.Point(37, 40);
            this.Doklad.Name = "Doklad";
            this.Doklad.Size = new System.Drawing.Size(75, 23);
            this.Doklad.TabIndex = 1;
            this.Doklad.Text = "Doklad";
            this.Doklad.UseVisualStyleBackColor = true;
            this.Doklad.Click += new System.EventHandler(this.Doklad_Click);
            // 
            // SalaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Doklad);
            this.Controls.Add(this.textBox);
            this.Name = "SalaryView";
            this.Text = "Salary";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button Doklad;
    }
}