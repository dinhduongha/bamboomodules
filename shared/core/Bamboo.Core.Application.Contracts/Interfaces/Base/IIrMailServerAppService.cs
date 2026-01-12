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
    public interface IIrMailServerAppService : IGenericApplicationService<IrMailServer>
    {
        Task<IrMailServer> BuildEmailAsync(Guid id, IrMailServerBuildEmailRequestDto input);
        Task<IrMailServer> ConnectAsync(Guid id, IrMailServerConnectRequestDto input);
        Task<IrMailServer> RetrieveMaxEmailSizeAsync(Guid id);
        Task<IrMailServer> SendEmailAsync(Guid id, IrMailServerSendEmailRequestDto input);
        Task<IrMailServer> TestSmtpConnectionAsync(Guid id, IrMailServerTestSmtpConnectionRequestDto input);
    }
}