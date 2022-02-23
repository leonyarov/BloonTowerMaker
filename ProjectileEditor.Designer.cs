namespace BloonTowerMaker
{
    partial class ProjectileEditor
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
            this.listProjectiles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.img_projectile = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.input_name = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.selectImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_projectile)).BeginInit();
            this.SuspendLayout();
            // 
            // listProjectiles
            // 
            this.listProjectiles.FormattingEnabled = true;
            this.listProjectiles.Location = new System.Drawing.Point(6, 19);
            this.listProjectiles.Name = "listProjectiles";
            this.listProjectiles.Size = new System.Drawing.Size(120, 199);
            this.listProjectiles.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.listProjectiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projectiles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.img_projectile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_new);
            this.groupBox2.Controls.Add(this.input_name);
            this.groupBox2.Location = new System.Drawing.Point(132, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 240);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // img_projectile
            // 
            this.img_projectile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.img_projectile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img_projectile.Location = new System.Drawing.Point(62, 54);
            this.img_projectile.Name = "img_projectile";
            this.img_projectile.Size = new System.Drawing.Size(100, 100);
            this.img_projectile.TabIndex = 6;
            this.img_projectile.TabStop = false;
            this.img_projectile.Click += new System.EventHandler(this.img_projectile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sprite:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(87, 160);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 1;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // input_name
            // 
            this.input_name.Location = new System.Drawing.Point(62, 23);
            this.input_name.Name = "input_name";
            this.input_name.Size = new System.Drawing.Size(100, 20);
            this.input_name.TabIndex = 3;
            this.input_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_name_KeyPress);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(6, 229);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 23);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // selectImageDialog
            // 
            this.selectImageDialog.Filter = "Image files|*.png";
            this.selectImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.selectImageDialog_FileOk);
            // 
            // ProjectileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 264);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProjectileEditor";
            this.Text = "ProjectileEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectileEditor_FormClosing);
            this.Load += new System.EventHandler(this.ProjectileEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_projectile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listProjectiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.TextBox input_name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox img_projectile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog selectImageDialog;
    }
}