using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class AuthPasskeyKeyAppService
    {

        protected async Task<AuthPasskeyKey> ComputePublicKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _compute_public_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> GetSessionChallengeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _get_session_challenge) ---
            */
            return default;
        }

        protected async Task<AuthPasskeyKey> InversePublicKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _inverse_public_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> StartAuthInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _start_auth) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> StartRegistrationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _start_registration) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> VerifyAuthInternalAsync(object auth, object public_key, object sign_count)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _verify_auth) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> VerifyRegistrationOptionsInternalAsync(object registration)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: _verify_registration_options) ---
            */
            return default;
        }
    }
}