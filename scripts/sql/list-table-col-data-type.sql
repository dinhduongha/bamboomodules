SELECT 
  concat(c.table_name, '.', c.column_name), c.is_nullable, c.data_type as u
FROM information_schema.columns c
JOIN information_schema.tables t
  ON c.table_schema = t.table_schema AND c.table_name = t.table_name
WHERE c.table_schema = 'public'
  AND t.table_type = 'BASE TABLE'
ORDER BY c.table_name, c.column_name;