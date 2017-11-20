using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemTrayApp
{
    public partial class frmTags : Form
    {
        public SharedItems.CopyItems items { get; set; }
        public frmTags()
        {
            InitializeComponent();
        }

        private void frmTags_Load(object sender, EventArgs e)
        {
            txtId.Text = items.Id.ToString();
            txtKey.Text = items.Keyword;
            txtText.Text = items.Text;
        }
    }
}
