using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc;
using Bamboo.AdminExtensions.Dtos;
using Volo.Abp;

namespace Bamboo.AdminExtensions;

[Produces("application/json")]
[Route("api/admin/client-app")]
[Authorize(Roles="admin")]
public class HostClientAppController : AbpController
{
    private readonly ClientAppService _clientAppService;
    public HostClientAppController(ClientAppService clientAppService)
    {
        this._clientAppService = clientAppService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientAppDto>>> GetListAsync()
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var clients = await _clientAppService.GetListAsync();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientAppDto>> GetAsync(Guid id)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var client = await _clientAppService.GetAsync(id);
        return Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult<ClientAppDto>> CreateAsync([FromBody] ClientAppDto input)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var client = await _clientAppService.CreateAsync(input);
        return Ok(client);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ClientAppDto>> UpdateAsync(Guid id, [FromBody] ClientAppDto input)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var client = await _clientAppService.UpdateAsync(id, input);
        return Ok(client);
    }

    [HttpPost("add-redirect-uri/{id}")]
    public async Task<ActionResult<ClientAppDto>> AddRedirectUriAsync(Guid id, string redirectUri)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var client = await _clientAppService.AddRedirectUriAsync(id, redirectUri);
        return Ok(client);
    }

    [HttpPost("add-post-logout-redirect-uri/{id}")]
    public async Task<ActionResult<ClientAppDto>> AddPostLogoutRedirectUriAsync(Guid id, string redirectUri)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var client = await _clientAppService.AddPostLogoutRedirectUriAsync(id, redirectUri);
        return Ok(client);
    }

    [HttpPost("update-client-type/{id}")]
    public async Task<ActionResult<ClientAppDto>> UpdateClientTypeAsync(Guid id, string clientType)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        var client = await _clientAppService.UpdateClientTypeAsync(id, clientType);
        return Ok(client);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host users can access features");
        }
        await _clientAppService.DeleteAsync(id);
        return Ok();
    }
}