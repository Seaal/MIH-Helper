namespace Matt.Mih.Helper.WinForms
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
            this.btnClear = new System.Windows.Forms.Button();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // btnBalance
            // 
            this.btnBalance.Location = new System.Drawing.Point(342, 537);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(100, 23);
            this.btnBalance.TabIndex = 20;
            this.btnBalance.Text = "Balance Teams";
            this.btnBalance.UseVisualStyleBackColor = true;
            // 
            // btnGameToggle
            // 
            this.btnGameToggle.Location = new System.Drawing.Point(342, 566);
            this.btnGameToggle.Name = "btnGameToggle";
            this.btnGameToggle.Size = new System.Drawing.Size(100, 23);
            this.btnGameToggle.TabIndex = 21;
            this.btnGameToggle.Text = "Game Started";
            this.btnGameToggle.UseVisualStyleBackColor = true;
            // 
            // lSwap1
            // 
            this.lSwap1.Location = new System.Drawing.Point(0, 46);
            this.lSwap1.Name = "lSwap1";
            this.lSwap1.Size = new System.Drawing.Size(784, 13);
            this.lSwap1.TabIndex = 2;
            this.lSwap1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSwap2
            // 
            this.lSwap2.Location = new System.Drawing.Point(0, 72);
            this.lSwap2.Name = "lSwap2";
            this.lSwap2.Size = new System.Drawing.Size(784, 13);
            this.lSwap2.TabIndex = 1;
            this.lSwap2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lRatingDifference
            // 
            this.lRatingDifference.Location = new System.Drawing.Point(0, 515);
            this.lRatingDifference.Name = "lRatingDifference";
            this.lRatingDifference.Size = new System.Drawing.Size(784, 13);
            this.lRatingDifference.TabIndex = 0;
            this.lRatingDifference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(342, 595);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 625);
            this.Controls.Add(this.btnClear);
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}

