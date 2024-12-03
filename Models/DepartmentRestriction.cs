public class DepartmentRestriction
{
    public int Id { get; set; }
    public int RestrictionId { get; set; } // Внешний ключ на ограничения
    public int DepartmentId { get; set; } // Внешний ключ на подразделение
    public Restriction Restriction { get; set; } // Навигационное свойство
    public Department Department { get; set; } // Навигационное свойство
}
