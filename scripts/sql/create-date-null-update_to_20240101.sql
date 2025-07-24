DO $$
DECLARE
    table_rec RECORD;
    update_query TEXT;
    total_updated INTEGER := 0;
BEGIN
    FOR table_rec IN (
        SELECT table_schema, table_name
        FROM information_schema.columns
        WHERE column_name = 'create_date'
        AND table_schema NOT IN ('pg_catalog', 'information_schema')
    ) LOOP
        update_query := format(
            'UPDATE %I.%I SET create_date = ''2024-01-01'' WHERE create_date IS NULL',
            table_rec.table_schema,
            table_rec.table_name
        );
        EXECUTE update_query;
        GET DIAGNOSTICS total_updated = ROW_COUNT;
        RAISE NOTICE 'Table %.% updated % rows', 
            table_rec.table_schema, 
            table_rec.table_name, 
            total_updated;
    END LOOP;
    RAISE NOTICE 'Update completed for all tables with create_date column.';
EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Error updating tables: %', SQLERRM;
END;
$$;
