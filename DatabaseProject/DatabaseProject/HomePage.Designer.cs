namespace DatabaseProject
{
    partial class HomePage
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
            this.UpdateProfileButton = new System.Windows.Forms.Button();
            this.AddBankButton = new System.Windows.Forms.Button();
            this.AddBankBranchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpdateProfileButton
            // 
            this.UpdateProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateProfileButton.Location = new System.Drawing.Point(69, 57);
            this.UpdateProfileButton.Name = "UpdateProfileButton";
            this.UpdateProfileButton.Size = new System.Drawing.Size(173, 34);
            this.UpdateProfileButton.TabIndex = 0;
            this.UpdateProfileButton.Text = "Update profile";
            this.UpdateProfileButton.UseVisualStyleBackColor = true;
            this.UpdateProfileButton.Click += new System.EventHandler(this.UpdateProfileButton_Click);
            // 
            // AddBankButton
            // 
            this.AddBankButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBankButton.Location = new System.Drawing.Point(69, 116);
            this.AddBankButton.Name = "AddBankButton";
            this.AddBankButton.Size = new System.Drawing.Size(173, 34);
            this.AddBankButton.TabIndex = 1;
            this.AddBankButton.Text = "Add Bank";
            this.AddBankButton.UseVisualStyleBackColor = true;
            this.AddBankButton.Click += new System.EventHandler(this.AddBankButton_Click);
            // 
            // AddBankBranchButton
            // 
            this.AddBankBranchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBankBranchButton.Location = new System.Drawing.Point(69, 180);
            this.AddBankBranchButton.Name = "AddBankBranchButton";
            this.AddBankBranchButton.Size = new System.Drawing.Size(173, 34);
            this.AddBankBranchButton.TabIndex = 2;
            this.AddBankBranchButton.Text = "Add Bank Branch";
            this.AddBankBranchButton.UseVisualStyleBackColor = true;
            this.AddBankBranchButton.Click += new System.EventHandler(this.AddBankBranchButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddBankBranchButton);
            this.Controls.Add(this.AddBankButton);
            this.Controls.Add(this.UpdateProfileButton);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateProfileButton;
        private System.Windows.Forms.Button AddBankButton;
        private System.Windows.Forms.Button AddBankBranchButton;
    }
}