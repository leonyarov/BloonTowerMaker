
namespace BloonTowerMaker
{
    partial class PathEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathEdit));
            this.label_path = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.input_cost = new System.Windows.Forms.TextBox();
            this.img_projectile = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.img_icon = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.img_display = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.input_desc = new System.Windows.Forms.RichTextBox();
            this.Description = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_model = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.image_select_dialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.img_projectile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_display)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_path.Location = new System.Drawing.Point(0, 0);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(28, 13);
            this.label_path.TabIndex = 0;
            this.label_path.Text = "path";
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.Location = new System.Drawing.Point(0, 684);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(482, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "Done";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Luckiest Guy", 10F);
            this.label1.Location = new System.Drawing.Point(21, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "cost";
            // 
            // input_cost
            // 
            this.input_cost.Font = new System.Drawing.Font("Luckiest Guy", 10F);
            this.input_cost.Location = new System.Drawing.Point(12, 154);
            this.input_cost.Name = "input_cost";
            this.input_cost.Size = new System.Drawing.Size(100, 24);
            this.input_cost.TabIndex = 1;
            this.input_cost.Text = "0";
            // 
            // img_projectile
            // 
            this.img_projectile.Location = new System.Drawing.Point(3, 33);
            this.img_projectile.Name = "img_projectile";
            this.img_projectile.Size = new System.Drawing.Size(89, 81);
            this.img_projectile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_projectile.TabIndex = 3;
            this.img_projectile.TabStop = false;
            this.img_projectile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img_projectile_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Luckiest Guy", 10F);
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Projectile";
            // 
            // img_icon
            // 
            this.img_icon.Location = new System.Drawing.Point(116, 33);
            this.img_icon.Name = "img_icon";
            this.img_icon.Size = new System.Drawing.Size(92, 81);
            this.img_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_icon.TabIndex = 3;
            this.img_icon.TabStop = false;
            this.img_icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img_icon_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Luckiest Guy", 10F);
            this.label3.Location = new System.Drawing.Point(113, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Icon";
            // 
            // img_display
            // 
            this.img_display.Location = new System.Drawing.Point(17, 66);
            this.img_display.Name = "img_display";
            this.img_display.Size = new System.Drawing.Size(137, 129);
            this.img_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_display.TabIndex = 3;
            this.img_display.TabStop = false;
            this.img_display.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img_display_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Portrait";
            // 
            // input_desc
            // 
            this.input_desc.Font = new System.Drawing.Font("Luckiest Guy", 10F);
            this.input_desc.Location = new System.Drawing.Point(12, 53);
            this.input_desc.Name = "input_desc";
            this.input_desc.Size = new System.Drawing.Size(234, 64);
            this.input_desc.TabIndex = 5;
            this.input_desc.Text = "description";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Luckiest Guy", 10F);
            this.Description.Location = new System.Drawing.Point(12, 33);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(88, 17);
            this.Description.TabIndex = 0;
            this.Description.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.combo_model);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Luckiest Guy", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 479);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model";
            // 
            // combo_model
            // 
            this.combo_model.FormattingEnabled = true;
            this.combo_model.Items.AddRange(new object[] {
            "Dart Monkey"});
            this.combo_model.Location = new System.Drawing.Point(247, 86);
            this.combo_model.Name = "combo_model";
            this.combo_model.Size = new System.Drawing.Size(121, 38);
            this.combo_model.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(476, 32);
            this.panel1.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioButton2.Font = new System.Drawing.Font("Luckiest Guy", 12F);
            this.radioButton2.Location = new System.Drawing.Point(375, 0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 32);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "3D model";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton1.Font = new System.Drawing.Font("Luckiest Guy", 12F);
            this.radioButton1.Location = new System.Drawing.Point(5, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 32);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "2D sprite";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.img_display);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Luckiest Guy", 18F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(0, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 201);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Icons";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.img_projectile);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.img_icon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(253, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 165);
            this.panel2.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.input_desc);
            this.groupBox3.Controls.Add(this.input_cost);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Description);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Luckiest Guy", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(0, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(482, 265);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            // 
            // image_select_dialog
            // 
            this.image_select_dialog.FileName = "openFileDialog1";
            this.image_select_dialog.Filter = "Image Files|*.png|jpeg files|*.jpeg ";
            this.image_select_dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.image_select_dialog_FileOk);
            // 
            // PathEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(482, 707);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_path);
            this.DoubleBuffered = true;
            this.Name = "PathEdit";
            this.Text = "PathEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PathEdit_FormClosing);
            this.Load += new System.EventHandler(this.PathEdit_Load);
            this.Enter += new System.EventHandler(this.PathEdit_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.img_projectile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_display)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_cost;
        private System.Windows.Forms.PictureBox img_projectile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox img_icon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox img_display;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox input_desc;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox combo_model;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog image_select_dialog;
    }
}