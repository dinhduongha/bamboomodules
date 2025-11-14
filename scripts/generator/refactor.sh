#!/bin/bash

# Odoo16-18
# rm -rf data/Models-Bamboo1618-Uuid-Converted/Models
# rm -rf data/Models-Bamboo1618-Uuid-Converted/Configurations
# python3 scripts/tools/refactor_fluent.py data/CoreDbContext/CoreDbContext-Bamboo1618-Uuid-Fluent.cs  data/Models-Bamboo1618-Uuid-Convert/ -oe data/Models-Bamboo1618-Uuid-Converted/Models/v16 -of data/Models-Bamboo1618-Uuid-Converted/Configurations/v16
# python3 scripts/tools/refactor_fluent.py fluent data/CoreDbContext/CoreDbContext-Bamboo1618-Uuid-Fluent.cs -o data/Models-Bamboo1618-Uuid-Converted/Configurations

# Odoo16
# rm -rf data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Models
# rm -rf data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Configurations
# # python3 scripts/tools/refactor_fluent.py entities --include-join-tables  data/Models-Odoo16-Uuid-Annotation-Origin/ -o data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Models
# # python3 scripts/tools/refactor_fluent.py fluent data/CoreDbContext/CoreDbContext-Odoo16-Uuid-Fluent.cs -o data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Configurations
# python3 scripts/tools/refactor_fluent.py data/CoreDbContext/CoreDbContext-Odoo16-Uuid-Fluent.cs data/Models-Odoo16-Uuid-Annotation-Origin -oe data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Models/main -of data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Configurations/main

# Odoo18
rm -rf data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Models
rm -rf data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Configurations
# # python3 scripts/tools/refactor_fluent.py entities --include-join-tables  data/Models-Odoo18-Uuid-Annotation-Origin/ -o data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Models > log18-model.txt
# # python3 scripts/tools/refactor_fluent.py fluent data/CoreDbContext/CoreDbContext-Odoo18-Uuid-Fluent.cs -o data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Configurations
python3 scripts/tools/refactor_fluent.py data/CoreDbContext/CoreDbContext-Odoo18-Uuid-Fluent.cs data/Models-Odoo18-Uuid-Annotation-Origin -oe data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Models/main -of data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Configurations/main

# Odoo19
rm -rf data/Models-Odoo19-Uuid-Annotation-Origin-Converted/Models
rm -rf data/Models-Odoo19-Uuid-Annotation-Origin-Converted/Configurations
# python3 scripts/tools/refactor_fluent.py entities --include-join-tables  data/Models-Odoo18-Uuid-Annotation-Origin/ -o data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Models > log18-model.txt
# python3 scripts/tools/refactor_fluent.py fluent data/CoreDbContext/CoreDbContext-Odoo18-Uuid-Fluent.cs -o data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Configurations
python3 scripts/tools/refactor_fluent.py data/CoreDbContext/CoreDbContext-Odoo19-Uuid-Fluent.cs data/Models-Odoo19-Uuid-Annotation-Origin -oe data/Models-Odoo19-Uuid-Annotation-Origin-Converted/Models/main -of data/Models-Odoo19-Uuid-Annotation-Origin-Converted/Configurations/main

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

#"$SCRIPT_DIR/copy-config.sh" data/Models-Bamboo1618-Uuid-Converted/Configurations/v16
#"$SCRIPT_DIR/copy-config.sh" data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Configurations/main
"$SCRIPT_DIR/copy-config.sh" data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Configurations/main
"$SCRIPT_DIR/copy-config.sh" data/Models-Odoo19-Uuid-Annotation-Origin-Converted/Configurations/main

#"$SCRIPT_DIR/copy-entities.sh" data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Models/main
"$SCRIPT_DIR/copy-entities.sh" data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Models/main
"$SCRIPT_DIR/copy-entities.sh" data/Models-Odoo19-Uuid-Annotation-Origin-Converted/Models/main
