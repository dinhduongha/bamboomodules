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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("bus", Category = "Base", Depends = new[] { "base", "web" })]
    public partial class IrWebsocketAppService : ApplicationService, IIrWebsocketAppService
    {

        public IrWebsocketAppService() 
        {

        }

        public async Task<TEntity> AfterSubscribeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _after_subscribe_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _after_subscribe_data) ---
            */
            return default;
        }

        protected async Task<object> AuthenticateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _authenticate) ---
            */
            return default;
        }

        public async Task<TEntity> BuildBusChannelListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _build_bus_channel_list) ---
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_websocket.py, METHOD: _build_bus_channel_list) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: ir_websocket.py, METHOD: _build_bus_channel_list) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _build_bus_channel_list) ---
            */
            return default;
        }

        public async Task<TEntity> OnWebsocketClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cookies) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_websocket.py, METHOD: _on_websocket_closed) ---
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _on_websocket_closed) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _on_websocket_closed) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSubscribeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels, object last) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _prepare_subscribe_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _prepare_subscribe_data) ---
            */
            return default;
        }

        public async Task<TEntity> ServeIrWebsocketInternalAsync<TEntity>(IEnumerable<TEntity> entities, object event_name, object data) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _serve_ir_websocket) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _serve_ir_websocket) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object og_data) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py, METHOD: _subscribe) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateMailPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inactivity_period) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_websocket.py, METHOD: _update_mail_presence) ---
            --- METHOD SOURCE (MODULE: hr_presence, FILE: ir_websocket.py, METHOD: _update_mail_presence) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py, METHOD: _update_mail_presence) ---
            */
            return default;
        }
    }
}