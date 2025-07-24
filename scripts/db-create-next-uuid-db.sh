#!/bin/bash
# Create DB with next_uuid() function
PG_PASSWORD=pgRoot@@PasswOrd psql -p 5432 -h 127.0.0.1 -U postgres -f sql/create-generic.sql
