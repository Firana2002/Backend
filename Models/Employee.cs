public class Employee
{
    public int Id { get; set; }
    public string EmployeeName { get; set; } // ФИО сотрудника
    public int DepartmentId { get; set; } // Внешний ключ на подразделение
    public Department Department { get; set; } // Навигационное свойство
}
