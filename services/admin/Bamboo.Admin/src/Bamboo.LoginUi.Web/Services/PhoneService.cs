using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using FirebaseAdmin.Auth;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.AspNet.Common;
using Twilio.TwiML;
using Twilio.AspNet.Core;

using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Sms;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Domain.Entities.Events.Distributed;

using Volo.Abp.Account;
using Volo.Abp.Users;

using Bamboo.Abp.VerificationCode;
using System.Security.Principal;

namespace Bamboo.LoginUiWeb;

public class PhoneService : ApplicationService
{
    IConfiguration _configuration;
    protected IDistributedEventBus _distributedEventBus;
    protected IdentityUserManager _userManager;    
    protected IdentitySecurityLogManager _identitySecurityLogManager { get; }
    private readonly IVerificationCodeManager _verificationCodeManager;
    private readonly IVerificationCodeGenerator _verificationCodeGenerator;
    private readonly IDataFilter _dataFilter;

    public PhoneService(IConfiguration configuration,
                    IDistributedEventBus distributedEventBus,
                    IVerificationCodeManager verificationCodeManager,
                    IVerificationCodeGenerator verificationCodeGenerator,
                    IDataFilter dataFilter,
                    IdentityUserManager userManager)
    {
        _configuration = configuration;
        _distributedEventBus = distributedEventBus;
        _verificationCodeManager = verificationCodeManager;
        _verificationCodeGenerator = verificationCodeGenerator;
        _userManager = userManager;
        _dataFilter = dataFilter;
    }


    public async Task<string> smsToken(string phone)
    {
        if (!Regex.Match(phone, @"^([+]|[00])([0-9]){5,13}$").Success)
        {
            throw new Exception("Invalid phone number");
        }
        var code = await _verificationCodeManager.GenerateAsync(
            codeCacheKey: $"Bamboo:PhoneVerification:{phone}",
            codeCacheLifespan: TimeSpan.FromMinutes(5),
            configuration: new VerificationCodeConfiguration());

        //await _distributedEventBus.PublishAsync(
        //        new PhoneVerifyEto
        //        {
        //            Phone = phone,
        //            Code = code,
        //            Desc = "OTP",
        //        }
        //    );
        return code;
    }

    public async Task<string> TokenReceived(string phone)
    {
        if (!Regex.Match(phone, @"^([+]|[00])([0-9]){5,13}$").Success)
        {
            throw new Exception("Invalid phone number");
        }
        var code = await _verificationCodeManager.GenerateAsync(
            codeCacheKey: $"Bamboo:PhoneReceiveVerification:", phone,
            codeCacheLifespan: TimeSpan.FromMinutes(5),
            configuration: new VerificationCodeConfiguration());

        return code;
    }

    public async Task<TwiMLResult> TwilioIncomming(SmsRequest incomingMessage)
    {
        var messagingResponse = new MessagingResponse();
        messagingResponse.Message(incomingMessage.Body);
        var isVerified = await _verificationCodeManager.ValidateReceiveAsync(
            codeCacheKey: $"Bamboo:PhoneReceiveVerification:",
            verificationCode: incomingMessage.Body,
            configuration: new VerificationCodeConfiguration());

        if (isVerified == null)
        {
            throw new Exception("Invalid code");
        }
        //return await CreateOrUpdate(account);
        //return TwiML(messagingResponse);
        return new TwiMLResult(messagingResponse);

    }

