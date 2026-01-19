using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsVoiceNoteAppService : IGenericApplicationService<DmsVoiceNote>
    {
        Task TranscribeVoiceAsync(Guid noteId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsVoiceNoteAppService : GenericApplicationService<DmsVoiceNote>, IDmsVoiceNoteAppService
    {
        public DmsVoiceNoteAppService(
            IRepository<DmsVoiceNote, Guid> repository,
            IServiceProvider serviceProvider,
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IMemoryCache memoryCache)
            : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
        }

        public async Task TranscribeVoiceAsync(Guid noteId)
        {
            var note = await Repository.GetAsync(noteId);
            // Logic gọi AI service để transcribe (placeholder)
            note.TranscribedText = "Transcribed text from voice";
            await Repository.UpdateAsync(note);
        }
    }
}