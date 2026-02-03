using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICardCampaignAppService : IGenericApplicationService<CardCampaign>
    {
        Task<CardCampaign> PreviewAsync(Guid[] ids);
        Task<CardCampaign> ShareAsync(Guid[] ids);
        Task<CardCampaign> ViewCardsAsync(Guid[] ids);
        Task<CardCampaign> ViewCardsClickedAsync(Guid[] ids);
        Task<CardCampaign> ViewCardsSharedAsync(Guid[] ids);
        Task<CardCampaign> ViewMailingsAsync(Guid[] ids);
    }
}