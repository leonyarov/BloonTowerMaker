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

namespace BloonTowerMaker
{
    public partial class NewProject : Form
    {
        public Project proj;
        public NewProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.proj = new Project(path.Text, towername.Text, version.Text, author.Text);
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void NewProject_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            path.Text = Project.GetFolder();
        }
    }
}
