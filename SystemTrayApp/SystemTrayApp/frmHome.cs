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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = FileOperation.ReadFile();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {


                SharedItems.CopyItems sItems = new SharedItems.CopyItems()
                {
                    Date = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Date,
                    Id = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Id,
                    Keyword = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Keyword,
                    Text = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Text
                };

                frmTags frmTg = new frmTags();
                frmTg.items = sItems;
                frmTg.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }
    }
}
