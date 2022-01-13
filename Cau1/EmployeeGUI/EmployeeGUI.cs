using Cau1.EmployeeBAL;
using Cau1.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cau1
{
 
    public partial class EmployeeGUI : Form
    {
        Employee_BAL EmpyBAL = new Employee_BAL();
     
        
        DepartmentBAL DPMBAL = new DepartmentBAL();
        public EmployeeGUI()
        {
            InitializeComponent();
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbMa.Text == "")
            {
                MessageBox.Show("Không có đối tượng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
          if (MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                EmployeeBEL emp = new EmployeeBEL();
                emp.IdEmployee = int.Parse(tbMa.Text);
                EmpyBAL.DeleteEmployee(emp);
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstemp = EmpyBAL.ReadEmployee();
            if (tbMa.Text != "" & tbName.Text != "" & tbLocation.Text != "")
            {
                EmployeeBEL emp = new EmployeeBEL();
                emp.IdEmployee = int.Parse(tbMa.Text);
                emp.Name = tbName.Text;
                emp.DateBirth = tbDate.Value;
                emp.Gender = checkBoxGT.Checked;
                emp.PlaceBirth = tbLocation.Text;
                emp.Department = (DepartmentBEL)ComboxDV.SelectedItem;
                EmpyBAL.NewEmployee(emp);
                dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth.ToShortDateString(), emp.Gender, emp.PlaceBirth, emp.Department.Name);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployee.CurrentRow;

            if (tbName.Text != "" & tbLocation.Text != "")
            {
                EmployeeBEL emp = new EmployeeBEL();
                emp.IdEmployee = int.Parse(tbMa.Text);
                emp.Name = tbName.Text;
                emp.DateBirth = tbDate.Value;
                emp.Gender = checkBoxGT.Checked;
                emp.PlaceBirth = tbLocation.Text;
                emp.Department = (DepartmentBEL)ComboxDV.SelectedItem;
                EmpyBAL.EditEmployee(emp);

                row.Cells[0].Value = emp.IdEmployee;
                row.Cells[1].Value = emp.Name;
                row.Cells[2].Value = emp.DateBirth.ToShortDateString();
                row.Cells[3].Value = emp.Gender;
                row.Cells[4].Value = emp.PlaceBirth;
                row.Cells[5].Value = emp.Department.Name;
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
                tbDate.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
                string cb = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
                if (cb == "True")
                {
                    checkBoxGT.Checked = true;
                }
                else
                {
                    checkBoxGT.Checked = false;
                }
                tbLocation.Text = dgvEmployee.Rows[idx].Cells[4].Value.ToString();
                ComboxDV.Text = dgvEmployee.Rows[idx].Cells[5].Value.ToString();
                // tbma.Enabled = false;
            }
        }

        private void EmployeeGUI_Load(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstemp = EmpyBAL.ReadEmployee();
            foreach (EmployeeBEL emp in lstemp)
            {
                dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth.ToShortDateString(), emp.Gender, emp.PlaceBirth, emp.NameDepartment);
            }
            List<DepartmentBEL> lstDepartment = DPMBAL.ReadDepartmentList();
            foreach (DepartmentBEL department in lstDepartment)
            {
                ComboxDV.Items.Add(department);
            }

            ComboxDV.DisplayMember = "Name";
        }
    }
}
