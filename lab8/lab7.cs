// Гуменюк Макс КІ2-21-4
using System;
using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Required(ErrorMessage = "Поле 'Ім'я' є обов'язковим")]
    [StringLength(50, ErrorMessage = "Ім'я повинно бути не більше 50 символів")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Поле 'Прізвище' є обов'язковим")]
    [StringLength(50, ErrorMessage = "Прізвище повинно бути не більше 50 символів")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Поле 'Email' є обов'язковим")]
    [EmailAddress(ErrorMessage = "Недійсний формат Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Поле 'Дата народження' є обов'язковим")]
    [DataType(DataType.Date, ErrorMessage = "Недійсний формат дати")]
    public DateTime BirthDate { get; set; }
}

// UserController.cs
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(UserModel model)
    {
        if (ModelState.IsValid)
        {
            // Дії для збереження моделі в базу даних або інше використання
            return RedirectToAction("Success");
        }

        return View(model);
    }

    public IActionResult Success()
    {
        return View();
    }
}