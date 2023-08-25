namespace ParentChildHierarchyProject.Data.Models
{
    public class Employee
    {
        public string Parent { get; set; }
        public string Child { get; set; }
        public override string ToString()
        {
            return $"Parent: {Parent} <=> Child: {Child}";
        }
    }
}
