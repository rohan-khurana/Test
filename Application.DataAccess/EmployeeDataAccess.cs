using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities;
using System.Data.SqlClient;
namespace Application.DataAccess
{
    public class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        SqlConnection conn;
        SqlCommand cmd;

        public EmployeeDataAccess()
        {
            conn = new SqlConnection("Data Source=IN-8XSTJM3;Initial Catalog=UCompany;Integrated Security=SSPI");
        }
        Employee IDataAccess<Employee, int>.Create(Employee entity)
        {
            Employee employee = new Employee();
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"INSERT INTO Employee VALUES({entity.EmpNo},'{entity.EmpName}','{entity.Designation}',{entity.Salary},{entity.DeptNo})";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }
            return employee;
        }

        Employee IDataAccess<Employee, int>.Delete(int id)
        {
            Employee employee = null;
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"DELETE FROM Employee WHERE EmpNo={id}";
                int result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    employee = new Employee();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return employee;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.Get()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM Employee";
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                        EmpName = Reader["EmpName"].ToString(),
                        Designation = Reader["Designation"].ToString(),
                        Salary = Convert.ToInt32(Reader["Salary"]),
                        DeptNo = Convert.ToInt32(Reader["DeptNo"])
                    });
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                conn.Close(); 
            }
            return employees;
        }

        Employee IDataAccess<Employee, int>.Get(int id)
        {
            Employee employee = null;
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM Employee WHERE EmpNo={id}";
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    employee = new Employee()
                    {
                        EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                        EmpName = Reader["EmpName"].ToString(),
                        Designation = Reader["Designation"].ToString(),
                        Salary = Convert.ToInt32(Reader["Salary"]),
                        DeptNo = Convert.ToInt32(Reader["DeptNo"])
                    };
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return employee;
        }

        Employee IDataAccess<Employee, int>.Update(int id, Employee entity)
        {
            Employee employee=new Employee();
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"Update Employee set EmpName ='{entity.EmpName}', Designation='{entity.Designation}', Salary={entity.Salary},DeptNo={entity.DeptNo} where EmpNo={entity.EmpNo}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return employee;
        }
    }
}
