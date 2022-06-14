CREATE VIEW [dbo].[V_AppUser]
	AS SELECT u.Id, u.Email, u.FirstName, u.LastName, u.NickName,u.IsActive, r.RoleName AS Role FROM AppUser u 
	JOIN AppRole r ON r.Id = u.RoleId