// Гуменюк Макс КІ2-21-4
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string Email { get; set; }
}
// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}

public class Startup
{
    // ... інші методи ...

    public void ConfigureServices(IServiceCollection services)
    {
        // Додати конфігурацію бази даних
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // ... інші сервіси ...
    }
}
public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var students = _context.Students.ToList();
        return View(students);
    }
}