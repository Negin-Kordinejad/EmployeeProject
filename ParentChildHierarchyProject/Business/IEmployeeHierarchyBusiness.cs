using ParentChildHierarchyProject.Data.Models;

namespace ParentChildHierarchyProject.Business
{
    public interface IEmployeeHierarchyBusiness
    {
        List<Employee> GetFullHierarchy(string employee, List<Employee> employeeHierarchies);
        List<Employee> GetAncestors(string child, List<Employee> employeeHierarchies);
        List<Employee> GetDescendants(string parent, List<Employee> employeeHierarchies);
    }
}