using Volo.Abp.ObjectMapping;
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
    [Module("board", Category = "Productivity", Depends = new[] { "spreadsheet_dashboard" })]
    public partial class BoardBoardAppService : ApplicationService, IBoardBoardAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public BoardBoardAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ArchPreprocessingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IBoardBoardable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: board, FILE: board.py) ---
            // def _arch_preprocessing(self, arch):
            // from lxml import etree
            // 
            // def remove_unauthorized_children(node):
            //     for child in node.iterchildren():
            //         if child.tag == 'action' and child.get('invisible'):
            //             node.remove(child)
            //         else:
            //             remove_unauthorized_children(child)
            //     return node
            // 
            // archnode = etree.fromstring(arch)
            // # add the js_class 'board' on the fly to force the webclient to
            // # instantiate a BoardView instead of FormView
            // archnode.set('js_class', 'board')
            // return etree.tostring(remove_unauthorized_children(archnode), pretty_print=True, encoding='unicode')
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IBoardBoardable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: board, FILE: board.py) ---
            // def create(self, vals_list):
            // return self
            */
            return default;
        }

        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBoardBoardable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: board, FILE: board.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // """
            // Overrides orm field_view_get.
            // @return: Dictionary of Fields, arch and toolbar.
            // """
            // 
            // res = super().get_view(view_id, view_type, **options)
            // 
            // custom_view = self.env['ir.ui.view.custom'].sudo().search([('user_id', '=', self.env.uid), ('ref_id', '=', view_id)], limit=1)
            // if custom_view:
            //     res.update({'custom_view_id': custom_view.id,
            //                 'arch': custom_view.arch})
            // res['arch'] = self._arch_preprocessing(res['arch'])
            // return res
            */
            return default;
        }
    }
}