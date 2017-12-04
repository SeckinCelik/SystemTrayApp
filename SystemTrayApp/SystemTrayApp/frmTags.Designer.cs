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
            this.dteTarih = new System.Windows.Forms.DateTimePicker();
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtId);
            this.flowLayoutPanel1.Controls.Add(this.txtKey);
            this.flowLayoutPanel1.Controls.Add(this.dteTarih);
            this.flowLayoutPanel1.Controls.Add(this.txtText);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 249);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(3, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(190, 20);
            this.txtId.TabIndex = 0;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(199, 3);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(190, 20);
            this.txtKey.TabIndex = 1;
            // 
            // dteTarih
            // 
            this.dteTarih.Enabled = false;
            this.dteTarih.Location = new System.Drawing.Point(3, 29);
            this.dteTarih.Name = "dteTarih";
            this.dteTarih.Size = new System.Drawing.Size(386, 20);
            this.dteTarih.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Enabled = false;
            this.txtText.Location = new System.Drawing.Point(3, 55);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(386, 160);
            this.txtText.TabIndex = 2;
            this.txtText.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(125, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 249);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmTags";
            this.Text = "Tag";
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
        private System.Windows.Forms.DateTimePicker dteTarih;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}