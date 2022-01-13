using Cau1.EmployeeDAL;
using Cau1.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmployeeBAL
{
    public class Employee_BAL
    {
        EmployDAL ThanhDAL = new EmployDAL();
        public List<EmployeeBEL> ReadEmployee()
        {
            List<EmployeeBEL> lstCus = ThanhDAL.ReadEmployee();
            return lstCus;
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            ThanhDAL.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            ThanhDAL.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            ThanhDAL.EditEmployee(emp);
        }
    }
}
