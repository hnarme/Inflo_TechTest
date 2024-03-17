using System.Linq;
using Serilog;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;


public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [Route("users")]
    public ViewResult List()
    {
        var items = _userService.GetAll().Select(u => new UserListItemViewModel
        {
            Id = u.Id,
            Forename = u.Forename,
            Surname = u.Surname,
            DateOfBirth = u.DateOfBirth,
            Email = u.Email,
            IsActive = u.IsActive,
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        Log.Information("User is on  the user list page");

        return View(model);
    }

    public ActionResult ActiveTrue(bool isActive)
    {
        var uItems = _userService.GetAll().Select(u => new UserListItemViewModel
        {
            Id = u.Id,
            Forename = u.Forename,
            Surname = u.Surname,
            Email = u.Email,
            IsActive = u.IsActive,
        });

        IEnumerable<bool> isactiveQuery = from u in _userService.GetAll()
                                         select u.IsActive;

        return RedirectToAction("List");
    }

    public ViewResult Details(int id)
    {
        var uDetails = _userService.GetAll().FirstOrDefault(u => u.Id == id);

        Log.Information("User is on the details page for => {@uDetails}", uDetails);

        return View(uDetails);
    }

    [HttpGet]
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return View("Error");
        }

        var uEdit = _userService.GetAll().FirstOrDefault(u => u.Id == id);
        if (uEdit == null)
        {
            return View("Error");
        }

        Log.Information("User is on the details page for => {@uEdit}", uEdit);

        return View(uEdit);
    }

    [HttpPost]
    public ActionResult Edit(int id, [Bind("Id,Forename,Surname,Email,IsActive")] User user)
    {
        if (id != user.Id)
        {
            return View("Error");
        }

        if (ModelState.IsValid)
        {
            _userService.Update(user);

            return RedirectToAction("List");
        }

        Log.Information("User has edited the details for => {@user}", user);

        return View(user);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return View("Error");
        }

        var udelete = _userService.GetAll().FirstOrDefault(u => u.Id == id);
        if (udelete == null)
        {
            return View("Error");
        }

        Log.Information("User is on the delete page for => {@udelete}", udelete);

        return View(udelete);
    }

    [HttpPost]
    public ActionResult Delete(User user)
    {
        _userService.Delete(user);

        Log.Information("User has deleted the details for => {@user}", user);

        return RedirectToAction("List");
    }


    public ActionResult Create()
    {
        Log.Information("User is on the page to create new users");

        return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        _userService.Create(user);

        Log.Information(" A new user has been created for => {@user}", user);

        return RedirectToAction("List");
    }

}
