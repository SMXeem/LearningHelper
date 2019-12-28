using System.Collections.Generic;
using LearningHelper.Models;

namespace LearningHelper.Interfaces.Managers
{
    public interface IUserManager : ICommonManager<User>
    {
        User GetById(long brandId);
        //ICollection<User> Get();
    }
}
