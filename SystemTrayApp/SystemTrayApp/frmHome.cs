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
        public enum Operation
        {
            GetData,
            DeleteData
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                userControl11.Visible = false;
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync(Operation.GetData);
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
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(Operation.GetData);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MethodInvoker action = () => userControl11.Visible = true;

                userControl11.BeginInvoke(action);

                Operation op = (Operation)e.Argument;
                if (op == Operation.DeleteData)
                {
                    DBOperations operaion = new DBOperations();
                    List<string> idList = new List<string>();

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        operaion.DeleteById(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
                else
                {
                    DBOperations db = new DBOperations();
                    backgroundWorker1.ReportProgress(40);
                    e.Result = db.getRecords().OrderByDescending(x => x.Date).ToList();
                    backgroundWorker1.ReportProgress(95);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MethodInvoker action = () => userControl11.Visible = false;

                userControl11.BeginInvoke(action); dataGridView1.DataSource = (List<SystemTrayApp.SharedItems.CopyItems>)e.Result;
            }
            catch (Exception ex)
            {
            }
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync(Operation.DeleteData);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
