------insert default data

----PAYSMART administrator: Responsible for managing PAYSMART application, 
----users, Fleet companies, groups, rights and roles, policy and backups, 
----updates, 
Set IDENTITY_INSERT  [dbo].[Roles] ON
Go


INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(1, 'PAYSMART administrator','Responsible for managing PAYSMART application,users, Fleet companies, groups, rights and roles, policy and backups,updates',1,0)

INSERT INTO [dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (1,1,1)

--PAYSMART Finance Administrator: Responsible for the billing function of 
--Access Fees, Support fees, License fees, Annual fees, Registration fees,
--Purchase of BT POS, etc.,

INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(2, 'PAYSMART Finance Administrator','Responsible for the billing function of Access Fees, Support fees, License fees, Annual fees, Registration fees, Purchase of BT POS, etc.,',1,0)

INSERT INTO [dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (1,2,1)

--Technical Support Engineer: Does not configure PAYSMART server but 
--troubleshoots and configures BT POS for clients. Also can blacklist and 
--activate BT POS devices 
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(3,'PAYSMART Technical Support Engineer','Does not configure PAYSMART server but troubleshoots and configures BT POS for clients. Also can blacklist and activate BT POS devices ',1,0)

INSERT INTO [dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (1,3,1)

--Helpdesk and Support Technician: Takes customer complaints and logs into
--system as Trouble Tickets for Technical support engineer to fix 
--problems. 
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(4,'PAYSMART Helpdesk and Support Technician','Takes customer complaints and logs into system as Trouble Tickets for Technical support engineer to fix problems.',1,0)

INSERT INTO [dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (1,4,1)

--Sales Consultant: Also has access to Billing module to affect payments 
--and receipting for fees and purchases of BT POS.
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(5,'PAYSMART Sales Consultant','Also has access to Billing module to affect payments and receipting for fees and purchases of BT POS.',1,0)

INSERT INTO [dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (1,5,1)


INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(11,'PAYSMART Guest','User will be able to view the details and cannot modify in the application',1,0)

INSERT INTO [dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (1,11,1)

--Fleet owner: PAYSMART client who registers with PAYSMART and who 
--procures BT POS terminals and manages fleet.
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(6,'Fleet Owner','PAYSMART client who registers with PAYSMART and who procures BT POS terminals and manages fleet.',1,1)

--Supervisor: Configured by fleet owner. Manages and operates BT POS 
--terminals. He should be trained on the BT POS usage and features.
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(7,'Supervisor','Configured by fleet owner. Manages and operates BT POS terminals. He should be trained on the BT POS usage and features.',1,1)

--Manager: Configured by fleet owner. Manages and operates BT POS 
--terminals. He should be trained on the BT POS usage and features.
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(8,'Manager','Configured by fleet owner. Manages and operates BT POS terminals. He should be trained on the BT POS usage and features.',1,1)

--Fleet Conductor: Configured by fleet owner. Operates individual assigned
--BT POS terminals in registered Bus to sale tickets to passengers. Cannot
--configure BTPOS or change Settings, cannot authorize refunds, cash outs 
--or transfers.
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(9,'Fleet Conductor',' Configured by fleet owner. Operates individual assigned BT POS terminals in registered Bus to sale tickets to passengers. Cannot configure BTPOS or change Settings, cannot authorize refunds, cash outs or transfers.',1,1)

--Fleet Ticket Salesperson Front Office: Configured by fleet owner for 
--Commercial website system login for his fleet. Manages passenger’s 
--complaints operates BT POS terminals and Commercial website system to 
--mainly do front office tickets sale online at bus station or office 
--outlet, customer queries and routes updates in system, sale online 
--tickets, resolve offers, vouchers, discounts, tariffs, routes 
--availability, fleet time table queries, etc.
INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(10,'Fleet Ticket Salesperson Front Office','Configured by fleet owner for Commercial website system login for his fleet. Manages passenger’s complaints operates BT POS terminals and Commercial website system to mainly do front office tickets sale online at bus station or office outlet, customer queries and routes updates in system, sale online tickets, resolve offers, vouchers, discounts, tariffs, routes availability, fleet time table queries, etc.',1,1)
   

INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(12,'Guest User','User will be able to view the details and cannot modify in the application',1,1)

INSERT INTO [dbo].[Roles]([Id],[Name],[Description],[Active],[IsPublic])
VALUES(13,'Fleet Driver','The driver for a vehicle.',1,1)

Set IDENTITY_INSERT  [dbo].[Roles] OFF


INSERT INTO [dbo].[UserRoles]
           ([UserId]
           ,[RoleId]
           ,[CompanyId])
     VALUES
           (1,1,1)

GO