namespace E_Commerce_Website.API.Repository.IRepository
{
    public interface IUserLogin:IRepository<UserLogin>
    {
        Task<string> FindByNameAsync(string username);
        Task<bool> CheckPasswordAsync(string user,string? password);
    }
}
