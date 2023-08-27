using ParentChildHierarchyProject.Data.Models;

namespace EmployeeHierarchyProject.Shell
{
    public class PrintEmployeeHierarchy : IPrintEmployeeHierarchy
    {
        public void Print(string employeeName, List<Employee> employeeHierarchy)
        {

            Console.WriteLine($"{employeeName} descendants :  ");
            //Console.WriteLine($"{employeName} ancestors :  ");
            //Console.WriteLine($"{employeName} full hierarchy :  ");

            foreach (var employee in employeeHierarchy)
            {
                Console.WriteLine($"{employee}");
            }

            Console.WriteLine("-----");
        }

    }
}
