namespace UTFPR.PoliciaMovel.Application.Interfaces.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        Task Save(T entity);
    }
}
