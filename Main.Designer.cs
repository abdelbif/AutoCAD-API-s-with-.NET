namespace DotNet_Autocad
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadLines = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.BtnLoadMText = new System.Windows.Forms.Button();
            this.BtnLoadPolylines = new System.Windows.Forms.Button();
            this.BtnLoadBlocksNoAttribute = new System.Windows.Forms.Button();
            this.BtnLoadBlocksWithAttribute = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnLoadBlocksWithAttribute);
            this.groupBox1.Controls.Add(this.BtnLoadBlocksNoAttribute);
            this.groupBox1.Controls.Add(this.BtnLoadPolylines);
            this.groupBox1.Controls.Add(this.BtnLoadMText);
            this.groupBox1.Controls.Add(this.btnLoadLines);
            this.groupBox1.Location = new System.Drawing.Point(83, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLoadLines
            // 
            this.btnLoadLines.Location = new System.Drawing.Point(62, 30);
            this.btnLoadLines.Name = "btnLoadLines";
            this.btnLoadLines.Size = new System.Drawing.Size(139, 35);
            this.btnLoadLines.TabIndex = 0;
            this.btnLoadLines.Text = "Load lines to Db";
            this.btnLoadLines.UseVisualStyleBackColor = true;
            this.btnLoadLines.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(23, 415);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(103, 16);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Message here...";
            // 
            // BtnLoadMText
            // 
            this.BtnLoadMText.Location = new System.Drawing.Point(62, 97);
            this.BtnLoadMText.Name = "BtnLoadMText";
            this.BtnLoadMText.Size = new System.Drawing.Size(139, 35);
            this.BtnLoadMText.TabIndex = 1;
            this.BtnLoadMText.Text = "Load MTexts to Db";
            this.BtnLoadMText.UseVisualStyleBackColor = true;
            this.BtnLoadMText.Click += new System.EventHandler(this.BtnLoadMText_Click);
            // 
            // BtnLoadPolylines
            // 
            this.BtnLoadPolylines.Location = new System.Drawing.Point(62, 164);
            this.BtnLoadPolylines.Name = "BtnLoadPolylines";
            this.BtnLoadPolylines.Size = new System.Drawing.Size(139, 35);
            this.BtnLoadPolylines.TabIndex = 2;
            this.BtnLoadPolylines.Text = "Load Polylines to Db";
            this.BtnLoadPolylines.UseVisualStyleBackColor = true;
            this.BtnLoadPolylines.Click += new System.EventHandler(this.BtnLoadPolylines_Click);
            // 
            // BtnLoadBlocksNoAttribute
            // 
            this.BtnLoadBlocksNoAttribute.Location = new System.Drawing.Point(37, 216);
            this.BtnLoadBlocksNoAttribute.Name = "BtnLoadBlocksNoAttribute";
            this.BtnLoadBlocksNoAttribute.Size = new System.Drawing.Size(194, 35);
            this.BtnLoadBlocksNoAttribute.TabIndex = 3;
            this.BtnLoadBlocksNoAttribute.Text = "Load BlocksNoAttribute to Db";
            this.BtnLoadBlocksNoAttribute.UseVisualStyleBackColor = true;
            this.BtnLoadBlocksNoAttribute.Click += new System.EventHandler(this.BtnLoadBlocksWithNoAttribute_Click);
            // 
            // BtnLoadBlocksWithAttribute
            // 
            this.BtnLoadBlocksWithAttribute.Location = new System.Drawing.Point(37, 284);
            this.BtnLoadBlocksWithAttribute.Name = "BtnLoadBlocksWithAttribute";
            this.BtnLoadBlocksWithAttribute.Size = new System.Drawing.Size(194, 35);
            this.BtnLoadBlocksWithAttribute.TabIndex = 4;
            this.BtnLoadBlocksWithAttribute.Text = "Load BlocksWithAttribute to Db";
            this.BtnLoadBlocksWithAttribute.UseVisualStyleBackColor = true;
            this.BtnLoadBlocksWithAttribute.Click += new System.EventHandler(this.BtnLoadBlocksWithAttribute_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Main";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadLines;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button BtnLoadMText;
        private System.Windows.Forms.Button BtnLoadPolylines;
        private System.Windows.Forms.Button BtnLoadBlocksNoAttribute;
        private System.Windows.Forms.Button BtnLoadBlocksWithAttribute;
    }
}