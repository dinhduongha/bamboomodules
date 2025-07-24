#!/bin/bash
# Move all data from old-odoo16 (with id is integer) to new-odoo18 (with id is uuid)
# Keep schema on destionation database. No new table / column. Recreate indexes 

pgloader --verbose --dynamic-space-size 4096 conf/pgloader-odoo16-data-full-uuid.conf > log16-data.txt

