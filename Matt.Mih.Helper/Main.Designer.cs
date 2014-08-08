namespace Matt.Mih.Helper
{
    partial class Main
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
            this.cbChampions1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbElo1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPlayer1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBalance = new System.Windows.Forms.Button();
            this.lNameError1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbChampions1
            // 
            this.cbChampions1.FormattingEnabled = true;
            this.cbChampions1.Location = new System.Drawing.Point(95, 69);
            this.cbChampions1.Name = "cbChampions1";
            this.cbChampions1.Size = new System.Drawing.Size(121, 21);
            this.cbChampions1.Sorted = true;
            this.cbChampions1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Champion:";
            // 
            // cbElo1
            // 
            this.cbElo1.FormattingEnabled = true;
            this.cbElo1.Location = new System.Drawing.Point(95, 97);
            this.cbElo1.Name = "cbElo1";
            this.cbElo1.Size = new System.Drawing.Size(121, 21);
            this.cbElo1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ranked Elo:";
            // 
            // tbPlayer1
            // 
            this.tbPlayer1.Location = new System.Drawing.Point(95, 23);
            this.tbPlayer1.Name = "tbPlayer1";
            this.tbPlayer1.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player Name:";
            // 
            // btnBalance
            // 
            this.btnBalance.Location = new System.Drawing.Point(331, 351);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(75, 23);
            this.btnBalance.TabIndex = 6;
            this.btnBalance.Text = "Balance Teams";
            this.btnBalance.UseVisualStyleBackColor = true;
            // 
            // lNameError1
            // 
            this.lNameError1.AutoSize = true;
            this.lNameError1.ForeColor = System.Drawing.Color.Red;
            this.lNameError1.Location = new System.Drawing.Point(95, 49);
            this.lNameError1.Name = "lNameError1";
            this.lNameError1.Size = new System.Drawing.Size(0, 13);
            this.lNameError1.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.lNameError1);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPlayer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbElo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChampions1);
            this.Name = "Main";
            this.Text = "Mentored Inhouse Helper";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChampions1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbElo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlayer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Label lNameError1;
    }
}

