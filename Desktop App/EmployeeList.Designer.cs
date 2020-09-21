namespace Desktop_App
{
    partial class UserList
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
            this.employeeListBox = new System.Windows.Forms.ListBox();
            this.detailButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.CalcSalary = new System.Windows.Forms.Button();
            this.calcAllSalary = new System.Windows.Forms.Button();
            this.CarListLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // employeeListBox
            // 
            this.employeeListBox.FormattingEnabled = true;
            this.employeeListBox.Location = new System.Drawing.Point(174, 37);
            this.employeeListBox.Name = "employeeListBox";
            this.employeeListBox.Size = new System.Drawing.Size(233, 303);
            this.employeeListBox.TabIndex = 0;
            // 
            // detailButton
            // 
            this.detailButton.Location = new System.Drawing.Point(451, 79);
            this.detailButton.Name = "detailButton";
            this.detailButton.Size = new System.Drawing.Size(86, 23);
            this.detailButton.TabIndex = 1;
            this.detailButton.Text = "Detail";
            this.detailButton.UseVisualStyleBackColor = true;
            this.detailButton.Click += new System.EventHandler(this.detailButton_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(451, 121);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(86, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Smazat";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // CalcSalary
            // 
            this.CalcSalary.Location = new System.Drawing.Point(451, 37);
            this.CalcSalary.Name = "CalcSalary";
            this.CalcSalary.Size = new System.Drawing.Size(86, 23);
            this.CalcSalary.TabIndex = 3;
            this.CalcSalary.Text = "Výpočet mzdy";
            this.CalcSalary.UseVisualStyleBackColor = true;
            this.CalcSalary.Click += new System.EventHandler(this.CalcSalary_Click);
            // 
            // calcAllSalary
            // 
            this.calcAllSalary.Location = new System.Drawing.Point(174, 375);
            this.calcAllSalary.Name = "calcAllSalary";
            this.calcAllSalary.Size = new System.Drawing.Size(233, 23);
            this.calcAllSalary.TabIndex = 4;
            this.calcAllSalary.Text = "Výpočet mzdy pro všechny zaměstnance";
            this.calcAllSalary.UseVisualStyleBackColor = true;
            this.calcAllSalary.Click += new System.EventHandler(this.calcAllSalary_Click);
            // 
            // CarListLink
            // 
            this.CarListLink.AutoSize = true;
            this.CarListLink.Location = new System.Drawing.Point(27, 41);
            this.CarListLink.Name = "CarListLink";
            this.CarListLink.Size = new System.Drawing.Size(63, 13);
            this.CarListLink.TabIndex = 5;
            this.CarListLink.TabStop = true;
            this.CarListLink.Text = "Seznam aut";
            this.CarListLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CarListLink_LinkClicked);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CarListLink);
            this.Controls.Add(this.calcAllSalary);
            this.Controls.Add(this.CalcSalary);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.detailButton);
            this.Controls.Add(this.employeeListBox);
            this.Name = "UserList";
            this.Text = "EmployeeList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox employeeListBox;
        private System.Windows.Forms.Button detailButton;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button CalcSalary;
        private System.Windows.Forms.Button calcAllSalary;
        private System.Windows.Forms.LinkLabel CarListLink;
    }
}