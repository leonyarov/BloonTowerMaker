using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloonTowerMaker.Data;
using BloonTowerMaker.Data;

namespace BloonTowerMaker
{
    public partial class MainForm : Form
    {
        BaseModel data;
        Models models;
        public MainForm()
        {
            InitializeComponent();
            models = new Models();
        }


        private void Edit(string path)
        {
            PathEdit edit = new PathEdit(path);
            edit.ShowDialog();
            edit.Focus();
        }

        #region Buttons
        private void btn_t100_Click(object sender, EventArgs e)
        {
            Edit("100");
        }
        private void btn_t020_Click(object sender, EventArgs e)
        {
            Edit("020");
        }

        private void btn_t300_Click(object sender, EventArgs e)
        {
            Edit("300");
        }

        private void btn_t400_Click(object sender, EventArgs e)
        {
            Edit("400");
        }

        private void btn_t500_Click(object sender, EventArgs e)
        {
            Edit("500");
        }

        private void btn_t050_Click(object sender, EventArgs e)
        {
            Edit("050");
        }

        private void btn_t040_Click(object sender, EventArgs e)
        {
            Edit("040");
        }

        private void btn_t030_Click(object sender, EventArgs e)
        {
            Edit("030");
        }

        private void btn_t200_Click(object sender, EventArgs e)
        {
            Edit("200");
        }

        private void btn_t010_Click(object sender, EventArgs e)
        {
            Edit("010");
        }
        #endregion

        private void img_base_Click(object sender, EventArgs e)
        {
            Edit("000");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            data = models.GetBaseModel();
            label_cost.Text = data.cost;
        }
    }
}
