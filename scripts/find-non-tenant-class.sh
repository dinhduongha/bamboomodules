#!/bin/bash

# Thư mục gốc để tìm (có thể thay đổi hoặc dùng tham số)
SEARCH_DIR="."

# Mẫu cần tìm
PATTERN='public Guid\? TenantId { get; set; }'

# Tìm tất cả các file .cs không chứa dòng mẫu
grep -L -R --include="*.cs" "$PATTERN" "$SEARCH_DIR"

