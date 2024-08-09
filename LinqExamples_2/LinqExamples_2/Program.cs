using System.Collections;

namespace LinqExamples_2 {
  public class Program {
    public static void Main(string[] args) {
      List<Employee> employeeList = Data.GetEmployees();
      List<Department> departmentList = Data.GetDepartments();
      Employee searchEmployee = new Employee {
          Id = 3,
          FirstName = "Douglas",
          LastName = "Roberts",
          AnnualSalary = 40000.2m,
          IsManager = false,
          DepartmentId = 2
      };
      
      
      // var results = employeeList.Join(departmentList, e => e.DepartmentId, d => d.Id,
      //                                 (emp, dept) => new {
      //                                     Id = emp.Id,
      //                                     FirstName = emp.FirstName,
      //                                     LastName = emp.LastName,
      //                                     AnnualSalary = emp.AnnualSalary,
      //                                     DepartmentId = emp.DepartmentId,
      //                                     DepartmentName = dept.LongName
      //                                 }).OrderBy(o => o.DepartmentId).ThenByDescending(o => o.AnnualSalary);
      //
      // foreach (var item in results) {
      //   Console.WriteLine(
      //       $"Id: {item.Id,-5} First Name: {item.FirstName,-10} Last Name: {item.LastName,-10} AnnualSalary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");
      // }

      // var results = from emp in employeeList
      //               join dept in departmentList
      //                   on emp.DepartmentId equals dept.Id
      //               orderby emp.DepartmentId, emp.AnnualSalary descending
      //               select new {
      //                   Id = emp.Id,
      //                   FirstName = emp.FirstName,
      //                   LastName = emp.LastName,
      //                   AnnualSalary = emp.AnnualSalary,
      //                   DepartmentId = emp.DepartmentId,
      //                   DepartmentName = dept.LongName
      //               };
      // foreach (var item in results) {
      //   Console.WriteLine(
      //       $"Id: {item.Id,-5} First Name: {item.FirstName,-10} Last Name: {item.LastName,-10} AnnualSalary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");
      // }

      // bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());
      //
      // if (containsEmployee) {
      //   Console.WriteLine($"An employee frecord for {searchEmployee.FirstName} {searchEmployee.LastName} was found.");
      // }
      // else {
      //   Console.WriteLine($"An employee frecord for {searchEmployee.FirstName} {searchEmployee.LastName} was NOT found.");
      // }

      // ArrayList mixeddCollection = Data.GetHeterogenousDataCollection();

      // var stringResult = from s in mixeddCollection.OfType<string>()
      //                    select s;
      
      // var intResult = from i in mixeddCollection.OfType<int>()
      //                    select i;
      
      // var employeeResult = from e in mixeddCollection.OfType<Employee>()
      //                    select e;
      //
      // foreach(var item in employeeResult)
      //   Console.WriteLine(item);

      var emp = employeeList.SingleOrDefault(e => e.Id == 8);
      Console.WriteLine($"{emp.FirstName} {emp.LastName}");
    }
  }
  
  public class EmployeeComparer : IEqualityComparer<Employee> {
      public bool Equals(Employee x, Employee y) {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && x.AnnualSalary == y.AnnualSalary && x.IsManager == y.IsManager && x.DepartmentId == y.DepartmentId;
      }

      public int GetHashCode(Employee obj) {
        return HashCode.Combine(obj.Id, obj.FirstName, obj.LastName, obj.AnnualSalary, obj.IsManager, obj.DepartmentId);
      }
    }

    public class Employee {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public decimal AnnualSalary { get; set; }
      public bool IsManager { get; set; }
      public int DepartmentId { get; set; }
    }

    public class Department {
      public int Id { get; set; }
      public string ShortName { get; set; }
      public string LongName { get; set; }
    }

    public static class Data {
      public static List<Employee> GetEmployees() {
        List<Employee> employees = new List<Employee>();

        Employee employee = new Employee {
            Id = 1,
            FirstName = "Bob",
            LastName = "Jones",
            AnnualSalary = 60000.3m,
            IsManager = true,
            DepartmentId = 1
        };
        employees.Add(employee);

        employee = new Employee {
            Id = 2,
            FirstName = "Sarah",
            LastName = "Jameson",
            AnnualSalary = 80000.3m,
            IsManager = true,
            DepartmentId = 3
        };
        employees.Add(employee);

        employee = new Employee {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);

        employee = new Employee {
            Id = 4,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 30000.2m,
            IsManager = false,
            DepartmentId = 3
        };
        employees.Add(employee);

        return employees;
      }

      public static List<Department> GetDepartments() {
        List<Department> departments = new List<Department>();

        Department department = new Department {
            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources"
        };
        departments.Add(department);

        department = new Department {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance"
        };
        departments.Add(department);

        department = new Department {
            Id = 3,
            ShortName = "TE",
            LongName = "Technology"
        };
        departments.Add(department);

        return departments;
      }

      public static ArrayList GetHeterogenousDataCollection() {
        ArrayList arrayList = new ArrayList();

        arrayList.Add(100);
        arrayList.Add("Bob Jones");
        arrayList.Add(2000);
        arrayList.Add(3000);
        arrayList.Add("Bill Henderson");
        arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName="Dale", AnnualSalary = 90000, IsManager = true, DepartmentId = 1});
        arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName="Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2});
        arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
        arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
        arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

        return arrayList;
      }
    }
}