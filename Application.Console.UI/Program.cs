using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities;
using Application.DataAccess;
namespace Application.UI
{
    internal class Program
    {
        static IDataAccess<Department, int> dsDept = new DepartmentDataAccess();
        static IDataAccess<Employee, int> dsEmp = new EmployeeDataAccess();
        static void Main(string[] args)
        {
            string ch,ch2;
            Console.WriteLine("ADO.NET Connected Architecture");
            do
            {
                Console.WriteLine("Select The Table:\n1.Department\n2.Employee");
                int tbl = Convert.ToInt32(Console.ReadLine());
                switch (tbl)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("Enter your Choice");
                            Console.WriteLine("1. Read All Records");
                            Console.WriteLine("2. Read Record by Primary Key");
                            Console.WriteLine("3. Create New Record");
                            Console.WriteLine("4. Update Exisiting Record");
                            Console.WriteLine("5. Delete Record");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    try
                                    {
                                        var Departments = dsDept.Get();
                                        PrintResults(Departments);
                                        Console.WriteLine();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter Department No.:");
                                        Console.Write("DeptNo: ");
                                        int DeptNo = Convert.ToInt32(Console.ReadLine());
                                        try
                                        {
                                            Department dept = new Department();
                                            dept = dsDept.Get(DeptNo);
                                            PrintDepartment(dept);
                                            Console.WriteLine();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Error Occurred {ex.Message}");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }

                                    break;
                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter Department Details:");
                                        Console.Write("DeptNo: ");
                                        Department department = new Department();
                                        department.DeptNo = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("DeptName: ");
                                        department.DeptName = Console.ReadLine();
                                        Console.Write("Location: ");
                                        department.Location = Console.ReadLine();
                                        Console.Write("Capacity: ");
                                        department.Capacity = Convert.ToInt32(Console.ReadLine());
                                        CreateDepartment(department);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                case 5:
                                    try
                                    {
                                        Console.WriteLine("Enter Department No.:");
                                        Console.Write("DeptNo: ");
                                        int DeptNo = Convert.ToInt32(Console.ReadLine());
                                        DeleteDepartment(DeptNo);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Enter Department No.:");
                                        Console.Write("DeptNo: ");
                                        Department department = new Department();
                                        department.DeptNo = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("DeptName: ");
                                        department.DeptName = Console.ReadLine();
                                        Console.Write("Location: ");
                                        department.Location = Console.ReadLine();
                                        Console.Write("Capacity: ");
                                        department.Capacity = Convert.ToInt32(Console.ReadLine());
                                        UpdateDepartment(department);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }
                            Console.Write("Do You Wish to Continue? (Y/N):");
                            ch = Console.ReadLine();
                            Console.Clear();

                        } while (ch == "Y" || ch == "y");
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("Enter your Choice");
                            Console.WriteLine("1. Read All Records");
                            Console.WriteLine("2. Read Record by Primary Key");
                            Console.WriteLine("3. Create New Record");
                            Console.WriteLine("4. Update Exisiting Record");
                            Console.WriteLine("5. Delete Record");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    try
                                    {
                                        var Employees = dsEmp.Get();
                                        PrintEmployeeTable(Employees);
                                        Console.WriteLine();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter Employee No.:");
                                        Console.Write("EmpNo: ");
                                        int EmpNo = Convert.ToInt32(Console.ReadLine());
                                        try
                                        {
                                            Employee emp = new Employee();
                                            emp = dsEmp.Get(EmpNo);
                                            PrintEmployee(emp);
                                            Console.WriteLine();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Error Occurred {ex.Message}");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }

                                    break;
                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter Employee Details:");
                                        Console.Write("EmpNo: ");
                                        Employee employee = new Employee();
                                        employee.EmpNo = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("EmpName: ");
                                        employee.EmpName = Console.ReadLine();
                                        Console.Write("Designation: ");
                                        employee.Designation = Console.ReadLine();
                                        Console.Write("Salary: ");
                                        employee.Salary = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("DeptNo: ");
                                        employee.DeptNo = Convert.ToInt32(Console.ReadLine());
                                        CreateEmployee(employee);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                case 5:
                                    try
                                    {
                                        Console.WriteLine("Enter Employee No.:");
                                        Console.Write("EmpNo: ");
                                        int EmpNo = Convert.ToInt32(Console.ReadLine());
                                        DeleteEmployee(EmpNo);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Enter Employee No.:");
                                        Console.Write("EmpNo: ");
                                        Employee employee = new Employee();
                                        employee.EmpNo = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("EmpName: ");
                                        employee.EmpName = Console.ReadLine();
                                        Console.Write("Designation: ");
                                        employee.Designation = Console.ReadLine();
                                        Console.Write("Salary: ");
                                        employee.Salary = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("DeptNo: ");
                                        employee.DeptNo = Convert.ToInt32(Console.ReadLine());
                                        UpdateEmployee(employee);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error Occurred {ex.Message}");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }
                            Console.Write("Do You Wish to Continue? (Y/N):");
                            ch = Console.ReadLine();
                            Console.Clear();

                        } while (ch == "Y" || ch == "y");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Do You Wish to Continue? (Y/N)");
                ch2 = Console.ReadLine();
                Console.Clear();

            }while(ch2 == "Y" || ch2 == "y");
            
            
        }

        static void PrintResults(IEnumerable<Department> depts)
        {
            Console.WriteLine("DeptNo   DeptName    Location    Capacity");
            foreach (var dept in depts)
            {
                Console.WriteLine($"{dept.DeptNo}   {dept.DeptName} {dept.Location} {dept.Capacity}");
            }
        }
        static void CreateDepartment(Department department)
        {
            dsDept.Create(department);
        }

        static void DeleteDepartment(int DeptNo)
        {
            dsDept.Delete(DeptNo);
        }

        static void PrintDepartment(Department dept)
        {
            Console.WriteLine("DeptNo   DeptName    Location    Capacity");
            Console.WriteLine($"{dept.DeptNo}   {dept.DeptName} {dept.Location} {dept.Capacity}");
        }

        static void UpdateDepartment(Department dept)
        {
            dsDept.Update(dept.DeptNo, dept);
        }

        static void PrintEmployeeTable(IEnumerable<Employee> emps)
        {
            Console.WriteLine("EmpNo   EmpName    Designation    Salary     DeptNo");
            foreach (var emp in emps)
            {
                Console.WriteLine($"{emp.EmpNo}   {emp.EmpName}     {emp.Designation}   {emp.Salary}      {emp.DeptNo}");
            }
        }
        static void CreateEmployee(Employee employee)
        {
            dsEmp.Create(employee);
        }

        static void DeleteEmployee(int EmpNo)
        {
            dsEmp.Delete(EmpNo);
        }

        static void PrintEmployee(Employee emp)
        {
            Console.WriteLine("EmpNo   EmpName    Designation    Salary     DeptNo"); 
            Console.WriteLine($"{emp.EmpNo}   {emp.EmpName}     {emp.Designation}   {emp.Salary}      {emp.DeptNo}");
        }

        static void UpdateEmployee(Employee emp)
        {
            dsEmp.Update(emp.EmpNo, emp);
        }

    }
}
