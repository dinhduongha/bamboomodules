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
    public partial class ResCompanyLdapAppService
    {

        protected async Task<ResCompanyLdap> AuthenticateInternalAsync(object conf, object login, object password)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _authenticate) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> ChangePasswordInternalAsync(object conf, object login, object old_passwd, object new_passwd)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _change_password) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> ConnectInternalAsync(object conf)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _connect) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> GetEntryInternalAsync(object conf, object login)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _get_entry) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> GetLdapDictsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _get_ldap_dicts) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> GetOrCreateUserInternalAsync(object conf, object login, object ldap_entry)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _get_or_create_user) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> MapLdapAttributesInternalAsync(object conf, object login, object ldap_entry)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _map_ldap_attributes) ---
            */
            return default;
        }

        protected async Task<ResCompanyLdap> QueryInternalAsync(object conf, object filter, object retrieve_attributes)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_company_ldap.py, METHOD: _query) ---
            */
            return default;
        }
    }
}