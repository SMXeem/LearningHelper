using LearningHelper.Interfaces.Repositories;
using LearningHelper.Models;
using LearningHelper.Utility;

namespace LearningHelper.Repository
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository() : base(new LearningContext())
        {
        }
    }
}