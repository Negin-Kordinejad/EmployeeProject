using ParentChildHierarchyProject.Data.Models;

namespace EmployeeHierarchyProject.Shell
{
    public interface IPrintEmployeeHierarchy
    {
        void Print(string employeeName, List<Employee> employeeHierarchy);
    }
}