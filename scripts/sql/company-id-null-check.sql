DO $$
DECLARE
    r RECORD;
    null_count INTEGER;
BEGIN
    RAISE NOTICE '--- Bắt đầu kiểm tra các bảng ---';

    -- Vòng lặp qua tất cả các bảng có cột 'company_id'
    FOR r IN
        SELECT table_schema, table_name
        FROM information_schema.columns
        WHERE column_name = 'company_id' AND table_schema = 'public'
        ORDER BY table_name
    LOOP
        -- Với mỗi bảng, thực thi một lệnh đếm số dòng có company_id là NULL
        EXECUTE format('SELECT COUNT(*) FROM %I.%I WHERE company_id IS NULL', r.table_schema, r.table_name)
        INTO null_count;

        -- Nếu có dòng nào là NULL, thì in ra thông báo
        IF null_count > 0 THEN
            RAISE NOTICE 'Bảng: %, Số lượng NULL: %', r.table_name, null_count;
        END IF;
    END LOOP;

    RAISE NOTICE '--- Kiểm tra hoàn tất ---';
END $$;

