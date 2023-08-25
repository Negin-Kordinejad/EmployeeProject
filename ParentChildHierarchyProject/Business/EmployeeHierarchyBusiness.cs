using ParentChildHierarchyProject.Data.Models;

namespace ParentChildHierarchyProject.Business
{
    public class EmployeeHierarchyBusiness : IEmployeeHierarchyBusiness
    {
        /// <summary>
        /// Get full employee hierarchy of an employee.
        /// </summary>
        public List<Employee> GetFullHierarchy(string employee, List<Employee> employeeHierarchies)
        {
            var parents = GetAncestors(employee, employeeHierarchies);
            var children = GetDescendants(employee, employeeHierarchies);

            return parents.Union(children).ToList();
        }

        /// <summary>
        /// Get parents employee hierarchy for an employee.
        /// </summary>
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

        /// <summary>
        /// Get childern employee hierarchy for an employee.
        /// </summary>
        public List<Employee> GetDescendants(string parent, List<Employee> employeeHierarchies)
        {
            var result = new List<Employee>();
            // Find the childeren of the parent
            var children = employeeHierarchies.Where(_ => _.Parent == parent);
            // Call the method for every child until the end and add them to the list. 
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
