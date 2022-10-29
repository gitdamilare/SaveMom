using SaveMom.Contracts.Dtos;
using SaveMom.Domain;

namespace SaveMom.Services
{
    public interface IOrganisationService
    {
        Task<List<OrganisationDto>> Get();
        Task<OrganisationDto> Get(string id);
        Task<OrganisationDto> Create(OrganisationDto organisation);
        Task Update(string id, OrganisationDto organisation);
        Task Remove(string id);
    }
}
