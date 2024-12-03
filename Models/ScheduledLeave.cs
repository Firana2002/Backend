public class ScheduledLeave
{
    public int Id { get; set; }
    public int EmployeeId { get; set; } // Внешний ключ на сотрудника
    public DateTime StartDate { get; set; } // Дата начала отпуска
    public DateTime EndDate { get; set; } // Дата окончания отпуска
    public Employee Employee { get; set; } // Навигационное свойство
}
