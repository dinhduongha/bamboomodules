using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public class IrSequenceAppService : GenericApplicationService<IrSequence>, IIrSequenceAppService
    {

        public IrSequenceAppService(IRepository<IrSequence, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrSequence> CreateDateRangeSeqInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _create_date_range_seq(self, date):
            // year = fields.Date.from_string(date).strftime('%Y')
            // date_from = '{}-01-01'.format(year)
            // date_to = '{}-12-31'.format(year)
            // date_range = self.env['ir.sequence.date_range'].search([('sequence_id', '=', self.id), ('date_from', '>=', date), ('date_from', '<=', date_to)], order='date_from desc', limit=1)
            // if date_range:
            //     date_to = date_range.date_from + timedelta(days=-1)
            // date_range = self.env['ir.sequence.date_range'].search([('sequence_id', '=', self.id), ('date_to', '>=', date_from), ('date_to', '<=', date)], order='date_to desc', limit=1)
            // if date_range:
            //     date_from = date_range.date_to + timedelta(days=1)
            // seq_date_range = self.env['ir.sequence.date_range'].sudo().create({
            //     'date_from': date_from,
            //     'date_to': date_to,
            //     'sequence_id': self.id,
            // })
            // return seq_date_range
            */
            return default;
        }

        protected async Task<IrSequence> GetCurrentSequenceInternalAsync(object sequence_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _get_current_sequence(self, sequence_date=None):
            // '''Returns the object on which we can find the number_next to consider for the sequence.
            // It could be an ir.sequence or an ir.sequence.date_range depending if use_date_range is checked
            // or not. This function will also create the ir.sequence.date_range if none exists yet for today
            // '''
            // if not self.use_date_range:
            //     return self
            // sequence_date = sequence_date or fields.Date.today()
            // seq_date = self.env['ir.sequence.date_range'].search(
            //     [('sequence_id', '=', self.id), ('date_from', '<=', sequence_date), ('date_to', '>=', sequence_date)], limit=1)
            // if seq_date:
            //     return seq_date[0]
            // #no date_range sequence was found, we create a new one
            // return self._create_date_range_seq(sequence_date)
            */
            return default;
        }

        public async Task<IrSequence> GetNextCharAsync(Guid id, IrSequenceGetNextCharRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def get_next_char(self, number_next):
            // interpolated_prefix, interpolated_suffix = self._get_prefix_suffix()
            // return interpolated_prefix + '%%0%sd' % self.padding % number_next + interpolated_suffix
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrSequence> GetNumberNextActualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _get_number_next_actual(self):
            // '''Return number from ir_sequence row when no_gap implementation,
            // and number from postgres sequence when standard implementation.'''
            // for seq in self:
            //     if not seq.id:
            //         seq.number_next_actual = 0
            //     elif seq.implementation != 'standard':
            //         seq.number_next_actual = seq.number_next
            //     else:
            //         seq_id = "%03d" % seq.id
            //         seq.number_next_actual = _predict_nextval(self, seq_id)
            */
            return default;
        }

        protected async Task<IrSequence> GetPrefixSuffixInternalAsync(object date, object date_range)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _get_prefix_suffix(self, date=None, date_range=None):
            // def _interpolate(s, d):
            //     return (s % d) if s else ''
            // 
            // def _interpolation_dict():
            //     now = range_date = effective_date = datetime.now(self.env.tz)
            //     if date or self.env.context.get('ir_sequence_date'):
            //         effective_date = fields.Datetime.from_string(date or self.env.context.get('ir_sequence_date'))
            //     if date_range or self.env.context.get('ir_sequence_date_range'):
            //         range_date = fields.Datetime.from_string(date_range or self.env.context.get('ir_sequence_date_range'))
            // 
            //     sequences = {
            //         'year': '%Y', 'month': '%m', 'day': '%d', 'y': '%y', 'doy': '%j', 'woy': '%W',
            //         'weekday': '%w', 'h24': '%H', 'h12': '%I', 'min': '%M', 'sec': '%S',
            //         'isoyear': '%G', 'isoy': '%g', 'isoweek': '%V',
            //     }
            //     res = {}
            //     for key, format in sequences.items():
            //         res[key] = effective_date.strftime(format)
            //         res['range_' + key] = range_date.strftime(format)
            //         res['current_' + key] = now.strftime(format)
            // 
            //     return res
            // 
            // self.ensure_one()
            // d = _interpolation_dict()
            // try:
            //     interpolated_prefix = _interpolate(self.prefix, d)
            //     interpolated_suffix = _interpolate(self.suffix, d)
            // except (ValueError, TypeError, KeyError):
            //     raise UserError(_('Invalid prefix or suffix for sequence “%s”', self.name))
            // return interpolated_prefix, interpolated_suffix
            */
            return default;
        }

        public async Task<IrSequence> NextByCodeAsync(Guid id, IrSequenceNextByCodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def next_by_code(self, sequence_code, sequence_date=None):
            // """ Draw an interpolated string using a sequence with the requested code.
            //     If several sequences with the correct code are available to the user
            //     (multi-company cases), the one from the user's current company will
            //     be used.
            // """
            // self.browse().check_access('read')
            // company_id = self.env.company.id
            // seq_ids = self.search([('code', '=', sequence_code), ('company_id', 'in', [company_id, False])], order='company_id')
            // if not seq_ids:
            //     _logger.debug("No ir.sequence has been found for code '%s'. Please make sure a sequence is set for current company." % sequence_code)
            //     return False
            // seq_id = seq_ids[0]
            // return seq_id._next(sequence_date=sequence_date)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrSequence> NextByIdAsync(Guid id, IrSequenceNextByIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def next_by_id(self, sequence_date=None):
            // """ Draw an interpolated string using the specified sequence."""
            // self.browse().check_access('read')
            // return self._next(sequence_date=sequence_date)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrSequence> NextDoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _next_do(self):
            // if self.implementation == 'standard':
            //     number_next = _select_nextval(self.env.cr, 'ir_sequence_%03d' % self.id)
            // else:
            //     number_next = _update_nogap(self, self.number_increment)
            // return self.get_next_char(number_next)
            */
            return default;
        }

        protected async Task<IrSequence> NextInternalAsync(object sequence_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _next(self, sequence_date=None):
            // """ Returns the next number in the preferred sequence in all the ones given in self."""
            // if not self.use_date_range:
            //     return self._next_do()
            // # date mode
            // dt = sequence_date or self.env.context.get('ir_sequence_date', fields.Date.today())
            // seq_date = self.env['ir.sequence.date_range'].search([('sequence_id', '=', self.id), ('date_from', '<=', dt), ('date_to', '>=', dt)], limit=1)
            // if not seq_date:
            //     seq_date = self._create_date_range_seq(dt)
            // return seq_date.with_context(ir_sequence_date_range=seq_date.date_from)._next()
            */
            return default;
        }

        protected async Task<IrSequence> SetNumberNextActualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_sequence.py) ---
            // def _set_number_next_actual(self):
            // for seq in self:
            //     seq.write({'number_next': seq.number_next_actual or 1})
            */
            return default;
        }

        protected async Task<IrSequence> UnlinkSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: ir_sequence.py) ---
            // def _unlink_sequence(self):
            // configs = self.env['pos.config'].search(domain=[
            //     '|', '|', '|',
            //     ('order_seq_id', 'in', self.ids),
            //     ('order_line_seq_id', 'in', self.ids),
            //     ('device_seq_id', 'in', self.ids),
            //     ('order_backend_seq_id', 'in', self.ids)
            // ])
            // if len(configs):
            //     raise UserError(_(
            //         "You cannot delete a sequence used in an active POS config: %s",
            //         configs.order_seq_id.mapped('name')
            //     ))
            */
            return default;
        }
    }
}