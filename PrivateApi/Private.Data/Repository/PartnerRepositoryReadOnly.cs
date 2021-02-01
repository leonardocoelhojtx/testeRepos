using System.Linq;
using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;

namespace Private.Data.Repository
{
    public class PartnerRepositoryReadOnly : BaseRepositoryReadOnly<PartnerViewEntity>, IPartnerRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;
        public PartnerRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PartnerViewEntity> SelectPartners()
        {
            try
            {
                return _context.Partners;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
