﻿namespace Employers_from_rest_api
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.newEmployer = new System.Windows.Forms.Button();
            this.modifiEmployer = new System.Windows.Forms.Button();
            this.deleteEmployer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(415, 405);
            this.dataGridView1.TabIndex = 0;
            // 
            // newEmployer
            // 
            this.newEmployer.Location = new System.Drawing.Point(514, 51);
            this.newEmployer.Name = "newEmployer";
            this.newEmployer.Size = new System.Drawing.Size(119, 39);
            this.newEmployer.TabIndex = 1;
            this.newEmployer.Text = "Új dolgozó...";
            this.newEmployer.UseVisualStyleBackColor = true;
            // 
            // modifiEmployer
            // 
            this.modifiEmployer.Location = new System.Drawing.Point(514, 114);
            this.modifiEmployer.Name = "modifiEmployer";
            this.modifiEmployer.Size = new System.Drawing.Size(118, 39);
            this.modifiEmployer.TabIndex = 2;
            this.modifiEmployer.Text = "Módosítás...";
            this.modifiEmployer.UseVisualStyleBackColor = true;
            // 
            // deleteEmployer
            // 
            this.deleteEmployer.Location = new System.Drawing.Point(515, 178);
            this.deleteEmployer.Name = "deleteEmployer";
            this.deleteEmployer.Size = new System.Drawing.Size(116, 41);
            this.deleteEmployer.TabIndex = 3;
            this.deleteEmployer.Text = "Dolgozó törlése";
            this.deleteEmployer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteEmployer);
            this.Controls.Add(this.modifiEmployer);
            this.Controls.Add(this.newEmployer);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button newEmployer;
        private System.Windows.Forms.Button modifiEmployer;
        private System.Windows.Forms.Button deleteEmployer;
        private System.Windows.Forms.Label label1;
    }
}
