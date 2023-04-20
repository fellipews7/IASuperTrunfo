using Data.Context;
using Attribute = Domain.Model.Attribute;

namespace Data.Repository
{
    public class AttributeRepository : Repository<Attribute>, IAttributeRepository
    {
        public AttributeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
