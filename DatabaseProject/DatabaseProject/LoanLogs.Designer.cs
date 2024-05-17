namespace DatabaseProject
{
    partial class LoanLogs
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
            this.datagridLoanLogs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridLoanLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridLoanLogs
            // 
            this.datagridLoanLogs.AllowUserToAddRows = false;
            this.datagridLoanLogs.AllowUserToDeleteRows = false;
            this.datagridLoanLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridLoanLogs.Location = new System.Drawing.Point(95, 85);
            this.datagridLoanLogs.Name = "datagridLoanLogs";
            this.datagridLoanLogs.ReadOnly = true;
            this.datagridLoanLogs.RowHeadersWidth = 51;
            this.datagridLoanLogs.RowTemplate.Height = 24;
            this.datagridLoanLogs.Size = new System.Drawing.Size(574, 311);
            this.datagridLoanLogs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loan Logs";
            // 
            // LoanLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridLoanLogs);
            this.Name = "LoanLogs";
            this.Text = "LoanLogs";
            this.Load += new System.EventHandler(this.LoanLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridLoanLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridLoanLogs;
        private System.Windows.Forms.Label label1;
    }
}