// See https://aka.ms/new-console-template for more information

using ParentChildHierarchyProject.Business;
using ParentChildHierarchyProject.Data.Migrations;



var builder = CreateHostBuilder(args).Build();

var service = builder.Services.GetRequiredService<IEmployeeHierarchyBusiness>();
var employees = EmployeeDataProvider.GetNames();
employees.ForEach(GetHierarchy);

void GetHierarchy(string employeName)
{
    Console.WriteLine($"{employeName} descendants :  ");

    var hierarchy = service.GetDescendants(employeName, EmployeeDataProvider.GetHierarchy());

    // var hierarchy = service.GetAncestors(employeName, EmployeeDataProvider.GetHierarchy());
    // var hierarchy = service.GetFullHierarchy(employeName, EmployeeDataProvider.GetHierarchy());

    foreach (var employee in hierarchy)
    {
        Console.WriteLine($"{employee}");
    }

    Console.WriteLine("-----");
}

Console.ReadKey();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) => services
                .AddSingleton<IEmployeeHierarchyBusiness, EmployeeHierarchyBusiness>());
}