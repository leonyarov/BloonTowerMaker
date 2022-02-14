using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloonTowerMaker.Data;
namespace BloonTowerMaker
{
    public partial class PathEdit : Form
    {
        string path;
        BaseModel baseModel;
        TemplateModel templateModel;
        bool isBase = false;
        Models models;
        public PathEdit(string path = "000")
        {
            InitializeComponent();
            this.path = path;
            isBase = path == "000";
            models = new Models();
        }

        private void PathEdit_Load(object sender, EventArgs e)
        {
            label_path.Text = path; //get tower path from calling button
            if (isBase)
            {
                baseModel = models.GetBaseModel();
                input_cost.Text = baseModel.cost;
                input_desc.Text = baseModel.description;
            }
            else
            {
                templateModel = models.GetTemplateModel(path);
                input_cost.Text = templateModel.cost;
                input_desc.Text = templateModel.description;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PathEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isBase)
            {
                baseModel.cost = input_cost.Text;
                baseModel.description = input_desc.Text;
            }
            else
            {
                templateModel.cost = input_cost.Text;
                templateModel.description = input_desc.Text;
            }
            if (isBase)
                models.UpdateBaseModel(baseModel);
            else
                models.UpdateTemplateModel(templateModel, path);
            MainForm.ActiveForm.Update();
        }

        private void img_display_Click(object sender, EventArgs e)
        {
            image_select_dialog.ShowDialog();
        }

        private void image_select_dialog_FileOk(object sender, CancelEventArgs e)
        {
            
            var file = image_select_dialog.FileName;
            string dpath = $"../../userfiles/tower_{path}/images";
            File.Copy(file,Models.getImagesPath(path) + "display.png");
        }
    }
}
