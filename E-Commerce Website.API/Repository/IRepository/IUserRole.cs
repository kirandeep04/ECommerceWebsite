namespace E_Commerce_Website.API.Repository.IRepository
{
    public interface IUserRole : IRepository<UserRole>
    {
        Task <IEnumerable<UserRole>>GetRolesAsync(string user);
    }
}
