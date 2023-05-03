using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.OpenIddict.Applications;

using Bamboo.AdminExtensions.Dtos;
namespace Bamboo.AdminExtensions;

public class ClientAppService : ApplicationService, ITransientDependency
{
    private readonly IRepository<OpenIddictApplication, Guid> _openIddictApplicationRepository;
    public ClientAppService(IRepository<OpenIddictApplication, Guid> _openIddictApplicationRepository)
    {
        this._openIddictApplicationRepository = _openIddictApplicationRepository;
    }

    public async Task<List<ClientAppDto>> GetListAsync()
    {
        var clients = await _openIddictApplicationRepository.GetListAsync();
        return clients.Select(x => new ClientAppDto
        {
            ClientId = x.ClientId,
            DisplayName = x.DisplayName,
            PostLogoutRedirectUris = x.PostLogoutRedirectUris,
            RedirectUris = x.RedirectUris,
            Permissions = x.Permissions,
            Type = x.Type
        }).ToList();
    }

    public async Task<ClientAppDto> GetAsync(Guid id)
    {
        var client = await _openIddictApplicationRepository.GetAsync(id);
        return new ClientAppDto
        {
            ClientId = client.ClientId,
            DisplayName = client.DisplayName,
            PostLogoutRedirectUris = client.PostLogoutRedirectUris,
            RedirectUris = client.RedirectUris,
            Permissions = client.Permissions,
            Type = client.Type
        };
    }

    public async Task<ClientAppDto> CreateAsync(ClientAppDto input)
    {
        var client = new OpenIddictApplication(GuidGenerator.Create());
        client.ClientId = input.ClientId;
        client.DisplayName = input.DisplayName;
        client.PostLogoutRedirectUris = input.PostLogoutRedirectUris;
        client.RedirectUris = input.RedirectUris;
        client.Permissions = input.Permissions;
        client.Type = input.Type;
        await _openIddictApplicationRepository.InsertAsync(client);
        return new ClientAppDto
        {
            ClientId = client.ClientId,
            DisplayName = client.DisplayName,
            PostLogoutRedirectUris = client.PostLogoutRedirectUris,
            RedirectUris = client.RedirectUris,
            Permissions = client.Permissions,
            Type = client.Type
        };
    }

    public async Task<ClientAppDto> UpdateAsync(Guid id, ClientAppDto input)
    {
        var client = await _openIddictApplicationRepository.GetAsync(id);
        client.ClientId = input.ClientId;
        client.DisplayName = input.DisplayName;
        client.PostLogoutRedirectUris = input.PostLogoutRedirectUris;
        client.RedirectUris = input.RedirectUris;
        client.Permissions = input.Permissions;
        client.Type = input.Type;
        await _openIddictApplicationRepository.UpdateAsync(client);
        return new ClientAppDto
        {
            ClientId = client.ClientId,
            DisplayName = client.DisplayName,
            PostLogoutRedirectUris = client.PostLogoutRedirectUris,
            RedirectUris = client.RedirectUris,
            Permissions = client.Permissions,
            Type = client.Type
        };
    }

    public async Task<ClientAppDto> AddRedirectUriAsync(Guid id, string redirectUri)
    {
        var client = await _openIddictApplicationRepository.GetAsync(id);
        var redirectUris = JsonSerializer.Deserialize<List<string>>(client.RedirectUris);
        redirectUris.Add(redirectUri);
        client.RedirectUris = JsonSerializer.Serialize(redirectUris);
        await _openIddictApplicationRepository.UpdateAsync(client);
        return new ClientAppDto
        {
            ClientId = client.ClientId,
            DisplayName = client.DisplayName,
            PostLogoutRedirectUris = client.PostLogoutRedirectUris,
            RedirectUris = client.RedirectUris,
            Permissions = client.Permissions,
            Type = client.Type
        };
    }

    public async Task<ClientAppDto> AddPostLogoutRedirectUriAsync(Guid id, string redirectUri)
    {
        var client = await _openIddictApplicationRepository.GetAsync(id);
        var redirectUris = JsonSerializer.Deserialize<List<string>>(client.PostLogoutRedirectUris);
        redirectUris.Add(redirectUri);
        client.PostLogoutRedirectUris = JsonSerializer.Serialize(redirectUris);
        await _openIddictApplicationRepository.UpdateAsync(client);
        return new ClientAppDto
        {
            ClientId = client.ClientId,
            DisplayName = client.DisplayName,
            PostLogoutRedirectUris = client.PostLogoutRedirectUris,
            RedirectUris = client.RedirectUris,
            Permissions = client.Permissions,
            Type = client.Type
        };
    }

    public async Task<ClientAppDto> UpdateClientTypeAsync(Guid id, string clientType)
    {
        var client = await _openIddictApplicationRepository.GetAsync(id);
        client.Type = clientType;
        await _openIddictApplicationRepository.UpdateAsync(client);
        return new ClientAppDto
        {
            ClientId = client.ClientId,
            DisplayName = client.DisplayName,
            PostLogoutRedirectUris = client.PostLogoutRedirectUris,
            RedirectUris = client.RedirectUris,
            Permissions = client.Permissions,
            Type = client.Type
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await _openIddictApplicationRepository.GetAsync(id);
        await _openIddictApplicationRepository.DeleteAsync(client);        
    }
}