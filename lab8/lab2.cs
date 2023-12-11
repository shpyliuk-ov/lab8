// Гуменюк Макс КІ2-21-4
using Microsoft.AspNetCore.Mvc;

public interface IMyService
{
    string GetHelloMessage();
}

public class MyService : IMyService
{
    public string GetHelloMessage()
    {
        return "Hello from MyService!";
    }
}

public static void ConfigureServices(IServiceCollection services)
{
    // Додаємо сервіс до контейнера DI
    services.AddScoped<IMyService, MyService>();

    // Додайте інші конфігурації служб тут
}

public class MyController : Controller
{
    private readonly IMyService _myService;

    // DI вставить IMyService в конструктор контролера
    public MyController(IMyService myService)
    {
        _myService = myService;
    }

    public IActionResult Index()
    {
        var message = _myService.GetHelloMessage();
        return View(model: message);
    }
}