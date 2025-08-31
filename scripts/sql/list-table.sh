#!/bin/bash
psql -p 5434 -h 3.0.46.229 -U postgres -d odoo16_extras -f list-table-col-data-type.sql -o odoo16_extras_type_remote.txt
psql -p 5434 -h 127.0.0.1 -U odoo -d odoo16_extras -f list-table-col-data-type.sql -o odoo16_extras_type_local.txt

#psql -p 5432 -h 127.0.0.1 -U postgres -d bamboo_1618_uuid -f list-table.sql -o bamboo_18_uuid_type.txt
#psql -p 5432 -h 127.0.0.1 -U postgres -d odoo18 -f list-table.sql -o odoo18_type.txt

