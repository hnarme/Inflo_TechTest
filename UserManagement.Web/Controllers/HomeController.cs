using Microsoft.Extensions.Logging;
using System.Text;

namespace UserManagement.WebMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<UsersController> _logger;

    [HttpGet]
    public ViewResult Index() => View();

    public HomeController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    public IActionResult Logger()
    {
        string filePath = "../UserManagement.Web/logs/UserManagementlog.txt";
        var data = System.IO.File.ReadAllText(filePath, Encoding.UTF8);

        string newFilePath = "../UserManagement.Web/logs/Logcopy.txt";
        var newData = System.IO.File.ReadAllText(newFilePath, Encoding.UTF8);

        if (System.IO.File.Exists(filePath))
        {
            string fileContents = data;
            ViewBag.FileContents = fileContents;
        }
        else
        {
            ViewBag.FileContents = "File not found.";
        }

        if (System.IO.File.Exists(filePath))
        {
            string newFileContents = @newData;
            System.IO.File.WriteAllText(newFilePath, newData);
            ViewBag.FileContents = newFileContents;
        }

        return View();
    }

}
