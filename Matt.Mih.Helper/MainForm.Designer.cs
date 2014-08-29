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
            this.btnBalance = new System.Windows.Forms.Button();
            this.btnGameToggle = new System.Windows.Forms.Button();
            this.lSwap1 = new System.Windows.Forms.Label();
            this.lSwap2 = new System.Windows.Forms.Label();
            this.lRatingDifference = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBalance
            // 
            this.btnBalance.Location = new System.Drawing.Point(342, 527);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(100, 23);
            this.btnBalance.TabIndex = 20;
            this.btnBalance.Text = "Balance Teams";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // btnGameToggle
            // 
            this.btnGameToggle.Location = new System.Drawing.Point(342, 556);
            this.btnGameToggle.Name = "btnGameToggle";
            this.btnGameToggle.Size = new System.Drawing.Size(100, 23);
            this.btnGameToggle.TabIndex = 21;
            this.btnGameToggle.Text = "Game Started";
            this.btnGameToggle.UseVisualStyleBackColor = true;
            this.btnGameToggle.Click += new System.EventHandler(this.btnGameToggle_Click);
            // 
            // lSwap1
            // 
            this.lSwap1.Location = new System.Drawing.Point(0, 23);
            this.lSwap1.Name = "lSwap1";
            this.lSwap1.Size = new System.Drawing.Size(784, 13);
            this.lSwap1.TabIndex = 2;
            this.lSwap1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSwap2
            // 
            this.lSwap2.Location = new System.Drawing.Point(0, 49);
            this.lSwap2.Name = "lSwap2";
            this.lSwap2.Size = new System.Drawing.Size(784, 13);
            this.lSwap2.TabIndex = 1;
            this.lSwap2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lRatingDifference
            // 
            this.lRatingDifference.Location = new System.Drawing.Point(0, 505);
            this.lRatingDifference.Name = "lRatingDifference";
            this.lRatingDifference.Size = new System.Drawing.Size(784, 13);
            this.lRatingDifference.TabIndex = 0;
            this.lRatingDifference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 602);
            this.Controls.Add(this.lSwap2);
            this.Controls.Add(this.lSwap1);
            this.Controls.Add(this.btnGameToggle);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.lRatingDifference);
            this.Name = "MainForm";
            this.Text = "Mentored Inhouse Helper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Button btnGameToggle;
        private System.Windows.Forms.Label lSwap1;
        private System.Windows.Forms.Label lSwap2;
        private System.Windows.Forms.Label lRatingDifference;
    }
}

