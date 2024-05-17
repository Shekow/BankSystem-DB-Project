namespace DatabaseProject
{
    partial class CustomerHomePage
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
            this.comboAccounts = new System.Windows.Forms.ComboBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AccountBalanceLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AccountBankCodeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AccountBranchNumberLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboLoanType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RequestLoanButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.AccountTypeLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AddAccountButton = new System.Windows.Forms.Button();
            this.comboLoanNumber = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AccountPendingBalanceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboAccounts
            // 
            this.comboAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAccounts.FormattingEnabled = true;
            this.comboAccounts.Location = new System.Drawing.Point(166, 103);
            this.comboAccounts.Name = "comboAccounts";
            this.comboAccounts.Size = new System.Drawing.Size(230, 37);
            this.comboAccounts.TabIndex = 0;
            this.comboAccounts.SelectedIndexChanged += new System.EventHandler(this.comboAccounts_SelectedIndexChanged);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.Location = new System.Drawing.Point(171, 19);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(73, 32);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Avaialble Balance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Welcome";
            // 
            // AccountBalanceLabel
            // 
            this.AccountBalanceLabel.AutoSize = true;
            this.AccountBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountBalanceLabel.ForeColor = System.Drawing.Color.Lime;
            this.AccountBalanceLabel.Location = new System.Drawing.Point(656, 164);
            this.AccountBalanceLabel.Name = "AccountBalanceLabel";
            this.AccountBalanceLabel.Size = new System.Drawing.Size(45, 29);
            this.AccountBalanceLabel.TabIndex = 5;
            this.AccountBalanceLabel.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bank:";
            // 
            // AccountBankCodeLabel
            // 
            this.AccountBankCodeLabel.AutoSize = true;
            this.AccountBankCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountBankCodeLabel.Location = new System.Drawing.Point(128, 164);
            this.AccountBankCodeLabel.Name = "AccountBankCodeLabel";
            this.AccountBankCodeLabel.Size = new System.Drawing.Size(97, 29);
            this.AccountBankCodeLabel.TabIndex = 7;
            this.AccountBankCodeLabel.Text = "BNKCD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Branch:";
            // 
            // AccountBranchNumberLabel
            // 
            this.AccountBranchNumberLabel.AutoSize = true;
            this.AccountBranchNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountBranchNumberLabel.Location = new System.Drawing.Point(147, 209);
            this.AccountBranchNumberLabel.Name = "AccountBranchNumberLabel";
            this.AccountBranchNumberLabel.Size = new System.Drawing.Size(52, 29);
            this.AccountBranchNumberLabel.TabIndex = 9;
            this.AccountBranchNumberLabel.Text = "123";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Request Loan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Loan Type";
            // 
            // comboLoanType
            // 
            this.comboLoanType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLoanType.FormattingEnabled = true;
            this.comboLoanType.Location = new System.Drawing.Point(146, 384);
            this.comboLoanType.Name = "comboLoanType";
            this.comboLoanType.Size = new System.Drawing.Size(148, 33);
            this.comboLoanType.TabIndex = 12;
            this.comboLoanType.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(310, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Loan Number:";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(300, 441);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 30);
            this.txtAmount.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(208, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Amount:";
            // 
            // RequestLoanButton
            // 
            this.RequestLoanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestLoanButton.Location = new System.Drawing.Point(469, 468);
            this.RequestLoanButton.Name = "RequestLoanButton";
            this.RequestLoanButton.Size = new System.Drawing.Size(112, 45);
            this.RequestLoanButton.TabIndex = 17;
            this.RequestLoanButton.Text = "Confirm";
            this.RequestLoanButton.UseVisualStyleBackColor = true;
            this.RequestLoanButton.Click += new System.EventHandler(this.RequestLoanButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 29);
            this.label10.TabIndex = 18;
            this.label10.Text = "Account Type:";
            // 
            // AccountTypeLabel
            // 
            this.AccountTypeLabel.AutoSize = true;
            this.AccountTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountTypeLabel.Location = new System.Drawing.Point(220, 258);
            this.AccountTypeLabel.Name = "AccountTypeLabel";
            this.AccountTypeLabel.Size = new System.Drawing.Size(109, 29);
            this.AccountTypeLabel.TabIndex = 19;
            this.AccountTypeLabel.Text = "Personal";
            // 
            // AddAccountButton
            // 
            this.AddAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAccountButton.Location = new System.Drawing.Point(469, 96);
            this.AddAccountButton.Name = "AddAccountButton";
            this.AddAccountButton.Size = new System.Drawing.Size(112, 45);
            this.AddAccountButton.TabIndex = 20;
            this.AddAccountButton.Text = "Add";
            this.AddAccountButton.UseVisualStyleBackColor = true;
            this.AddAccountButton.Click += new System.EventHandler(this.AddAccountButton_Click);
            // 
            // comboLoanNumber
            // 
            this.comboLoanNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLoanNumber.FormattingEnabled = true;
            this.comboLoanNumber.Location = new System.Drawing.Point(452, 384);
            this.comboLoanNumber.Name = "comboLoanNumber";
            this.comboLoanNumber.Size = new System.Drawing.Size(148, 33);
            this.comboLoanNumber.TabIndex = 21;
            this.comboLoanNumber.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(416, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(202, 29);
            this.label11.TabIndex = 22;
            this.label11.Text = "Pending Balance:";
            // 
            // AccountPendingBalanceLabel
            // 
            this.AccountPendingBalanceLabel.AutoSize = true;
            this.AccountPendingBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountPendingBalanceLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.AccountPendingBalanceLabel.Location = new System.Drawing.Point(656, 209);
            this.AccountPendingBalanceLabel.Name = "AccountPendingBalanceLabel";
            this.AccountPendingBalanceLabel.Size = new System.Drawing.Size(45, 29);
            this.AccountPendingBalanceLabel.TabIndex = 23;
            this.AccountPendingBalanceLabel.Text = "0.0";
            // 
            // CustomerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 518);
            this.Controls.Add(this.AccountPendingBalanceLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboLoanNumber);
            this.Controls.Add(this.AddAccountButton);
            this.Controls.Add(this.AccountTypeLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RequestLoanButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboLoanType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AccountBranchNumberLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AccountBankCodeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AccountBalanceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.comboAccounts);
            this.Name = "CustomerHomePage";
            this.Text = "CustomerHomePage";
            this.Load += new System.EventHandler(this.CustomerHomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAccounts;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AccountBalanceLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AccountBankCodeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label AccountBranchNumberLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboLoanType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button RequestLoanButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label AccountTypeLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button AddAccountButton;
        private System.Windows.Forms.ComboBox comboLoanNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label AccountPendingBalanceLabel;
    }
}