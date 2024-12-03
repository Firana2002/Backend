using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
  

public class VacationPlanningContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveDays> LeaveDays { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<Restriction> Restrictions { get; set; }
    public DbSet<DepartmentRestriction> DepartmentRestrictions { get; set; }
    public DbSet<ScheduledLeave> ScheduledLeaves { get; set; }

    public VacationPlanningContext(DbContextOptions<VacationPlanningContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Добавление тестовой записи в Organization
    modelBuilder.Entity<Organization>().HasData(new Organization
    {
        Id = 1,
        OrganizationName = "Эн+ Диджитал"
    });

    // Добавление тестовой записи в Department
    modelBuilder.Entity<Department>().HasData(new Department
    {
        Id = 1,
        DepartmentName = "IT",
        OrganizationId = 1
    });

    // Добавление тестовой записи в Employee
    modelBuilder.Entity<Employee>().HasData(new Employee
    {
        Id = 1,
        EmployeeName = "Иванов Иван Иванович",
        DepartmentId = 1
    });

    // Добавление тестовой записи в Position
    modelBuilder.Entity<Position>().HasData(new Position
    {
        Id = 1,
        PositionTitle = "Разработчик"
    });

    // Добавление тестовых записей в LeaveType
    modelBuilder.Entity<LeaveType>().HasData(new LeaveType[]
    {
        new LeaveType { Id = 1, LeaveTypeName = "Ежегодный основной" },
        new LeaveType { Id = 2, LeaveTypeName = "Ежегодный дополнительный" },
        new LeaveType { Id = 3, LeaveTypeName = "Учебный" },
        new LeaveType { Id = 4, LeaveTypeName = "Без сохранения зарплаты" }
    });

    // Добавление тестовой записи в LeaveDays
    modelBuilder.Entity<LeaveDays>().HasData(new LeaveDays
    {
        Id = 1,
        EmployeeId = 1,
        LeaveTypeId = 1,
        TotalDays = 14
    });

    // Добавление тестовой записи в Holiday
    modelBuilder.Entity<Holiday>().HasData(new Holiday
    {
        Id = 1,
        HolidayDate = new DateTime(2023, 1, 1),
        HolidayDescription = "Новый год"
    });

    // Добавление тестовой записи в Restriction
    modelBuilder.Entity<Restriction>().HasData(new Restriction
    {
        Id = 1,
        RestrictionType = "Законодательное"
    });

    // Добавление тестовой записи в DepartmentRestriction
    modelBuilder.Entity<DepartmentRestriction>().HasData(new DepartmentRestriction
    {
        Id = 1,
        RestrictionId = 1,
        DepartmentId = 1
    });

    // Добавление тестовой записи в ScheduledLeave
    modelBuilder.Entity<ScheduledLeave>().HasData(new ScheduledLeave
    {
        Id = 1,
        EmployeeId = 1,
        StartDate = new DateTime(2023, 6, 1),
        EndDate = new DateTime(2023, 6, 15)
    });
}

}
