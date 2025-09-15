#!/bin/bash
rm -rf data/Generated
#rm -rf data/Generated/NameSpace
#rm -rf data/Generated/NameSpaceFlat
#rm -rf data/Generated/NameSpaceFlat-Run
#rm -rf data/Generated/FlatAll
# ls -p | grep -v ./
python3 scripts/tools/generate_abp_scaffold.py -s /home/ha/work/dockers/odoo /home/ha/work/dockers/odoo18/addons --group-by-category --flat-structure model --flat-namespace model service controller --entity-property-order abc --include-private-methods --flat-by-cat -o data/Generated/NameSpaceFlat

#python3 scripts/tools/generate_abp_scaffold-run.py -s /home/ha/work/dockers/odoo /home/ha/work/dockers/odoo18/addons --group-by-category --flat-structure model --flat-namespace model --entity-property-order type --include-private-methods -o data/Generated/NameSpaceFlat-Run

#python3 scripts/tools/generate_abp_scaffold.py -s /home/ha/work/dockers/odoo /home/ha/work/dockers/odoo18/addons --group-by-category --flat-structure model --entity-property-order type --include-private-methods -o data/Generated/Begin

#python3 scripts/tools/generate_abp_scaffold.py -s /home/ha/work/dockers/odoo /home/ha/work/dockers/odoo18/addons --group-by-category --flat-structure model --entity-property-order abc --include-private-methods -o data/Generated/NameSpace

#python3 scripts/tools/generate_abp_scaffold.py -s /home/ha/work/dockers/odoo /home/ha/work/dockers/odoo18/addons --group-by-category --flat-structure all --flat-namespace model,service,controller --entity-property-order abc --include-private-methods --add-common-actions -o data/Generated/FlatAll

#python3 scripts/tools/generate_abp_scaffold.py -s /home/ha/work/dockers/odoo /home/ha/work/dockers/odoo18/addons --group-by-category --flat-structure model --entity-property-order abc --generate-services all --include-private-methods --add-common-actions -o data/Generated/All
