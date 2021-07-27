

CREATE VIEW [dbo].[V_ALL_ROLE_PERMISSION]
AS
SELECT R.Name As RoleName, R.Id As RoleId, 
	   F.ID As FunctionId, F.Name As FunctionName, A.ID As ActionId, A.Name As ActionName
FROM AppRoles As R 
LEFT JOIN AppRole_Permission As RP ON R.Id = RP.RoleID
LEFT JOIN AppFunction_Action As FA ON RP.Function_ActionID = FA.ID
LEFT JOIN AppFunctions As F ON FA.FunctionId = F.ID
LEFT JOIN AppActions As A ON FA.ActionId = A.ID
 
 




GO
/****** Object:  View [dbo].[V_ALL_USER_ROLE_PERMISSION]    Script Date: 2020/10/27 14:29:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[V_ALL_USER_ROLE_PERMISSION]
AS
SELECT U.Email, U.Id As UserId, R.Name As RoleName, R.Id As RoleId, 
	   F.ID As FunctionId, F.Name As FunctionName, A.ID As ActionId, A.Name As ActionName
FROM AppUsers AS U
LEFT JOIN AppUserRoles As UR ON U.Id = UR.UserId
LEFT JOIN AppRoles As R ON UR.RoleId = R.Id
LEFT JOIN AppRole_Permission As RP ON R.Id = RP.RoleID
LEFT JOIN AppFunction_Action As FA ON RP.Function_ActionID = FA.ID
LEFT JOIN AppFunctions As F ON FA.FunctionId = F.ID
LEFT JOIN AppActions As A ON FA.ActionId = A.ID
 
 



GO
/****** Object:  View [dbo].[V_LEVEL_PERMISSION]    Script Date: 2020/10/27 14:29:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[V_LEVEL_PERMISSION]
AS
SELECT FA.ID As FunctionActionId, F.ID As FunctionId, F.Name As FunctionName, A.ID As ActionId, A.Name As ActionName 
From AppFunctions AS F
INNER JOIN AppFunction_Action As FA ON F.ID = FA.FunctionId
INNER JOIN AppActions As A ON FA.ActionId = A.ID

