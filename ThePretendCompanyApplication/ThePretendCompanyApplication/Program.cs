using TCPData;
using TCPExtensions;

namespace ThePretendCompanyApplication {
  class Program {
    static void Main(string[] args) {
      List<Employee> employeeList = Data.GetEmployees();
      //
      // var filteredEmployees = employeeList.Filter(emp => emp.IsManager == true);
      //
      // foreach (var employee in filteredEmployees) {
      //   Console.WriteLine($"First Name: {employee.FirstName}");
      //   Console.WriteLine($"Last Name: {employee.LastName}");
      //   Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
      //   Console.WriteLine($"Manager: {employee.IsManager}");
      //   Console.WriteLine();
      // }
      
      List<Department> departmentList = Data.GetDepartments();
      // var filteredDepartments= departmentList.Filter(dep => dep.ShortName == "FN"
      //   || dep.ShortName =="HR");
      //
      // var filteredDepartments = departmentList.Where(
      //   dep => dep.ShortName == "FN" || dep.ShortName == "HR");
      //
      // foreach (var department in filteredDepartments) {
      //   Console.WriteLine($"Short Name: {department.ShortName}");
      //   Console.WriteLine($"Long Name: {department.LongName}");
      //   Console.WriteLine();
      // }

      var resultList = from emp in employeeList
        join dept in departmentList
          on emp.DepartmentId equals dept.Id
        select new {
          FirstName = emp.FirstName,
          LastName = emp.LastName,
          AnnualSalary = emp.AnnualSalary,
          Manager = emp.IsManager,
          Department = dept.LongName
        };
      
      foreach (var employee in resultList) {
        Console.WriteLine($"First Name: {employee.FirstName}");
        Console.WriteLine($"Last Name: {employee.LastName}");
        Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
        Console.WriteLine($"Manager: {employee.Manager}");
        Console.WriteLine($"Department: {employee.Department}");
        Console.WriteLine();
      }

      var averageSalary = resultList.Average(a => a.AnnualSalary);
      Console.WriteLine($"Average Salary: {averageSalary}");
      var maxSalary = resultList.Max(a => a.AnnualSalary);
      Console.WriteLine($"Max Salary: {maxSalary}");
      
    }
  }
}