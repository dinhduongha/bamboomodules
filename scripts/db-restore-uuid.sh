#!/bin/bash
set "PGPASSWORD=pgRoot@@PasswOrd"
pg_restore -d bamboo_core -h 127.0.0.1 -p 5432 -a -v -U bamboo -F tar backup-uuid.tar --disable-triggers

