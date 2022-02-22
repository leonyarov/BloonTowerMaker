
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
            this.label_path = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.img_icon = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.img_display = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_model = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.input_description = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.input_cost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.input_name = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.propertiesList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.input_property = new System.Windows.Forms.MaskedTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.image_select_dialog = new System.Windows.Forms.OpenFileDialog();
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.img_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_display)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.button_ok.Location = new System.Drawing.Point(0, 782);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(662, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "Done";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // img_icon
            // 
            this.img_icon.Location = new System.Drawing.Point(201, 27);
            this.img_icon.Name = "img_icon";
            this.img_icon.Size = new System.Drawing.Size(67, 64);
            this.img_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_icon.TabIndex = 3;
            this.img_icon.TabStop = false;
            this.img_icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img_icon_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(198, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Icon";
            // 
            // img_display
            // 
            this.img_display.Location = new System.Drawing.Point(8, 27);
            this.img_display.Name = "img_display";
            this.img_display.Size = new System.Drawing.Size(155, 147);
            this.img_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_display.TabIndex = 3;
            this.img_display.TabStop = false;
            this.img_display.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img_display_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Portrait";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Description.Location = new System.Drawing.Point(5, 18);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(60, 13);
            this.Description.TabIndex = 0;
            this.Description.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.combo_model);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 577);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model";
            // 
            // combo_model
            // 
            this.combo_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.combo_model.FormattingEnabled = true;
            this.combo_model.Items.AddRange(new object[] {
            "Dart Monkey"});
            this.combo_model.Location = new System.Drawing.Point(247, 86);
            this.combo_model.Name = "combo_model";
            this.combo_model.Size = new System.Drawing.Size(121, 21);
            this.combo_model.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(656, 32);
            this.panel1.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(581, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 22);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "3D model";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(5, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "2D sprite";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 201);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.img_display);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.img_icon);
            this.panel2.Location = new System.Drawing.Point(374, 13);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(276, 182);
            this.panel2.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.input_description);
            this.groupBox4.Controls.Add(this.tableLayoutPanel2);
            this.groupBox4.Controls.Add(this.Description);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(262, 182);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Info";
            // 
            // input_description
            // 
            this.input_description.Dock = System.Windows.Forms.DockStyle.Top;
            this.input_description.Location = new System.Drawing.Point(5, 31);
            this.input_description.Multiline = true;
            this.input_description.Name = "input_description";
            this.input_description.Size = new System.Drawing.Size(252, 57);
            this.input_description.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.input_cost, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.input_name, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 108);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(252, 69);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cost";
            // 
            // input_cost
            // 
            this.input_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.input_cost.Location = new System.Drawing.Point(3, 16);
            this.input_cost.Name = "input_cost";
            this.input_cost.Size = new System.Drawing.Size(100, 20);
            this.input_cost.TabIndex = 1;
            this.input_cost.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(109, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Upgrade Name";
            // 
            // input_name
            // 
            this.input_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.input_name.Location = new System.Drawing.Point(109, 16);
            this.input_name.Name = "input_name";
            this.input_name.Size = new System.Drawing.Size(100, 20);
            this.input_name.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btn_Edit);
            this.groupBox3.Controls.Add(this.propertiesList);
            this.groupBox3.Controls.Add(this.input_property);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(0, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(662, 363);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(497, 336);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 21);
            this.btn_Edit.TabIndex = 11;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // propertiesList
            // 
            this.propertiesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.value,
            this.type});
            this.propertiesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertiesList.HideSelection = false;
            this.propertiesList.Location = new System.Drawing.Point(161, 16);
            this.propertiesList.Name = "propertiesList";
            this.propertiesList.Size = new System.Drawing.Size(498, 315);
            this.propertiesList.TabIndex = 9;
            this.propertiesList.UseCompatibleStateImageBehavior = false;
            this.propertiesList.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 210;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 121;
            // 
            // input_property
            // 
            this.input_property.Location = new System.Drawing.Point(167, 337);
            this.input_property.Name = "input_property";
            this.input_property.Size = new System.Drawing.Size(295, 20);
            this.input_property.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 344);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Stats";
            // 
            // image_select_dialog
            // 
            this.image_select_dialog.FileName = "openFileDialog1";
            this.image_select_dialog.Filter = "Image Files|*.png|jpeg files|*.jpeg ";
            this.image_select_dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.image_select_dialog_FileOk);
            // 
            // type
            // 
            this.type.Text = "Type";
            // 
            // PathEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(662, 805);
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
            ((System.ComponentModel.ISupportInitialize)(this.img_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_display)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.PictureBox img_icon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox img_display;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox input_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_cost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox input_description;
        private System.Windows.Forms.ListView propertiesList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.MaskedTextBox input_property;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ColumnHeader type;
    }
}