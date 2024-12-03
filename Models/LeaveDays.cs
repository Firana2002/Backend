public class LeaveDays
{
    public int Id { get; set; }
    public int EmployeeId { get; set; } // Внешний ключ на сотрудника
    public int LeaveTypeId { get; set; } // Внешний ключ на вид отпуска
    public int TotalDays { get; set; } // Общее количество дней отпуска
    public Employee Employee { get; set; } // Навигационное свойство
    public LeaveType LeaveType { get; set; } // Навигационное свойство
}
