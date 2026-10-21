namespace Bai4_StudentMdi
{
    partial class frmStudent
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
            this.components = new System.ComponentModel.Container();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnChooseAvatar = new System.Windows.Forms.Button();
            this.grpAsync = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblLoadInfo = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.ctxGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.grpAsync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.ctxGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();

            this.grpInput.Controls.Add(this.lblStudentId);
            this.grpInput.Controls.Add(this.txtStudentId);
            this.grpInput.Controls.Add(this.lblFullName);
            this.grpInput.Controls.Add(this.txtFullName);
            this.grpInput.Controls.Add(this.lblAge);
            this.grpInput.Controls.Add(this.txtAge);
            this.grpInput.Controls.Add(this.lblGender);
            this.grpInput.Controls.Add(this.cboGender);
            this.grpInput.Controls.Add(this.picAvatar);
            this.grpInput.Controls.Add(this.btnChooseAvatar);
            this.grpInput.Location = new System.Drawing.Point(15, 15);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(505, 215);
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Thông tin sinh viên";

            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(20, 33);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Text = "Mã SV:";

            this.txtStudentId.Location = new System.Drawing.Point(110, 30);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(170, 23);
            this.txtStudentId.TabIndex = 0;

            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 73);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Text = "Họ tên:";

            this.txtFullName.Location = new System.Drawing.Point(110, 70);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(170, 23);
            this.txtFullName.TabIndex = 1;

            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(20, 113);
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "Tuổi:";

            this.txtAge.Location = new System.Drawing.Point(110, 110);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(170, 23);
            this.txtAge.TabIndex = 2;

            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(20, 153);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Giới tính:";

            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cboGender.Location = new System.Drawing.Point(110, 150);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(170, 23);
            this.cboGender.TabIndex = 3;

            this.picAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(305, 25);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(180, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabStop = false;

            this.btnChooseAvatar.Location = new System.Drawing.Point(305, 180);
            this.btnChooseAvatar.Name = "btnChooseAvatar";
            this.btnChooseAvatar.Size = new System.Drawing.Size(180, 26);
            this.btnChooseAvatar.TabIndex = 4;
            this.btnChooseAvatar.Text = "Chọn ảnh";
            this.btnChooseAvatar.UseVisualStyleBackColor = true;
            this.btnChooseAvatar.Click += new System.EventHandler(this.btnChooseAvatar_Click);

            this.grpAsync.Controls.Add(this.btnLoad);
            this.grpAsync.Controls.Add(this.progressBar1);
            this.grpAsync.Controls.Add(this.lblPercent);
            this.grpAsync.Controls.Add(this.lblLoadInfo);
            this.grpAsync.Location = new System.Drawing.Point(530, 15);
            this.grpAsync.Name = "grpAsync";
            this.grpAsync.Size = new System.Drawing.Size(275, 215);
            this.grpAsync.TabStop = false;
            this.grpAsync.Text = "Nạp dữ liệu bất đồng bộ";

            this.btnLoad.Location = new System.Drawing.Point(15, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(245, 36);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Nạp dữ liệu (async)";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.progressBar1.Location = new System.Drawing.Point(15, 85);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(245, 24);

            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPercent.Location = new System.Drawing.Point(15, 118);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Text = "0%";

            this.lblLoadInfo.Location = new System.Drawing.Point(15, 152);
            this.lblLoadInfo.Name = "lblLoadInfo";
            this.lblLoadInfo.Size = new System.Drawing.Size(245, 50);
            this.lblLoadInfo.Text = "Giả lập nạp 50 sinh viên (khoảng 4 giây). Trong lúc nạp vẫn có thể di chuyển form, dùng menu.";

            this.btnAdd.Location = new System.Drawing.Point(15, 242);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(145, 242);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 34);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(275, 242);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnExport.Location = new System.Drawing.Point(405, 242);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 34);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Xuất file CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStudents.ContextMenuStrip = this.ctxGrid;           
            this.dgvStudents.Location = new System.Drawing.Point(15, 290);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(790, 255);
            this.dgvStudents.TabIndex = 9;
            this.dgvStudents.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStudents_CellMouseDown);

            this.ctxGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ctxDelete, this.ctxRefresh, this.ctxDetail });
            this.ctxGrid.Name = "ctxGrid";

            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Text = "Xóa dòng";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);

            this.ctxRefresh.Name = "ctxRefresh";
            this.ctxRefresh.Text = "Làm mới dữ liệu";
            this.ctxRefresh.Click += new System.EventHandler(this.ctxRefresh_Click);

            this.ctxDetail.Name = "ctxDetail";
            this.ctxDetail.Text = "Xem chi tiết";
            this.ctxDetail.Click += new System.EventHandler(this.ctxDetail_Click);

            this.errorProvider.ContainerControl = this;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpAsync);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvStudents);
            this.MinimumSize = new System.Drawing.Size(720, 520);
            this.Name = "frmStudent";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.frmStudent_Load);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.grpAsync.ResumeLayout(false);
            this.grpAsync.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ctxGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseAvatar;
        private System.Windows.Forms.GroupBox grpAsync;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblLoadInfo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ContextMenuStrip ctxGrid;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxRefresh;
        private System.Windows.Forms.ToolStripMenuItem ctxDetail;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}