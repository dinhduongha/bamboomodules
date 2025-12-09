using AutoMapper;
using Bamboo.Admin.Application.Dtos;

namespace Bamboo.Admin;

public class AdminApplicationAutoMapperProfile : Profile
{
    public AdminApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<TenantMember, TenantMemberDto>();
        CreateMap<CreateTenantMemberDto, TenantMember>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TenantId, o => o.Ignore()); // TenantId sẽ được gán trong AppService;
        CreateMap<UpdateTenantMemberDto, TenantMember>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TenantId, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Condition(src => src.Status.HasValue))
            .ForMember(dest => dest.IsOwner, opt => opt.Condition(src => src.IsOwner.HasValue));
    }
}
