using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bai4_StudentMdi
{
    public class Student : INotifyPropertyChanged
    {
        private string studentId = "";
        private string fullName = "";
        private int age;
        private string gender = "Nam";
        private string avatarPath = "";

        public event PropertyChangedEventHandler PropertyChanged;

        private void Raise(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string StudentId
        {
            get { return studentId; }
            set { if (studentId != value) { studentId = value; Raise(nameof(StudentId)); } }
        }

        public string FullName
        {
            get { return fullName; }
            set { if (fullName != value) { fullName = value; Raise(nameof(FullName)); } }
        }

        public int Age
        {
            get { return age; }
            set { if (age != value) { age = value; Raise(nameof(Age)); } }
        }

        public string Gender
        {
            get { return gender; }
            set { if (gender != value) { gender = value; Raise(nameof(Gender)); } }
        }

        public string AvatarPath
        {
            get { return avatarPath; }
            set
            {
                if (avatarPath != value)
                {
                    avatarPath = value;
                    Raise(nameof(AvatarPath));
                    Raise(nameof(AvatarFileName));
                }
            }
        }

        public string AvatarFileName
        {
            get { return string.IsNullOrEmpty(avatarPath) ? "" : Path.GetFileName(avatarPath); }
        }
    }

    public partial class frmStudent : Form
    {
        private const char Delimiter = ';';
        private readonly BindingList<Student> students = new BindingList<Student>();
        private readonly BindingSource bsStudents = new BindingSource();
        private int nextId = 1;

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            InitGrid();

            bsStudents.DataSource = students;
            dgvStudents.DataSource = bsStudents;
            SetupBindings();
            bsStudents.CurrentChanged += bsStudents_CurrentChanged;

            students.Add(new Student { StudentId = "SV001", FullName = "Nguyễn Văn An", Age = 20, Gender = "Nam" });
            students.Add(new Student { StudentId = "SV002", FullName = "Trần Thị Bình", Age = 19, Gender = "Nữ" });
            students.Add(new Student { StudentId = "SV003", FullName = "Lê Minh Châu", Age = 21, Gender = "Nữ" });
            nextId = 4;

            bsStudents.Position = 0;
            UpdateInputState();

            frmMain main = this.MdiParent as frmMain;
            if (main != null)
                this.Text = "Quản lý sinh viên - " + main.CurrentUser;
        }

        private void InitGrid()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã SV", DataPropertyName = "StudentId", FillWeight = 14 });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "FullName", FillWeight = 36 });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tuổi",
                DataPropertyName = "Age",
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giới tính", DataPropertyName = "Gender", FillWeight = 14 });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tệp ảnh", DataPropertyName = "AvatarFileName", FillWeight = 26 });
        }

        private void SetupBindings()
        {
            txtStudentId.DataBindings.Add("Text", bsStudents, "StudentId", true, DataSourceUpdateMode.OnValidation);

            txtFullName.DataBindings.Add("Text", bsStudents, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding ageBinding = txtAge.DataBindings.Add("Text", bsStudents, "Age", true, DataSourceUpdateMode.OnValidation);
            ageBinding.BindingComplete += AgeBinding_BindingComplete;

            cboGender.DataBindings.Add("SelectedItem", bsStudents, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void AgeBinding_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Success)
                errorProvider.SetError(txtAge, "");
            else
                errorProvider.SetError(txtAge, "Tuổi phải là số nguyên hợp lệ!");
        }

        private void bsStudents_CurrentChanged(object sender, EventArgs e)
        {
            Student s = bsStudents.Current as Student;
            ShowAvatar(s != null ? s.AvatarPath : "");
            ClearErrors();
        }

        private void ShowAvatar(string path)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }

            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

            try
            {
                using (Image temp = Image.FromFile(path))
                {
                    picAvatar.Image = new Bitmap(temp);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            Student s = bsStudents.Current as Student;
            if (s == null)
            {
                MessageBox.Show("Hãy chọn một sinh viên trước!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Tệp hình ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    s.AvatarPath = ofd.FileName;
                    ShowAvatar(s.AvatarPath);
                    Notify("Đã đổi ảnh đại diện của " + s.StudentId);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student
            {
                StudentId = "SV" + nextId.ToString("000"),
                FullName = "",
                Age = 18,
                Gender = "Nam"
            };
            nextId++;

            students.Add(s);
            bsStudents.Position = bsStudents.Count - 1;
            UpdateInputState();
            txtFullName.Focus();

            Notify("Đã thêm sinh viên " + s.StudentId + " (hãy nhập thông tin)");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s = bsStudents.Current as Student;
            if (s == null)
            {
                MessageBox.Show("Chưa có sinh viên nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Validate();
            bsStudents.EndEdit();

            ClearErrors();
            bool ok = true;
            string id = txtStudentId.Text.Trim();
            if (id == "")
            {
                errorProvider.SetError(txtStudentId, "Mã SV không được để trống!");
                ok = false;
            }
            else
            {
                foreach (Student other in students)                     
                {
                    if (other != s && string.Equals(other.StudentId, id, StringComparison.OrdinalIgnoreCase))
                    {
                        errorProvider.SetError(txtStudentId, "Mã SV đã tồn tại!");
                        ok = false;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(txtAge)) || s.Age <= 0 || s.Age > 70)
            {
                errorProvider.SetError(txtAge, "Tuổi không hợp lệ!");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(s.FullName))
            {
                errorProvider.SetError(txtFullName, "Họ tên không được để trống!");
                ok = false;
            }
            if (!ok) return;

            Notify("Đã cập nhật sinh viên " + s.StudentId);
            MessageBox.Show("Đã cập nhật thông tin sinh viên " + s.StudentId + ".", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void DeleteCurrent()
        {
            Student s = bsStudents.Current as Student;
            if (s == null)
            {
                MessageBox.Show("Hãy chọn một sinh viên cần xóa!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên \"" + s.FullName + "\" (" + s.StudentId + ")?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bsStudents.RemoveCurrent();
                UpdateInputState();
                Notify("Đã xóa sinh viên " + s.StudentId);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Validate();
            bsStudents.EndEdit();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sinh viên";
                sfd.Filter = "Tệp CSV (*.csv)|*.csv";
                sfd.FileName = "SinhVien_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                List<string> lines = new List<string>();
                lines.Add(string.Join(Delimiter.ToString(), "StudentId", "FullName", "Age", "Gender", "AvatarPath"));

                foreach (Student s in students)
                {
                    lines.Add(string.Join(Delimiter.ToString(),
                        CsvEscape(s.StudentId),
                        CsvEscape(s.FullName),
                        s.Age.ToString(),
                        CsvEscape(s.Gender),
                        CsvEscape(s.AvatarPath)));
                }

                try
                {
                    File.WriteAllLines(sfd.FileName, lines, new UTF8Encoding(true));
                    Notify("Đã xuất " + students.Count + " sinh viên ra CSV");
                    MessageBox.Show("Đã xuất " + students.Count + " sinh viên ra file:\n" + sfd.FileName,
                                    "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string CsvEscape(string value)
        {
            if (value == null) return "";
            if (value.IndexOfAny(new char[] { Delimiter, '"', '\n', '\r' }) >= 0)
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private void dgvStudents_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvStudents.ClearSelection();
                dgvStudents.Rows[e.RowIndex].Selected = true;
                dgvStudents.CurrentCell = dgvStudents.Rows[e.RowIndex].Cells[0];
            }
        }

        private void ctxDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }
        private void ctxRefresh_Click(object sender, EventArgs e)
        {
            btnLoad.PerformClick();
        }

        private void ctxDetail_Click(object sender, EventArgs e)
        {
            Student s = bsStudents.Current as Student;
            if (s == null) return;

            MessageBox.Show("Mã SV: " + s.StudentId + "\n" +
                            "Họ tên: " + s.FullName + "\n" +
                            "Tuổi: " + s.Age + "\n" +
                            "Giới tính: " + s.Gender + "\n" +
                            "Ảnh: " + (string.IsNullOrEmpty(s.AvatarPath) ? "(chưa có)" : s.AvatarPath),
                            "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Notify(string message)
        {
            frmMain main = this.MdiParent as frmMain;
            if (main != null)
                main.SetStatusMessage(message);
        }

        private async Task<List<Student>> LoadStudentsAsync(IProgress<int> progress)
        {
            return await Task.Run(() =>
            {
                List<Student> list = new List<Student>();
                const int total = 50;

                for (int i = 1; i <= total; i++)
                {
                    Thread.Sleep(80);

                    list.Add(new Student
                    {
                        StudentId = "SV" + i.ToString("000"),
                        FullName = "Sinh viên số " + i,
                        Age = 18 + (i % 8),
                        Gender = (i % 2 == 0) ? "Nữ" : "Nam"
                    });

                    if (progress != null)
                        progress.Report(i * 100 / total);
                }
                return list;
            });
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            frmMain main = this.MdiParent as frmMain;
            string message;
            btnLoad.Enabled = false;
            progressBar1.Value = 0;
            lblPercent.Text = "0%";

            Progress<int> progress = new Progress<int>(percent =>
            {
                if (this.IsDisposed) return;
                progressBar1.Value = percent;
                lblPercent.Text = percent + "%";
                if (main != null)
                    main.ReportProgress(percent, "Đang nạp sinh viên");
            });

            try
            {
                List<Student> data = await LoadStudentsAsync(progress);

                if (this.IsDisposed) return;

                students.Clear();
                foreach (Student s in data)
                    students.Add(s);

                nextId = students.Count + 1;
                progressBar1.Value = 100;
                lblPercent.Text = "100%";
                UpdateInputState();

                message = "Đã nạp xong " + data.Count + " sinh viên.";
            }
            catch (Exception ex)
            {
                message = "Nạp dữ liệu thất bại: " + ex.Message;
            }
            finally
            {
                if (!this.IsDisposed)
                    btnLoad.Enabled = true;
                if (main != null)
                    main.ResetProgress();
            }

            if (!this.IsDisposed)
            {
                Notify(message);
                MessageBox.Show(message, "Nạp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateInputState()
        {
            bool hasData = bsStudents.Count > 0;
            grpInput.Enabled = hasData;
            btnUpdate.Enabled = hasData;
            btnDelete.Enabled = hasData;
            btnExport.Enabled = hasData;
        }

        private void ClearErrors()
        {
            errorProvider.SetError(txtAge, "");
            errorProvider.SetError(txtFullName, "");
        }
    }
}
