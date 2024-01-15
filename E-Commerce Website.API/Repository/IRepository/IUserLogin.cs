namespace E_Commerce_Website.API.Repository.IRepository
{
    public interface IUserLogin : IRepository<UserLogin>
    {
        Task<UserLogin> FindUserByEmailAsync(string email);

    }
}
