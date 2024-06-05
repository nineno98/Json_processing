namespace Employers_from_rest_api
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.mentesbutton = new System.Windows.Forms.Button();
            this.nevtextbox = new System.Windows.Forms.TextBox();
            this.salaryNumUpdown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.salaryNumUpdown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Név";
            // 
            // mentesbutton
            // 
            this.mentesbutton.Location = new System.Drawing.Point(81, 256);
            this.mentesbutton.Name = "mentesbutton";
            this.mentesbutton.Size = new System.Drawing.Size(222, 78);
            this.mentesbutton.TabIndex = 1;
            this.mentesbutton.Text = "Új dolgozó bevitele";
            this.mentesbutton.UseVisualStyleBackColor = true;
            this.mentesbutton.Click += new System.EventHandler(this.mentesbutton_Click);
            // 
            // nevtextbox
            // 
            this.nevtextbox.Location = new System.Drawing.Point(81, 127);
            this.nevtextbox.Name = "nevtextbox";
            this.nevtextbox.Size = new System.Drawing.Size(221, 20);
            this.nevtextbox.TabIndex = 2;
            // 
            // salaryNumUpdown
            // 
            this.salaryNumUpdown.Location = new System.Drawing.Point(81, 191);
            this.salaryNumUpdown.Name = "salaryNumUpdown";
            this.salaryNumUpdown.Size = new System.Drawing.Size(222, 20);
            this.salaryNumUpdown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fizetés";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salaryNumUpdown);
            this.Controls.Add(this.nevtextbox);
            this.Controls.Add(this.mentesbutton);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Új dolgozó hozzáadása";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryNumUpdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mentesbutton;
        private System.Windows.Forms.TextBox nevtextbox;
        private System.Windows.Forms.NumericUpDown salaryNumUpdown;
        private System.Windows.Forms.Label label2;
    }
}