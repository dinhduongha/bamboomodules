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
    public interface IIrMailServerAppService : IGenericAppService<IrMailServer>
    {
        Task<IrMailServer> RetrieveMaxEmailSizeAsync(Guid[] ids);
        Task<IrMailServer> SendEmailAsync(IrMailServerSendEmailRequestDto input);
        Task<IrMailServer> TestSmtpConnectionAsync(IrMailServerTestSmtpConnectionRequestDto input);
    }
}