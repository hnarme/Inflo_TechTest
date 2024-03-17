using System.Collections.Generic;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> FilterByActive(bool isActive) => _dataAccess.FilterByActive<User>(isActive);
    //{
    //    var uFilter = _dataAccess.FilterByActive(isActive);
    //    return uFilter;

    //}

    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public User Update(User user)
    {
        var uUpdate = _dataAccess.Update(user);
        return uUpdate;
    }

    public User Delete(User user)
    {
        var uDelete = _dataAccess.Delete(user);
        return uDelete;
    }

    public User Create(User user)
    {
        var uCreate = _dataAccess.Create(user);
        return uCreate;
    }
}
