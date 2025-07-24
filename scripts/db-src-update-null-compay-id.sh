#!/bin/bash
PG_PASSWORD=PassWord123 psql -p 5432 -h 127.0.0.1 -U postgres -d odoo18 -f src/company-id-null-update.sql
