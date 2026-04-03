using Bamboo.Admin.Application.Dtos;
using Riok.Mapperly.Abstractions;
//using Volo.Abp.Mapperly;

namespace Bamboo.Admin.Application.Mappers;

[Mapper]
public static partial class AdminApplicationMappers
{
    /* You can configure your Mapperly mapping configuration here.
     * Alternatively, you can split your mapping configurations
     * into multiple mapper classes for a better organization. */

    public static partial TenantMemberDto ToDto(this TenantMember source);

}


/* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
/*
        CreateMap<TenantMember, TenantMemberDto>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore());
        CreateMap<CreateTenantMemberDto, TenantMember>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TenantId, o => o.Ignore()); // TenantId sẽ được gán trong AppService;
        CreateMap<UpdateTenantMemberDto, TenantMember>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TenantId, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Condition(src => src.Status.HasValue))
            .ForMember(dest => dest.IsOwner, opt => opt.Condition(src => src.IsOwner.HasValue));
*/

// [Mapper]
// public static partial class FeedbackMapper
// {
//     [MapProperty(nameof(FeedbackReport.CreationTime), nameof(FeedbackDto.CreatedAt))]
//     public static partial FeedbackDto ToDto(this FeedbackReport source);
// }