-- UPDATE all NULL (orphan) company_id to main_company
DO $$
DECLARE
    -- << HÃY THAY ĐỔI SỐ 1 THÀNH ID CÔNG TY CHÍNH CỦA BẠN >>
    default_company_id INTEGER := 1;

    -- Biến để thực thi vòng lặp
    r RECORD;
    rows_affected INTEGER;
BEGIN
    RAISE NOTICE '--- Bắt đầu quá trình cập nhật hàng loạt company_id ---';
    RAISE NOTICE 'Sử dụng company_id mặc định là: %', default_company_id;

    -- Vòng lặp qua tất cả các BẢNG GỐC có cột 'company_id'
    FOR r IN
        SELECT c.table_name
        FROM information_schema.columns AS c
        JOIN information_schema.tables AS t
            ON c.table_schema = t.table_schema AND c.table_name = t.table_name
        WHERE
            c.column_name = 'company_id'
            AND t.table_schema = 'public'
            AND t.table_type = 'BASE TABLE' -- SỬA ĐỔI QUAN TRỌNG: Chỉ lấy các bảng gốc, bỏ qua các VIEW
    LOOP
        -- Xây dựng và thực thi câu lệnh UPDATE một cách động
        EXECUTE format(
            'UPDATE %I SET company_id = %s WHERE company_id IS NULL;',
            r.table_name, default_company_id
        );

        -- Lấy số dòng đã được cập nhật
        GET DIAGNOSTICS rows_affected = ROW_COUNT;

        -- Chỉ in ra thông báo nếu có sự thay đổi
        IF rows_affected > 0 THEN
            RAISE NOTICE 'Bảng: % -> Đã cập nhật % dòng.', r.table_name, rows_affected;
        END IF;

    END LOOP;

    RAISE NOTICE '--- Quá trình cập nhật hoàn tất ---';
END $$;
