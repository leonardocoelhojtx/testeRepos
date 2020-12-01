using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IPartnerUserRepository : IRepository<PartnerUserEntity>
    {
        Task UpdatePartnerUserSituationAsync(Int64 idPartner, Int64 idUser, string situation);
    }
}
