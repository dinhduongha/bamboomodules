using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict.Scopes;

using Bamboo.AdminExtensions.Dtos;

namespace Bamboo.AdminExtensions;

[Route("api/admin/scope-management")]
[Produces("application/json")]
[Authorize]
public class ScopeController : AbpController
{
    private readonly IRepository<OpenIddictScope, Guid> _openIddictScopeRepository;
    public ScopeController(IRepository<OpenIddictScope, Guid> _openIddictScopeRepository)
    {
        this._openIddictScopeRepository = _openIddictScopeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ScopeDto>>> GetListAsync()
    {
        var scopes = await _openIddictScopeRepository.GetListAsync();
        return Ok(scopes.Select(x => new ScopeDto
        {
            Id = x.Id,
            Name = x.Name,
            DisplayName = x.DisplayName,
            Description = x.Description,
            Resources = x.Resources,
            Properties = x.Properties
        }).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ScopeDto>> GetAsync(Guid id)
    {
        var scope = await _openIddictScopeRepository.GetAsync(id);
        return Ok(new ScopeDto
        {
            Id = scope.Id,
            Name = scope.Name,
            DisplayName = scope.DisplayName,
            Description = scope.Description,
            Resources = scope.Resources,
            Properties = scope.Properties
        });
    }

    [HttpPost]
    public async Task<ActionResult<ScopeDto>> CreateAsync([FromBody] ScopeDto input)
    {
        var scope = new OpenIddictScope(GuidGenerator.Create());
        scope.Name = input.Name;
        scope.DisplayName = input.DisplayName;
        scope.Description = input.Description;
        scope.Resources = input.Resources;
        scope.Properties = input.Properties;
        await _openIddictScopeRepository.InsertAsync(scope);
        return Ok(new ScopeDto
        {
            Id = scope.Id,
            Name = scope.Name,
            DisplayName = scope.DisplayName,
            Description = scope.Description,
            Resources = scope.Resources,
            Properties = scope.Properties
        });
    }

    [HttpPut("{clientId}")]
    public async Task<ActionResult<ScopeDto>> UpdateAsync(Guid clientId, [FromBody] ScopeDto input)
    {
        var scope = await _openIddictScopeRepository.GetAsync(clientId);
        scope.Name = input.Name;
        scope.DisplayName = input.DisplayName;
        scope.Description = input.Description;
        scope.Resources = input.Resources;
        scope.Properties = input.Properties;
        await _openIddictScopeRepository.UpdateAsync(scope);
        return Ok(new ScopeDto
        {
            Id = scope.Id,
            Name = scope.Name,
            DisplayName = scope.DisplayName,
            Description = scope.Description,
            Resources = scope.Resources,
            Properties = scope.Properties
        });
    }
}