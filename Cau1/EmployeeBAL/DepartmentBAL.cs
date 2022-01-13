using Cau1.EmployeeDAL;
using Cau1.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmployeeBAL
{
    public class DepartmentBAL
    {
        DepartmentDAL ThanhDAL = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> lstThanhDAL = ThanhDAL.ReadDepartmentList();
            return lstThanhDAL;
        }
    }
}
