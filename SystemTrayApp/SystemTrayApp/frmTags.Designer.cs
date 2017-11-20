namespace SystemTrayApp
{
    partial class frmTags
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtId);
            this.flowLayoutPanel1.Controls.Add(this.txtKey);
            this.flowLayoutPanel1.Controls.Add(this.txtText);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(197, 273);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtId.Location = new System.Drawing.Point(3, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(190, 20);
            this.txtId.TabIndex = 0;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(3, 29);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(190, 20);
            this.txtKey.TabIndex = 1;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(3, 55);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(190, 213);
            this.txtText.TabIndex = 2;
            this.txtText.Text = "";
            // 
            // frmTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 273);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmTags";
            this.Text = "frmTags";
            this.Load += new System.EventHandler(this.frmTags_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.RichTextBox txtText;
    }
}