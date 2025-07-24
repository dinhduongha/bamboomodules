#!/bin/bash
# Create schema and move data from old-odoo16 (with id is integer) to new-odoo18 (with id is uuid)
# BE AWARE: All tables on destination database will be drop and re-create. No extra field.

pgloader --verbose --dynamic-space-size 4096 conf/pgloader-odoo16-schema-full-uuid.conf > log16-schema-full.txt

