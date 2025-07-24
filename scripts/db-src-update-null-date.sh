#!/bin/bash
PG_PASSWORD=PassWord123 psql -p 5432 -h 127.0.0.1 -U postgres -d odoo18 -f src/create-date-null-update_to_20240101.sql
