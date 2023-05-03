using Volo.Abp.Application.Dtos;
namespace Bamboo.AdminExtensions.Dtos;
public class ClientAppDto : EntityDto
{
    public string ClientId { get; set; }
    public string DisplayName { get; set; }
    public string PostLogoutRedirectUris { get; set; }
    public string RedirectUris { get; set; }
    public string Permissions { get; set; }
    public string Type { get; set; }
}