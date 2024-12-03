public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; } // Название подразделения
    public int OrganizationId { get; set; } // Внешний ключ на организацию
    public Organization Organization { get; set; } // Навигационное свойство
}
