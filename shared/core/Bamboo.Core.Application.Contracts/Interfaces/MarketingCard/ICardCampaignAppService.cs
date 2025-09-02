using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICardCampaignAppService : IGenericApplicationService<CardCampaign>
    {
        Task<CardCampaign> PreviewAsync(Guid id);
        Task<CardCampaign> ShareAsync(Guid id);
        Task<CardCampaign> ViewCardsAsync(Guid id);
        Task<CardCampaign> ViewCardsClickedAsync(Guid id);
        Task<CardCampaign> ViewCardsSharedAsync(Guid id);
        Task<CardCampaign> ViewMailingsAsync(Guid id);
    }
}