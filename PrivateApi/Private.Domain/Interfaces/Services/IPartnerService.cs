using Private.Domain.DTOs.Partner;
using Private.Domain.DTOs.PartnerPlan;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IPartnerService
    {
        Task<PartnerDto> Get(Int64 id);
        Task<IEnumerable<PartnerResumeDto>> Get(Int64? id, string reasonName, string fantasy, Int64? cpfCnpj, string status, string filter, string filterType);
        Task<IEnumerable<PartnerUserDto>> GetPartnerUsers(Int64 id);
        Task PutPersonAndPartner(PartnerDtoUpdate partner);
        Task<PersonAddressEntity> PutPartnerAddress(Int64 idPersonAddress, Int64 idPartner, Int64 idUser, PersonAddressDtoUpdate personAddress);
        Task PutPartnerUserSituation(Int64 idPartner, Int64 idUser, string situation);
        Task PostPartnerUser(Int64 idPartner, Int64 idUser, Int64 idUserLogged);
        Task<PartnerPersonEntity> PutStatusPartnerPerson(Int64 idPartner, Int64 idUserLogged, string status);
        Task<PartnerDto> PostPartner(Int64 idUserLogged, PartnerDtoInsert partner);
        Task<IEnumerable<PartnerPlanDto>> GetPartnerPlan(Int64 idPartner);
        Task<PartnerPlanDto> PostPartnerBillingPlan(PartnerBillingPlanDtoInsert partnerBillingPlanDtoInsert, Int64 idUserLogged);
        Task PutStatusPartnerBillingPlan(Int64 idPartnerBillingPlan, Int64 idUserLogged, string status);
    }
}
