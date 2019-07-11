using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidHw
{
    /// //////////////finished task

    //public class WorkReport: IEntryManager<WorkReportEntry>
    //{
    //    private readonly List<WorkReportEntry> _entries;

    //    public WorkReport()
    //    {
    //        _entries = new List<WorkReportEntry>();
    //    }

    //    public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);

    //    public void RemoveEntryAt(int index) => _entries.RemoveAt(index);


    //}

    //// TODO: apply SRP
    //public class FileSaving
    //{
    //    private readonly List<WorkReportEntry> _entries;

    //    public void SaveToFile<T>(string directoryPath, string fileName)
    //    {
    //        if (!Directory.Exists(directoryPath))
    //        {
    //            Directory.CreateDirectory(directoryPath);
    //        }

    //        File.WriteAllText(Path.Combine(directoryPath, fileName), this.ToString());
    //    }


    //    public override string ToString() =>
    //        string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
    //}

    //////////////finished task

    //#region Principle start
    ////public abstract class Employee
    ////{
    ////    public virtual string GetProjectDetails(int employeeId)
    ////    {
    ////        return "Base Project";
    ////    }
    ////    public virtual string GetEmployeeDetails(int employeeId)
    ////    {
    ////        return "Base Employee";
    ////    }
    ////}
    ////public class CasualEmployee : Employee
    ////{
    ////    public override string GetProjectDetails(int employeeId)
    ////    {
    ////        return "Child Project";
    ////    }
    ////    // May be for contractual employee we do not need to store the details into database.
    ////    public override string GetEmployeeDetails(int employeeId)
    ////    {
    ////        return "Child Employee";
    ////    }
    ////}
    ////public class ContractualEmployee : Employee
    ////{
    ////    public override string GetProjectDetails(int employeeId)
    ////    {
    ////        return "Child Project";
    ////    }
    ////    // May be for contractual employee we do not need to store the details into database.
    ////    public override string GetEmployeeDetails(int employeeId)
    ////    {
    ////        throw new NotImplementedException();
    ////    }
    ////}
    //    #endregion

    //    public interface IEmployee
    //    {
    //        public virtual string GetEmployeeDetails(int employeeId)
    //        {
    //            return "Base Employee";
    //        }
    //    }

    //    public interface IProject
    //    {
    //        public virtual string GetProjectDetails(int employeeId)
    //        {
    //            return "Base Project";
    //        }
    //    }

    //    public class CasualEmployee : IEmployee, IProject
    //    {
    //        public override string GetProjectDetails(int employeeId)
    //        {
    //            return "Child Project";
    //        }

    //        public override string GetEmployeeDetails(int employeeId)
    //        {
    //            return "Child Employee";
    //        }
    //    }
    //    public class ContractualEmployee : IEmployee
    //    {
    //        public override string GetProjectDetails(int employeeId)
    //        {
    //            return "Child Project";
    //        }
    //    }

    //    public void Run()
    //    {
    //        Console.WriteLine("LSP Task run:");
    //        List<IEmployee> employeeList = new List<IEmployee>();
    //        employeeList.Add(new ContractualEmployee());
    //        employeeList.Add(new CasualEmployee());
    //        foreach (IEmployee e in employeeList)
    //        {
    //            e.GetProjectDetails(1245);
    //        }
    //    }
    //}


    /////////////////////////example dip
    //public enum Gender
    //{
    //    Male,
    //    Female
    //}
    //public enum Position
    //{
    //    Administrator,
    //    Manager,
    //    Executive
    //}
    //public class Employee
    //{
    //    public string Name { get; set; }
    //    public Gender Gender { get; set; }
    //    public Position Position { get; set; }
    //}
    /////////////////////интерфейс от которого наследуется IEmployeeSearchable(поиск сотрудникиов) 
    //public interface IEmployeeSearchable
    //{
    //    IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
    //}

    //public class EmployeeManager : IEmployeeSearchable
    //{
    //    private readonly List<Employee> _employees;

    //    public EmployeeManager()
    //    {
    //        _employees = new List<Employee>();
    //    }

    //    public void AddEmployee(Employee employee)
    //    {
    //        _employees.Add(employee);
    //    }

    //    public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
    //        => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
    //}

    /////////////////////////IEmployeeSearchable(поиск сотрудникиов)  не входит и по этому не неследуется
    //public class EmployeeStatistics
    //{
    //    private readonly IEmployeeSearchable _emp;

    //    public EmployeeStatistics(IEmployeeSearchable emp)
    //    {
    //        _emp = emp;
    //    }

    //    public int CountFemaleManagers() =>
    //    _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var empManager = new EmployeeManager();
    //        empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
    //        empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });

    //        var stats = new EmployeeStatistics(empManager);
    //        Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");
    //    }
    //}


    ////////////////example sri
    public interface IProduct
    {
        int ID { get; set; }
        double Weight { get; set; }
        int Stock { get; set; }
    }


    public interface IPants
    {
        int Inseam { get; set; }
        int WaistSize { get; set; }
    }


    public interface IHat
    {
        int HatSize { get; set; }
    }


    // реализует лишь то, что использует

    public class Jeans : IProduct, IPants
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int Inseam { get; set; }
        public int WaistSize { get; set; }
    }


    // также реализует лишь то, что использует
    public class BaseballCap : IProduct, IHat
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int HatSize { get; set; }
    }
}
