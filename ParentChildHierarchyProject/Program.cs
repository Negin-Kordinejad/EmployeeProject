using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

    //Console.WriteLine($"{employeName} ancestors :  ");
    //var hierarchy = service.GetAncestors(employeName, EmployeeDataProvider.GetHierarchy());

    //Console.WriteLine($"{employeName} full hierarchy :  ");
    //var hierarchy = service.GetFullHierarchy(employeName, EmployeeDataProvider.GetHierarchy());

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