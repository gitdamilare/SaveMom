using Mapster;
using SaveMom.Contracts.Dtos.Antenatal;
using SaveMom.Domain.Antenatal;
using System.Reflection;

namespace SaveMom.API.Extentions
{
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            TypeAdapterConfig<PatientRequestDto, Patient>
                .NewConfig()
                .Map(dest => dest.Spouse, src => src.SpouseInfo)
                .TwoWays();

            TypeAdapterConfig<Patient, PatientResponseDto>
                .NewConfig()
                .Map(dest => dest.SpouseInfo, src => src.Spouse)
                .TwoWays();
        }
    }
}
