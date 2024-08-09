namespace LINQExamples_3;

public class Program {
  public static void Main(string[] args) {
    List<Employee> employeeList = Data.GetEmployees();
    List<Department> departmentList = Data.GetDepartments();
    
    //// Equality Operator
    //// SequenceEqual
    // var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
    // var integerList2 = new List<int> { 1, 2, 3, 4, 5, 7 };
    //
    // var boolSequenceEqual = integerList1.SequenceEqual(integerList2);
    //
    // Console.WriteLine(boolSequenceEqual);

    var employeeListCompare = Data.GetEmployees();
    bool boolSE = employeeList.SequenceEqual(employeeListCompare, new EmployeeComparer());
    
    Console.WriteLine(boolSE);
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
    }