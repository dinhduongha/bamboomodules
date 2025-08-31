DO $$
DECLARE
    table_rec RECORD;
    update_query TEXT;
    total_updated INTEGER := 0;
BEGIN
    FOR table_rec IN (
        SELECT t.table_schema, c.table_name
        FROM information_schema.columns AS c
        JOIN information_schema.tables AS t
            ON c.table_schema = t.table_schema AND c.table_name = t.table_name
		WHERE
            c.column_name = 'create_date'
            AND t.table_schema = 'public'
            AND t.table_type = 'BASE TABLE'
		ORDER BY c.table_name
    ) LOOP
        update_query := format(
            'UPDATE %I.%I SET create_date = ''2024-01-01'' WHERE create_date IS NULL',
            table_rec.table_schema,
            table_rec.table_name
        );
        EXECUTE update_query;
        GET DIAGNOSTICS total_updated = ROW_COUNT;
        IF total_updated > 0 THEN 
            RAISE NOTICE 'Table %.% updated % rows', 
                table_rec.table_schema, 
                table_rec.table_name, 
                total_updated;
        END IF;
    END LOOP;
    RAISE NOTICE 'Update completed for all tables with create_date column.';
EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Error updating tables: %', SQLERRM;
END;
$$;
