namespace Desktop_App
{
    partial class CarList
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
            this.Delete = new System.Windows.Forms.Button();
            this.detailButton = new System.Windows.Forms.Button();
            this.carListBox = new System.Windows.Forms.ListBox();
            this.import = new System.Windows.Forms.Button();
            this.sync = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.EmployeeLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(702, 84);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(86, 23);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Smazat";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // detailButton
            // 
            this.detailButton.Location = new System.Drawing.Point(702, 46);
            this.detailButton.Name = "detailButton";
            this.detailButton.Size = new System.Drawing.Size(86, 23);
            this.detailButton.TabIndex = 6;
            this.detailButton.Text = "Detail";
            this.detailButton.UseVisualStyleBackColor = true;
            // 
            // carListBox
            // 
            this.carListBox.FormattingEnabled = true;
            this.carListBox.Location = new System.Drawing.Point(208, 46);
            this.carListBox.Name = "carListBox";
            this.carListBox.Size = new System.Drawing.Size(469, 303);
            this.carListBox.TabIndex = 5;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(521, 372);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 8;
            this.import.Text = "Import XML";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // sync
            // 
            this.sync.Location = new System.Drawing.Point(521, 401);
            this.sync.Name = "sync";
            this.sync.Size = new System.Drawing.Size(75, 23);
            this.sync.TabIndex = 9;
            this.sync.Text = "Sync";
            this.sync.UseVisualStyleBackColor = true;
            this.sync.Click += new System.EventHandler(this.sync_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(602, 372);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 10;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(702, 326);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(86, 23);
            this.clear.TabIndex = 11;
            this.clear.Text = "Vyčistit";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // EmployeeLink
            // 
            this.EmployeeLink.AutoSize = true;
            this.EmployeeLink.Location = new System.Drawing.Point(26, 37);
            this.EmployeeLink.Name = "EmployeeLink";
            this.EmployeeLink.Size = new System.Drawing.Size(105, 13);
            this.EmployeeLink.TabIndex = 12;
            this.EmployeeLink.TabStop = true;
            this.EmployeeLink.Text = "Seznam zaměstanců";
            this.EmployeeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EmployeeLink_LinkClicked);
            // 
            // CarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EmployeeLink);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.export);
            this.Controls.Add(this.sync);
            this.Controls.Add(this.import);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.detailButton);
            this.Controls.Add(this.carListBox);
            this.Name = "CarList";
            this.Text = "CarList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button detailButton;
        private System.Windows.Forms.ListBox carListBox;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button sync;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.LinkLabel EmployeeLink;
    }
}