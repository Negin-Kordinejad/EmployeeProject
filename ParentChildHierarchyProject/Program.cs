using EmployeeHierarchyProject.Shell;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParentChildHierarchyProject.Business;
using ParentChildHierarchyProject.Data.Migrations;



var builder = CreateHostBuilder(args).Build();
var service = builder.Services.GetRequiredService<IEmployeeHierarchyBusiness>();
var printService = builder.Services.GetRequiredService<IPrintEmployeeHierarchy>();

var employees = EmployeeDataProvider.GetNames();
employees.ForEach(GetHierarchy);

void GetHierarchy(string employeName)
{
    var employeeHierarchy = EmployeeDataProvider.GetHierarchy();
    var hierarchy = service.GetDescendants(employeName, EmployeeDataProvider.GetHierarchy());
    //var hierarchy = service.GetAncestors(employeName, EmployeeDataProvider.GetHierarchy());
    //var hierarchy = service.GetFullHierarchy(employeName, EmployeeDataProvider.GetHierarchy());

    printService.Print(employeName, hierarchy);
}

Console.ReadKey();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) => services
                .AddSingleton<IEmployeeHierarchyBusiness, EmployeeHierarchyBusiness>()
                .AddSingleton<IPrintEmployeeHierarchy, PrintEmployeeHierarchy>()
            );
}