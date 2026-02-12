using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsVoiceNoteAppService : IGenericAppService<DmsVoiceNote>
    {
        Task TranscribeVoiceAsync(Guid noteId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsVoiceNoteAppService : GenericAppService<DmsVoiceNote>, IDmsVoiceNoteAppService
    {
        public DmsVoiceNoteAppService(
            IRepository<DmsVoiceNote, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
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