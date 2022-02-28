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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectileEditor));
            this.listProjectiles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridProjectile = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridDamage = new System.Windows.Forms.DataGridView();
            this.btn_help = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.img_projectile = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.selectImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProjectile)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_projectile)).BeginInit();
            this.SuspendLayout();
            // 
            // listProjectiles
            // 
            this.listProjectiles.FormattingEnabled = true;
            this.listProjectiles.Location = new System.Drawing.Point(6, 19);
            this.listProjectiles.Name = "listProjectiles";
            this.listProjectiles.Size = new System.Drawing.Size(156, 199);
            this.listProjectiles.TabIndex = 0;
            this.listProjectiles.SelectedIndexChanged += new System.EventHandler(this.listProjectiles_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.btn_help);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.img_projectile);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_new);
            this.groupBox1.Controls.Add(this.listProjectiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(966, 387);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projectiles";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(168, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(792, 381);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridProjectile);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 373);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Projectile Model";
            // 
            // dataGridProjectile
            // 
            this.dataGridProjectile.AllowUserToAddRows = false;
            this.dataGridProjectile.AllowUserToDeleteRows = false;
            this.dataGridProjectile.AllowUserToResizeRows = false;
            this.dataGridProjectile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProjectile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProjectile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProjectile.Location = new System.Drawing.Point(3, 16);
            this.dataGridProjectile.Name = "dataGridProjectile";
            this.dataGridProjectile.RowHeadersVisible = false;
            this.dataGridProjectile.ShowEditingIcon = false;
            this.dataGridProjectile.Size = new System.Drawing.Size(383, 354);
            this.dataGridProjectile.TabIndex = 0;
            this.dataGridProjectile.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProjectile_CellValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridDamage);
            this.groupBox2.Location = new System.Drawing.Point(398, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 373);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Damage Model";
            // 
            // dataGridDamage
            // 
            this.dataGridDamage.AllowUserToAddRows = false;
            this.dataGridDamage.AllowUserToDeleteRows = false;
            this.dataGridDamage.AllowUserToResizeRows = false;
            this.dataGridDamage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDamage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDamage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDamage.Location = new System.Drawing.Point(3, 16);
            this.dataGridDamage.Name = "dataGridDamage";
            this.dataGridDamage.RowHeadersVisible = false;
            this.dataGridDamage.ShowEditingIcon = false;
            this.dataGridDamage.Size = new System.Drawing.Size(383, 354);
            this.dataGridDamage.TabIndex = 0;
            this.dataGridDamage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDamage_CellValueChanged);
            // 
            // btn_help
            // 
            this.btn_help.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_help.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_help.Location = new System.Drawing.Point(36, 356);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(20, 20);
            this.btn_help.TabIndex = 8;
            this.btn_help.Text = "?";
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sprite:";
            // 
            // img_projectile
            // 
            this.img_projectile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.img_projectile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.img_projectile.Location = new System.Drawing.Point(62, 276);
            this.img_projectile.Name = "img_projectile";
            this.img_projectile.Size = new System.Drawing.Size(100, 100);
            this.img_projectile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_projectile.TabIndex = 6;
            this.img_projectile.TabStop = false;
            this.img_projectile.Click += new System.EventHandler(this.img_projectile_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(6, 229);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(87, 229);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 1;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
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
            this.ClientSize = new System.Drawing.Size(966, 387);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectileEditor";
            this.Text = "ProjectileEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectileEditor_FormClosing);
            this.Load += new System.EventHandler(this.ProjectileEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProjectile)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_projectile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listProjectiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox img_projectile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog selectImageDialog;
        private System.Windows.Forms.DataGridView dataGridDamage;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridProjectile;
    }
}