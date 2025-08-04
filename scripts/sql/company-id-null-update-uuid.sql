-- UPDATE all NULL (orphan) company_id to main_company (using UUID)
DO $$
DECLARE
    -- << THAY THẾ BẰNG GUID CỦA CÔNG TY CHÍNH >>
    -- Thay đổi kiểu dữ liệu từ INTEGER sang UUID
    default_company_id UUID := '00000000-0000-0000-0000-000000000001'; -- ví dụ

    -- Biến để thực thi vòng lặp
    r RECORD;
    rows_affected INTEGER;
BEGIN
    RAISE NOTICE '--- Bắt đầu quá trình cập nhật hàng loạt company_id (UUID) ---';
    RAISE NOTICE 'Sử dụng company_id mặc định là: %', default_company_id;

    -- Vòng lặp qua tất cả các bảng cần cập nhật (logic không thay đổi)
    FOR r IN
        SELECT c.table_name
        FROM information_schema.columns AS c
        JOIN information_schema.tables AS t
            ON c.table_schema = t.table_schema AND c.table_name = t.table_name
        WHERE
            c.column_name = 'company_id'
            AND t.table_schema = 'public'
            AND t.table_type = 'BASE TABLE'
            AND (
                (
                    t.table_name NOT LIKE 'base_%'
                    AND t.table_name NOT LIKE 'ir_%'
                    AND t.table_name NOT LIKE 'res_%'
                    AND t.table_name NOT IN (
                        'auth_totp_device', 
                        'auth_totp_wizard',
                        'bus_bus',
                        'bus_presence',
                        'demical_precision',
                        'report_layout',
                        'report_paperformat',
                        'web_editor_converter_test',
                        'web_editor_converter_test_sub',
                        'web_tour_tour',
                        'web_tour_tour_step',
                        'wizard_ir_model_menu_create'
                        )
                )
                OR
                (
                    t.table_name IN (
                        'base_document_layout',
                        'base_partner_merge_automatic_wizard',
                        'base_partner_merge_line',
                        'ir_attachment',
                        'ir_default',
                        'ir_mail_server',
                        'ir_property'
                        'ir_sequence',
                        -- 'ir_model_access',
                        -- 'ir_model_field_access',
                        -- 'ir_rule',
                        -- 'res_users',
                        'res_config_settings',
                        'res_currency_rate',
                        'res_partner',
                        'res_partner_bank'
                    )
                )
            )
    LOOP
        -- Thay đổi quan trọng: Dùng %L thay cho %s để xử lý giá trị UUID/text
        EXECUTE format(
            'UPDATE public.%I SET company_id = %L WHERE company_id IS NULL;',
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