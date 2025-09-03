#!/bin/bash
# Move all data from old-odoo18 (with id is integer) to new-odoo18 (with id is uuid)
# Keep schema on destionation database. No new table / column. Recreate indexes 
# Add --dynamic-space-size 4096 ( use 4GB memory if large database)

# Replace your host/db/username/password in file conf/pgloader-odoo18-data-full-uuid.conf

pgloader --verbose --dynamic-space-size 4096 pgloader/conf/pgloader-odoo18-data-full-uuid.conf > log18-data.txt


