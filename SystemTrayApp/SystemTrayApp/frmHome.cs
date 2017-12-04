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
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {


                //SharedItems.CopyItems sItems = new SharedItems.CopyItems()
                //{
                //    Date = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Date,
                //    Id = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Id,
                //    Keyword = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Keyword,
                //    Text = ((SystemTrayApp.SharedItems.CopyItems)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).Text
                //};

                //frmTags frmTg = new frmTags();
                //frmTg.items = sItems;
                //frmTg.ShowDialog();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DBOperations db = new DBOperations();
                backgroundWorker1.ReportProgress(40);
                e.Result = db.getRecords().OrderByDescending(x => x.Date).ToList();
                backgroundWorker1.ReportProgress(95);
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dataGridView1.DataSource = (List<SystemTrayApp.SharedItems.CopyItems>)e.Result;
            }
            catch (Exception ex)
            {
            }
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DBOperations operaion = new DBOperations();
                List<string> idList = new List<string>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    idList.Add(row.Cells[0].Value.ToString());
                }

                operaion.DeleteByIdList(idList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
