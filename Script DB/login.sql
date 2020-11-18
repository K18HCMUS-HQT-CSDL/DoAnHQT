USE [HQT_CSDL]
GO
/****** Object:  StoredProcedure [dbo].[login_role]    Script Date: 11/19/2020 12:25:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[login_role]
@username char(20),
@role varchar(20) output
as
begin
set nocount on;
select @role= name from sys.database_principals where principal_id =
( 
select rl.role_principal_id FROM sys.database_principals as pr join 
	sys.database_role_members as rl 
	on rl.member_principal_id=pr.principal_id and (pr.type='R' or pr.type='S') and pr.name=@username
)
--print @role
end
GRANT EXECUTE ON login_role to NguoiThue