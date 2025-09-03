#!/bin/bash
mc alias set myminio http://127.0.0.1:9000 minioadmin minioadmin # access key & secret key

# Tạo policy
mc admin policy create myminio public-policy public-policy.json
mc admin policy create myminio user-policy user-policy.json

# Cho phép anonymous GET apps, images
mc anonymous set-json public-policy myminio/miniapp

# Gán user policy cho user minapp
mc admin policy attach myminio user-policy --user minapp

