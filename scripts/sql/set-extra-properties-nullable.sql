DO $$
DECLARE
    rec RECORD;
    alter_stmt TEXT;
    table_count INTEGER := 0;
BEGIN
    -- Lặp qua tất cả các bảng có cột 'extra_properties' với constraint NOT NULL
    FOR rec IN (
        SELECT table_schema, table_name
        FROM information_schema.columns
        WHERE column_name = 'extra_properties'
        AND table_schema = 'public'
        AND is_nullable = 'NO'
    ) LOOP
        -- Tạo câu lệnh ALTER TABLE
        alter_stmt := format('ALTER TABLE %I.%I ALTER COLUMN extra_properties DROP NOT NULL;',
                            rec.table_schema, rec.table_name);
        
        -- Thực thi câu lệnh
        EXECUTE alter_stmt;
        
        -- Tăng bộ đếm
        table_count := table_count + 1;
        
        -- In ra câu lệnh đã thực thi
        RAISE NOTICE 'Altered table: %.%, column extra_properties is now nullable', 
                     rec.table_schema, rec.table_name;
    END LOOP;

    -- Thông báo kết quả
    IF table_count = 0 THEN
        RAISE NOTICE 'No tables with non-nullable extra_properties column found.';
    ELSE
        RAISE NOTICE 'Successfully altered % tables.', table_count;
    END IF;
END $$;