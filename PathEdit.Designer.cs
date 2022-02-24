
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
            this.button_ok = new System.Windows.Forms.Button();
            this.img_icon = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.img_display = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_model = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridProjectiles = new System.Windows.Forms.DataGridView();
            this.dataGridPathAttack = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridPathProperty = new System.Windows.Forms.DataGridView();
            this.image_select_dialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.img_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_display)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProjectiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPathAttack)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPathProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.Location = new System.Drawing.Point(0, 782);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(806, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "Done";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // img_icon
            // 
            this.img_icon.BackColor = System.Drawing.Color.Silver;
            this.img_icon.Location = new System.Drawing.Point(215, 40);
            this.img_icon.Name = "img_icon";
            this.img_icon.Size = new System.Drawing.Size(155, 155);
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
            this.label3.Location = new System.Drawing.Point(212, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Icon";
            // 
            // img_display
            // 
            this.img_display.BackColor = System.Drawing.Color.Silver;
            this.img_display.Location = new System.Drawing.Point(12, 40);
            this.img_display.Name = "img_display";
            this.img_display.Size = new System.Drawing.Size(155, 155);
            this.img_display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_display.TabIndex = 3;
            this.img_display.TabStop = false;
            this.img_display.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img_display_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Portrait";
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
            this.groupBox1.Size = new System.Drawing.Size(806, 205);
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
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(725, 5);
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
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.img_display);
            this.groupBox2.Controls.Add(this.img_icon);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 201);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(0, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(806, 376);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridProjectiles);
            this.groupBox6.Controls.Add(this.dataGridPathAttack);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(386, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(417, 357);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attack";
            // 
            // dataGridProjectiles
            // 
            this.dataGridProjectiles.AllowUserToAddRows = false;
            this.dataGridProjectiles.AllowUserToDeleteRows = false;
            this.dataGridProjectiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProjectiles.Location = new System.Drawing.Point(206, 19);
            this.dataGridProjectiles.Name = "dataGridProjectiles";
            this.dataGridProjectiles.Size = new System.Drawing.Size(208, 171);
            this.dataGridProjectiles.TabIndex = 2;
            // 
            // dataGridPathAttack
            // 
            this.dataGridPathAttack.AllowUserToAddRows = false;
            this.dataGridPathAttack.AllowUserToDeleteRows = false;
            this.dataGridPathAttack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPathAttack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridPathAttack.Location = new System.Drawing.Point(3, 196);
            this.dataGridPathAttack.Name = "dataGridPathAttack";
            this.dataGridPathAttack.Size = new System.Drawing.Size(411, 158);
            this.dataGridPathAttack.TabIndex = 1;
            this.dataGridPathAttack.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPathAttack_CellValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridPathProperty);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(380, 357);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tower";
            // 
            // dataGridPathProperty
            // 
            this.dataGridPathProperty.AllowUserToAddRows = false;
            this.dataGridPathProperty.AllowUserToDeleteRows = false;
            this.dataGridPathProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPathProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPathProperty.Location = new System.Drawing.Point(3, 16);
            this.dataGridPathProperty.Name = "dataGridPathProperty";
            this.dataGridPathProperty.Size = new System.Drawing.Size(374, 338);
            this.dataGridPathProperty.TabIndex = 0;
            this.dataGridPathProperty.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPathProperty_CellValueChanged);
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
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(806, 805);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ok);
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
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProjectiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPathAttack)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPathProperty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.PictureBox img_icon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox img_display;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox combo_model;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog image_select_dialog;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridPathProperty;
        private System.Windows.Forms.DataGridView dataGridProjectiles;
        private System.Windows.Forms.DataGridView dataGridPathAttack;
    }
}