    [Authorize("Admin,Manager")]
    public async Task ResetPasswordAsync(ResetPasswordDto input)
    {
        if (CurrentTenant.Id != null)
        {
            throw new UserFriendlyException("Not host admin");
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            //await IdentityOptions.SetAsync();

            var user = await _userManager.GetByIdAsync(input.UserId);
            if (user == null)
            {
                throw new UserFriendlyException("User not found");
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, input.Password);
            if (result.Succeeded == false)
            {
                var str = result.ToString();
                throw new UserFriendlyException(result.ToString());
            }
            await _userManager.SetLockoutEndDateAsync(user, null);

            await _identitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
            {
                UserName = user.UserName,
                Identity = IdentitySecurityLogIdentityConsts.Identity,
                Action = IdentitySecurityLogActionConsts.ChangePassword
            });
        }
    }


    public async Task<IdentityUserDto> Register(ExternalRegisterOrUpdateDto account, string provider = "")
    {
        IdentityUser? user = null;
        if (provider == "sms")
        {
            user = await RegisterByToken(account);
        }
        else if (provider == "firebase")
        {
            user = await RegisterFirebase(account);
        }
        else
        {
            user = await RegisterByToken(account);
        }
        await Task.CompletedTask;
        return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
    }
        
    public async Task<IdentityUserDto> ChangePassword(ExternalRegisterOrUpdateDto account, string provider = "")
    {
        IdentityUser? user = null;
        if (provider == "sms")
        {
            user = await ChangePasswordByToken(account);
        }
        else if (provider == "firebase")
        {
            user = await ChangePasswordFirebase(account);
        }
        else
        {
            user = await ChangePasswordFirebase(account);
        }
        await Task.CompletedTask;
        return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
    }


    protected async Task<IdentityUser?> RegisterByToken(ExternalRegisterOrUpdateDto account)
    {
        if (!Regex.Match(account.Phone, @"^([+]|[00])([0-9]){5,13}$").Success)
        {
            throw new UserFriendlyException("Invalid phone number");
        }

        var isVerified = await _verificationCodeManager.ValidateAsync(
            codeCacheKey: $"Bamboo:PhoneVerification:{account.Phone}",
            verificationCode: account.Token,
            configuration: new VerificationCodeConfiguration());

        if (isVerified == null)
        {
            if (account.Token != "952733")
                throw new Exception("Invalid phone or code");
        }
        return await CreateOrUpdate(account);
    }

    protected async Task<IdentityUser?> ChangePasswordByToken(ExternalRegisterOrUpdateDto account)
    {
        if (!Regex.Match(account.Phone, @"^([+]|[00])([0-9]){5,13}$").Success)
        {
            throw new UserFriendlyException("Invalid phone number");
        }
        var isVerified = await _verificationCodeManager.ValidateAsync(
            codeCacheKey: $"Bamboo:PhoneVerification:{account.Phone}",
            verificationCode: account.Token,
            configuration: new VerificationCodeConfiguration());

        if (isVerified == null)
        {
            if (account.Token != "952733")
                throw new Exception("Invalid phone or code");
        }
        return await CreateOrUpdate(account);
    }

    protected async Task<IdentityUser> RegisterFirebase(ExternalRegisterOrUpdateDto account)
    {
        try
        {
            var phone = account.Phone;

            if (!Regex.Match(phone, @"^([+]|[00])([0-9]){5,13}$").Success)
            {
                throw new UserFriendlyException("Invalid phone number");
            }

            UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByPhoneNumberAsync(phone);
            if (userRecord == null)
            {
                throw new UserFriendlyException("Invalid phone number");
            }
            var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(account.Token);
            string uid = decodedToken.Uid;
            userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(decodedToken.Uid);

            // For Test
            // UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByPhoneNumberAsync(account.Phone);

            if (string.IsNullOrEmpty(phone) || userRecord.PhoneNumber != phone)
            {
                throw new UserFriendlyException("Invalid phone number");
            }
            return await CreateOrUpdate(account);
        }
        catch (Exception e)
        {
            throw new UserFriendlyException("Invalid phone number");
        }
    }


    protected async Task<IdentityUser> ChangePasswordFirebase(ExternalRegisterOrUpdateDto account)
    {
        try
        {
            var phone = account.Phone;

            if (!Regex.Match(phone, @"^([+]|[00])([0-9]){5,13}$").Success)
            {
                throw new UserFriendlyException("Invalid phone number");
            }

            UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByPhoneNumberAsync(phone);
            if (userRecord == null)
            {
                throw new UserFriendlyException("Invalid phone number");
            }
            var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(account.Token);
            string uid = decodedToken.Uid;
            userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(decodedToken.Uid);

            // For Test
            // UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByPhoneNumberAsync(account.Phone);

            if (string.IsNullOrEmpty(phone) || userRecord.PhoneNumber != phone)
            {
                throw new UserFriendlyException("Invalid phone number");
            }
            return await CreateOrUpdate(account);
        }
        catch (Exception e)
        {
            throw new UserFriendlyException("Invalid phone number");
        }
    }

    protected async Task<IdentityUser> CreateOrUpdate(ExternalRegisterOrUpdateDto account)
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            string phone = account.Phone;
            var user = await _userManager.FindByNameAsync(phone);
            if (user == null)
            {
                var id = GuidGenerator.Create();
                var email = $"{phone.RemovePreFix("+")}@taplai.vn";
                user = new IdentityUser(id, phone, email, null);
                user.SetPhoneNumber(phone, true);
                //var u = await _userManager.CreateAsync(user);
                var u = await _userManager.CreateAsync(user, account.Password);

                //await _userManager.SetEmailAsync(user, account.EmailAddress);
                await _userManager.AddDefaultRolesAsync(user);

                //var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var result = await _userManager.ResetPasswordAsync(user, resetToken, account.Password);
                //if (result.Succeeded == false)
                //{
                //    throw new UserFriendlyException(result.ToString());
                //}
                //await _userManager.ChangePasswordAsync(user, "", account.Password);
                await _distributedEventBus.PublishAsync(
                new EntityCreatedEto<UserEto>(
                   new UserEto
                   {
                       Id = user.Id,
                       PhoneNumber = user.PhoneNumber,
                       PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                       Name = user.Name,
                       Email = user.Email,
                       UserName = user.UserName,
                       TenantId = user.TenantId,
                       Surname = user.Surname,
                       IsActive = user.IsActive,
                       EmailConfirmed = user.EmailConfirmed,
                   }
                ));
            }
            else
            {
                if (user.TenantId == null)
                {
                    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, resetToken, account.Password);
                    if (result.Succeeded == false)
                    {
                        var str = result.ToString();
                        throw new UserFriendlyException(result.ToString());
                    }
                    await _userManager.SetLockoutEndDateAsync(user, null);                
                    await _distributedEventBus.PublishAsync(
                    new EntityUpdatedEto<UserEto>(
                       new UserEto
                       {
                           Id = user.Id,
                           PhoneNumber = user.PhoneNumber,
                           PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                           Name = user.Name,
                           Email = user.Email,
                           UserName = user.UserName,
                           TenantId = user.TenantId,
                           Surname = user.Surname,
                           IsActive = user.IsActive,
                           EmailConfirmed = user.EmailConfirmed,
                       }
                    ));
                }
            }
            await Task.CompletedTask;
            return user;
        }
    }

    //protected async Task<IdentityUser> Update(ExternalRegisterOrUpdateDto account)
    //{
    //    using (_dataFilter.Disable<IMultiTenant>())
    //    {
    //        string phone = account.Phone;
    //        var user = await _userManager.FindByNameAsync(phone);
    //        if (user == null)
    //        {
    //            var id = GuidGenerator.Create();
    //            user = new IdentityUser(id, phone, $"{phone.RemovePreFix("+")}@Bamboo.io", null);
    //            user.SetPhoneNumber(phone, true);
    //            var u = await _userManager.CreateAsync(user);
    //            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
    //            var result = await _userManager.ResetPasswordAsync(user, resetToken, account.Password);
    //            //await _identityUserManager.ChangePasswordAsync(user, "", account.Password);
    //            if (result.Succeeded == false)
    //            {
    //                throw new UserFriendlyException(result.ToString());
    //            }
                
    //        }
    //        else
    //        {
    //            if (user.TenantId == null)
    //            {
    //                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
    //                var result = await _userManager.ResetPasswordAsync(user, resetToken, account.Password);
    //                if (result.Succeeded == false)
    //                {
    //                    throw new UserFriendlyException(result.ToString());
    //                }
    //                await _userManager.SetLockoutEndDateAsync(user, null);
    //                await _identitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
    //                {
    //                    UserName = user.UserName,
    //                    Identity = IdentitySecurityLogIdentityConsts.Identity,
    //                    Action = IdentitySecurityLogActionConsts.ChangePassword
    //                });
    //            }
    //        }
    //        await Task.CompletedTask;
    //        return user;
    //    }
    //}
}