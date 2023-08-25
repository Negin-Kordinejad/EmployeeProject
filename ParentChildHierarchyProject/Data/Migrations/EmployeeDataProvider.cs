using ParentChildHierarchyProject.Data.Models;

namespace ParentChildHierarchyProject.Data.Migrations
{
    public static class EmployeeDataProvider
    {
        public static List<Employee> GetHierarchy()
        {
            return new List<Employee>
            {
                new() { Parent = "Fred", Child = "Eric"},
                new() { Parent = "Fred", Child = "Clarrie"},
                new() { Parent = "Fred", Child = "Trevor"},
                new() { Parent = "Eric", Child = "Marilyn"},
                new() { Parent = "Eric", Child = "Rodney"},
                new() { Parent = "Eric", Child = "Carl"},
                new() { Parent = "Trevor", Child = "Ross"},
                new() { Parent = "Trevor", Child = "David"},
                new() { Parent = "Trevor", Child = "Donald"},
                new() { Parent = "Trevor", Child = "Darrell"},
                new() { Parent = "Ross", Child = "Lisa"},
                new() { Parent = "Ross", Child = "Ryan"},
                new() { Parent = "Ross", Child = "Matthew"},
                new() { Parent = "Donald", Child = "Joel"},
                new() { Parent = "Darrell", Child = "Ben"},
                new() { Parent = "Lisa", Child = "Atalia"},
                new() { Parent = "Ryan", Child = "Max"},
                new() { Parent = "Matthew", Child = "Luke"},
                new() { Parent = "Matthew", Child = "Jane"},
            };
        }

        public static List<string> GetNames()
        {
            var hierarchy = GetHierarchy();
            return hierarchy
                .Select(signal => signal.Parent)
                .Union(hierarchy
                    .Select(signal => signal.Child))
                .Distinct()
                .ToList();

        }
    }
}
