#!/bin/bash
# ls -p | grep -v ./
BASE_PATH="${1:-data/Generated-19/NameSpaceFlat/src/}"
#BASE_PATH="${1:-$(pwd)}"
#DST_SERVICES="${2:-services/core/src/}"
DST_SERVICES=services/core/src
DST_SHARED=shared/core/

mkdir -p $DST_SHARED/Bamboo.Core.Domain.Shared/
mkdir -p $DST_SHARED/Bamboo.Core.Application.Contracts/
mkdir -p $DST_SERVICES/Bamboo.Core.Application/Services/
mkdir -p $DST_SERVICES/Bamboo.Core.HttpApi/Controllers/

cp -avr $BASE_PATH/Bamboo.Core.Domain.Shared/Interfaces $DST_SHARED/Bamboo.Core.Domain.Shared/
cp -avr $BASE_PATH/Bamboo.Core.Application.Contracts/DTOs $DST_SHARED/Bamboo.Core.Application.Contracts/
cp -avr $BASE_PATH/Bamboo.Core.Application.Contracts/Interfaces $DST_SHARED/Bamboo.Core.Application.Contracts/
cp -avr $BASE_PATH/Bamboo.Core.Application/Services/* $DST_SERVICES/Bamboo.Core.Application/Services
cp -avr $BASE_PATH/Bamboo.Core.HttpApi/Controllers/* $DST_SERVICES/Bamboo.Core.HttpApi/Controllers 