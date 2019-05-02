using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PyaFramework.Core
{
    public interface IClonable
    {
    }
    public interface IThing : IClonable
    {
        Guid Id { get; set; }
    }
    public interface IUser : IThing
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        string Role { get; set; } //Task: Make Role a type it needs to be linked to Access Level somehow. Can we?
        byte[] Salt { get; set; }
        string Hash { get; set; }
    }
    public interface IDataProvider
    {
        List<T> GetList<T>() where T : class, IThing;
        List<T> GetList<T>(Func<T, bool> func) where T : class, IThing;
        T Get<T>(Func<T, bool> func) where T : class, IThing;
        T Get<T>(Guid id) where T : class, IThing;
        List<T> GetListIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class, IThing;
        List<T> GetListIncluding<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class, IThing;
        //Lesson: Why don't we say: TransactionResult Add(Thing obj)?
        // Because then in order to use it with any derived class off Thing,
        // we'd have to cast the subclass to Thing or use "as List<Thing>"
        TransactionResult Add<T>(T obj) where T : class, IThing;
        TransactionResult Update<T>(T obj) where T : class, IThing;
        TransactionResult Delete<T>(Guid id) where T : class, IThing;
    }
    public interface IUserService
    {
        Task<bool> GetPrincipal(string userName, string passWord, out ClaimsPrincipal claimsPrincipal);
        Task<bool> ValidateCredentials(string userName, string passWord, out IUser user);
        TransactionResult Save(IUser user); //Task: Add delete too
        TransactionResult SetPassword(Guid id, string password);
    }
}
