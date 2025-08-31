WITH CandidateTables AS (
    -- Bước 1: Tìm tất cả các bảng có khóa ngoại đến CẢ HAI bảng bạn quan tâm
    SELECT
        kcu.table_schema,
        kcu.table_name
    FROM
        information_schema.table_constraints AS tc
        JOIN information_schema.key_column_usage AS kcu
          ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema
        JOIN information_schema.constraint_column_usage AS ccu
          ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema
    WHERE
        tc.constraint_type = 'FOREIGN KEY'
        AND ccu.table_name IN ('res_partner', 'product_product')
    GROUP BY
        kcu.table_schema,
        kcu.table_name
    HAVING
        COUNT(DISTINCT ccu.table_name) = 2
)
-- Bước 2: Từ các bảng ứng viên, lấy thông tin chi tiết về các cột
SELECT
    ct.table_schema,
    ct.table_name AS join_table_name,
    COUNT(c.column_name) AS total_columns,
    STRING_AGG(c.column_name, ', ') AS columns_in_table
FROM
    CandidateTables AS ct
    JOIN information_schema.columns AS c
      ON ct.table_schema = c.table_schema AND ct.table_name = c.table_name
GROUP BY
    ct.table_schema,
    ct.table_name
ORDER BY
    total_columns; -- Sắp xếp theo tổng số cột để bảng ít cột nhất nổi lên trên
