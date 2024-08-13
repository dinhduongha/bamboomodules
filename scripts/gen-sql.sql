SELECT concat('update ', table_name, ' set ', column_name, ' = ''2024-01-01'' ', 'where ', column_name, ' is null;') as u
  ,table_name, column_name, data_type, information_schema.columns.*
  FROM information_schema.columns
 WHERE table_schema = 'public'
 and column_name='create_date'
 and is_updatable='YES'
 order by table_name, column_name