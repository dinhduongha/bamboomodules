SELECT concat('column  ', table_name, '.', column_name, ' to bigint,') as u
, table_name, column_name, data_type, information_schema.columns.*
  FROM information_schema.columns
 WHERE table_schema = 'public'
 and column_name like '%id'
and data_type = 'bigint'
order by table_name