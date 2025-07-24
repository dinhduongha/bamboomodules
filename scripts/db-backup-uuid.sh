#!/bin/bash
set "PGPASSWORD=pgRoot@@PasswOrd"
pg_dump -d bamboo_core -h 127.0.0.1 -p 5432 -a -v -U bamboo -p 5432 -F tar -f backup-uuid.tar --exclude-table='timescaledb.*' --exclude-table='*timescaledb*'

