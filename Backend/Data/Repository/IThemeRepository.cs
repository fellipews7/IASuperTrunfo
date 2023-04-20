using Domain.Model;

namespace Data.Repository
{
    public interface IThemeRepository : IRepository<Theme>
    {
        IQueryable<Theme> GetCards();
        IQueryable<Theme> GetAttributes();
    }
}
