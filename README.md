# Bamboo ERP 
 
 **Bamboo** is a porting of **Odoo ERP** to C# using ABP Framework.

# What's News (2003-05-03)
- **ABP** version v7.2.1
- Apply **microsevices** pattern.
- **Odoo 16**: Support almost entities ( **> 500 TABLES**) from Odoo 16 with some mapping: 
-- **Id** fields were converted from **int** to **UUID** (Almost.)
-- **ResCompany** was mapped as **Tenant**, **ResUser** was mapped to **IdentityUser**
- Use same model objects for entities and dtos. **All models** were placed in folder **Bamboo.Core.Domain.Shared/Models**
- **Full CRUD** for every models.
- **Add AppContracts / AppServices / AppControllers / AppClientProxies for every models.**

# How to run
1. Open Bamboo.Admin.sln then build and run **Bamboo.Admin.HttpApi.Host** for login / account management
2. Open Bamboo.Core.sln then build and run **Bamboo.Core.HttpApi.Host** for CRUD services
3. Open Bamboo.Web.MVC.sln for UI

# TODO
- **Bussiness Logic**. I'm not Odoo expert. Please contact me at https://wepi.social/u/wepi if you can help.
- **Localization**
- **Web UI App** (MVC or Blazor / Angular)
- **Mobile App**

# Other
I can move Odoo 16 data to BambooERP database. If you want, feel **free** to contact me.

---
## Base Modules
 -  Base
## CRM Modules
 - Crm
## Sales Modules
 - Sales
 - POS
 - Contracts
## Stock Modules
 - Inventory
 - Purchase 
 - Repairs
 - Barcode
## Account Modules
 - Invoices
 - Payments
## HR Modules
 - Employees
 - Attendances
 - Fleet
## MRP Modules
 - Mrp
 - Maintenance