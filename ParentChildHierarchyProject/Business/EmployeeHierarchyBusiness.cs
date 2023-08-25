using ParentChildHierarchyProject.Data.Models;

namespace ParentChildHierarchyProject.Business
{
    public class EmployeeHierarchyBusiness : IEmployeeHierarchyBusiness
    {
       
       public List<Employee> GetFullHierarchy(string employee, List<Employee> employeeHierarchies)
        {
            var parents = GetAncestors(employee, employeeHierarchies);
            var children = GetDescendants(employee, employeeHierarchies);

            return parents.Union(children).ToList();
        }

       public List<Employee> GetAncestors(string child, List<Employee> employeeHierarchies)
        {
            var result = new List<Employee>();
            var parent = employeeHierarchies.FirstOrDefault(_ => _.Child == child);
            if (parent != null)
            {
                result.Add(parent);
                var parentsOfParent = GetAncestors(parent.Parent, employeeHierarchies);
                if (parentsOfParent.Count > 0)
                    result.AddRange(parentsOfParent);
            }

            return result;
        }

       public List<Employee> GetDescendants(string parent, List<Employee> employeeHierarchies)
        {
            var result = new List<Employee>();
            var children = employeeHierarchies.Where(_ => _.Parent == parent);
            foreach (var child in children)
            {
                result.Add(child);
                var childrenOfChild = GetDescendants(child.Child, employeeHierarchies);
                if (childrenOfChild.Count > 0)
                    result.AddRange(childrenOfChild);
            }
            return result;
        }
    }
}
