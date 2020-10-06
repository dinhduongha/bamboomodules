# Bamboo Modules

This repository contain modules for Bamboo, a Dotnet Core ERP/CRM application base on aspboilerplate and blazor. 

# Directories structure

Every modules should have 4 sub modules:

## Bamboo.(ModuleName).Shared

Define DTOs and Interfaces which can shared between Server and Blazor client.

## Bamboo.(ModuleName).Core

This module only available on server side.

Define entities which can be used by Bamboo.EntityFrameworkCore for create table in database.

Every server's DomainService also should be put here.

## Bamboo.(ModuleName).Application

This module is similar Application Service Module. This module provide API/Service for client.

## Bamboo.(ModuleName).Client

This module will be use by Blazor/C# client.
