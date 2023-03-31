using Mapster;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SaveMom.Contracts.Configurations;
using SaveMom.Contracts.Dtos;
using SaveMom.Domain;
using SaveMom.Domain.Data;
using SaveMom.Domain.Identity;
using SaveMom.Domain.SeedData;

namespace SaveMom.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IMongoCollection<Organisation> _organisationCollection;
        private readonly IDbContext<Organisation> _dbContext;

        public OrganisationService(IOptions<DbStoreOptions> saveMomStoreDatabaseOptions, IDbContext<Organisation> dbContext)
        {
            _dbContext = dbContext;
            _organisationCollection = _dbContext.Collection;

        }

        public async Task<OrganisationDto> Create(OrganisationDto organisationDto)
        {
            var organisation = organisationDto.Adapt<Organisation>();
            await _organisationCollection.InsertOneAsync(organisation);
            return organisation.Adapt<OrganisationDto>();
        }

        public async Task<List<OrganisationDto>> Get()
        {
            var result = await _organisationCollection.Find(_ => true).ToListAsync();
            if(result.Any())
                return result.Adapt<List<OrganisationDto>>();
            var data = OrganisationSeeder.GetSeedData();
            await _organisationCollection.InsertManyAsync(data);
            var o = await _organisationCollection.Find(_ => true).ToListAsync();
            return o.Adapt<List<OrganisationDto>>();
        }

        public async Task<OrganisationDto> Get(string id)
        {
            var result = await _organisationCollection.Find(xx => xx.Id == id).FirstOrDefaultAsync();
            return result.Adapt<OrganisationDto>();
        }

        public async Task Remove(string id) =>
            await _organisationCollection.DeleteOneAsync(xx => xx.Id == id);

        public async Task Update(string id, OrganisationDto organisationDto) =>
            await _organisationCollection.ReplaceOneAsync(xx => xx.Id == id, organisationDto.Adapt<Organisation>());
    }
}
