namespace QuanLyThuVien.Views
{
    partial class frmTraSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraSach));
            this.dtNGAYLAP = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtGVCHITIETPHIEU = new System.Windows.Forms.DataGridView();
            this.dtGVPHIEUMUONTRA = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVCHITIETPHIEU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPHIEUMUONTRA)).BeginInit();
            this.SuspendLayout();
            // 
            // dtNGAYLAP
            // 
            this.dtNGAYLAP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNGAYLAP.Location = new System.Drawing.Point(504, 16);
            this.dtNGAYLAP.Name = "dtNGAYLAP";
            this.dtNGAYLAP.Size = new System.Drawing.Size(208, 20);
            this.dtNGAYLAP.TabIndex = 316;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.btnThem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(13, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(89, 35);
            this.btnThem.TabIndex = 313;
            this.btnThem.Text = "Trả sách";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.Blue;
            this.btnTim.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(718, 8);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(87, 35);
            this.btnTim.TabIndex = 311;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(423, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 310;
            this.label3.Text = "Ngày lập";
            // 
            // dtGVCHITIETPHIEU
            // 
            this.dtGVCHITIETPHIEU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVCHITIETPHIEU.BackgroundColor = System.Drawing.Color.White;
            this.dtGVCHITIETPHIEU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVCHITIETPHIEU.Location = new System.Drawing.Point(2, 367);
            this.dtGVCHITIETPHIEU.Name = "dtGVCHITIETPHIEU";
            this.dtGVCHITIETPHIEU.Size = new System.Drawing.Size(981, 192);
            this.dtGVCHITIETPHIEU.TabIndex = 309;
            // 
            // dtGVPHIEUMUONTRA
            // 
            this.dtGVPHIEUMUONTRA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVPHIEUMUONTRA.BackgroundColor = System.Drawing.Color.White;
            this.dtGVPHIEUMUONTRA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPHIEUMUONTRA.Location = new System.Drawing.Point(2, 56);
            this.dtGVPHIEUMUONTRA.Name = "dtGVPHIEUMUONTRA";
            this.dtGVPHIEUMUONTRA.Size = new System.Drawing.Size(981, 307);
            this.dtGVPHIEUMUONTRA.TabIndex = 308;
            this.dtGVPHIEUMUONTRA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVPHIEUMUONTRA_CellClick);
            // 
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(984, 567);
            this.Controls.Add(this.dtNGAYLAP);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtGVCHITIETPHIEU);
            this.Controls.Add(this.dtGVPHIEUMUONTRA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTraSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả sách";
            this.Load += new System.EventHandler(this.frmTraSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVCHITIETPHIEU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPHIEUMUONTRA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtNGAYLAP;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtGVCHITIETPHIEU;
        private System.Windows.Forms.DataGridView dtGVPHIEUMUONTRA;
    }
}