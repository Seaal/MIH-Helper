namespace Matt.Mih.Helper
{
    partial class MainForm
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
            this.cbChampions0 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPlayer0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBalance = new System.Windows.Forms.Button();
            this.tbElo0 = new System.Windows.Forms.TextBox();
            this.btnGameToggle = new System.Windows.Forms.Button();
            this.lError0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbChampions0
            // 
            this.cbChampions0.FormattingEnabled = true;
            this.cbChampions0.Location = new System.Drawing.Point(95, 49);
            this.cbChampions0.Name = "cbChampions0";
            this.cbChampions0.Size = new System.Drawing.Size(121, 21);
            this.cbChampions0.Sorted = true;
            this.cbChampions0.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Champion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ranked Elo:";
            // 
            // tbPlayer0
            // 
            this.tbPlayer0.Location = new System.Drawing.Point(95, 23);
            this.tbPlayer0.Name = "tbPlayer0";
            this.tbPlayer0.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer0.TabIndex = 4;
            this.tbPlayer0.Leave += new System.EventHandler(this.tbPlayer0_Leave);
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
            this.btnBalance.Location = new System.Drawing.Point(342, 351);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(100, 23);
            this.btnBalance.TabIndex = 6;
            this.btnBalance.Text = "Balance Teams";
            this.btnBalance.UseVisualStyleBackColor = true;
            // 
            // tbElo0
            // 
            this.tbElo0.Location = new System.Drawing.Point(95, 77);
            this.tbElo0.Name = "tbElo0";
            this.tbElo0.ReadOnly = true;
            this.tbElo0.Size = new System.Drawing.Size(100, 20);
            this.tbElo0.TabIndex = 8;
            // 
            // btnGameToggle
            // 
            this.btnGameToggle.Location = new System.Drawing.Point(342, 380);
            this.btnGameToggle.Name = "btnGameToggle";
            this.btnGameToggle.Size = new System.Drawing.Size(100, 23);
            this.btnGameToggle.TabIndex = 9;
            this.btnGameToggle.Text = "Game Started";
            this.btnGameToggle.UseVisualStyleBackColor = true;
            this.btnGameToggle.Click += new System.EventHandler(this.btnGameToggle_Click);
            // 
            // lError0
            // 
            this.lError0.AutoSize = true;
            this.lError0.ForeColor = System.Drawing.Color.Red;
            this.lError0.Location = new System.Drawing.Point(95, 104);
            this.lError0.Name = "lError0";
            this.lError0.Size = new System.Drawing.Size(0, 13);
            this.lError0.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.tbElo0);
            this.Controls.Add(this.lError0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPlayer0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChampions0);
            this.Controls.Add(this.btnGameToggle);
            this.Controls.Add(this.btnBalance);
            this.Name = "MainForm";
            this.Text = "Mentored Inhouse Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChampions0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlayer0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.TextBox tbElo0;
        private System.Windows.Forms.Button btnGameToggle;
        private System.Windows.Forms.Label lError0;
    }
}

