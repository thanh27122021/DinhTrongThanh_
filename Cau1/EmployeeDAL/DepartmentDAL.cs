using Cau1.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmployeeDAL
{
    public class DepartmentDAL : DBConnection
    {

        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectAllDepartment1", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentBEL> lstArea = new List<DepartmentBEL>();
            while (reader.Read())
            {
                DepartmentBEL area = new DepartmentBEL
                {
                    IdDepartment = reader["IdDepartment"].ToString(),
                    Name = reader["Name"].ToString()
                };
                lstArea.Add(area);
            }
            conn.Close();
            return lstArea;
        }



        public DepartmentBEL ReadDepartment(string IdDepartment)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            // SqlCommand cmd = new SqlCommand("select*from Department where IdDepartment = "+"'"+IdDepartment.ToString()+"'", conn); ;
            //lấy dl 
            SqlCommand cmd = new SqlCommand("SelectDepartment1", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@IdDepartment", SqlDbType.NVarChar).Value = IdDepartment;
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentBEL dep = new DepartmentBEL();
            if (reader.HasRows && reader.Read())
            {
                dep.IdDepartment = reader["IdDepartment"].ToString();
                dep.Name = reader["Name"].ToString();
            }
            conn.Close();
            return dep;
        }
    }
}
