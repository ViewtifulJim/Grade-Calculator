namespace GradeCalculator
{
    partial class ModuleNameForm
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
            this.lblEnterModuleName = new System.Windows.Forms.Label();
            this.txtBoxModuleName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterModuleName
            // 
            this.lblEnterModuleName.AutoSize = true;
            this.lblEnterModuleName.Font = new System.Drawing.Font("Lucida Bright", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterModuleName.Location = new System.Drawing.Point(53, 20);
            this.lblEnterModuleName.Name = "lblEnterModuleName";
            this.lblEnterModuleName.Size = new System.Drawing.Size(243, 26);
            this.lblEnterModuleName.TabIndex = 40;
            this.lblEnterModuleName.Text = "Enter module name:";
            // 
            // txtBoxModuleName
            // 
            this.txtBoxModuleName.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxModuleName.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxModuleName.Location = new System.Drawing.Point(37, 62);
            this.txtBoxModuleName.Name = "txtBoxModuleName";
            this.txtBoxModuleName.Size = new System.Drawing.Size(277, 31);
            this.txtBoxModuleName.TabIndex = 41;
            this.txtBoxModuleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(187, 111);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(127, 35);
            this.btnOK.TabIndex = 42;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(37, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 35);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ModuleNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBoxModuleName);
            this.Controls.Add(this.lblEnterModuleName);
            this.Name = "ModuleNameForm";
            this.Text = "ModuleName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterModuleName;
        private System.Windows.Forms.TextBox txtBoxModuleName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}