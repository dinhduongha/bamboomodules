using Bamboo.Admin;
using Bamboo.Admin.Application.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
//using Volo.Abp.ObjectMapper;

[Mapper]
[MapExtraProperties]
public partial class TenantMemberMapper : MapperBase<TenantMember, TenantMemberDto>
{
    // 1. Map TenantMember -> TenantMemberDto
    [MapperIgnoreTarget(nameof(TenantMemberDto.Roles))] // Bỏ qua Roles vì kiểu dữ liệu khác nhau (List<string> vs ICollection)
    //public partial TenantMemberDto Map(TenantMember source);

    public override TenantMemberDto Map(TenantMember source)
    {
        throw new System.NotImplementedException();
    }

    public override void Map(TenantMember source, TenantMemberDto destination)
    {
        throw new System.NotImplementedException();
    }

    //[MapperIgnoreTarget(nameof(TenantMemberDto.Roles))]
    //public partial TenantMemberDto Map(TenantMember source, [MappingTarget] TenantMemberDto destination);

    // 2. Map CreateTenantMemberDto -> TenantMember
    // [MapperIgnoreTarget(nameof(TenantMember.Id))]
    // [MapperIgnoreTarget(nameof(TenantMember.TenantId))]
    // [MapperIgnoreTarget(nameof(TenantMember.Roles))]
    // [MapperIgnoreTarget(nameof(TenantMember.OrganizationUnits))]
    // public partial TenantMember Map(CreateTenantMemberDto source);
    // public partial TenantMember Map(CreateTenantMemberDto source, [MappingTarget] TenantMember destination);

    // // 3. Map UpdateTenantMemberDto -> TenantMember
    // [MapperIgnoreTarget(nameof(TenantMember.Id))]
    // [MapperIgnoreTarget(nameof(TenantMember.TenantId))]
    // [MapperIgnoreTarget(nameof(TenantMember.UserId))]
    // [MapperIgnoreTarget(nameof(TenantMember.Roles))]
    // [MapperIgnoreTarget(nameof(TenantMember.OrganizationUnits))]
    // public partial TenantMember Map(UpdateTenantMemberDto source);
    // public partial TenantMember Map(UpdateTenantMemberDto source, [MappingTarget] TenantMember destination);
}