using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IHrIndividualSkillMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionSaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> CanEditCertificationValidityPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> CheckDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> CheckNotOverlappingRegularSkillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> CheckSkillLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> CheckSkillTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> ComputeCertificationSkillTypeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> ComputeSkillIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> ComputeSkillLevelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> CreateIndividualSkillsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> DefaultSkillTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> ExpireIndividualSkillsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> GetCurrentSkillsByApplicantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> GetCurrentSkillsByEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> GetOverlappingIndividualSkillInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> GetPassiveFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> GetTransformedCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object commands, object individuals) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> LinkedFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> OnchangeIsCertificationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> OnchangeValidDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> OpenHrEmployeeSkillModalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
        Task<TEntity> WriteIndividualSkillsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object commands) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable;
    }
}