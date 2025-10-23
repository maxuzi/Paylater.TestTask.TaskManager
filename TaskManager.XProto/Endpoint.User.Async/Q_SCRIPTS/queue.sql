--ALTER DATABASE TEST SET ENABLE_BROKER WITH ROLLBACK AFTER 5 SECONDS
--waitfor(RECEIVE cast(message_body as nvarchar(MAX)) FROM Q_dst_UserTasksQuery_UserService_GetUserName)

CREATE MESSAGE TYPE Q_MESSAGE_PaylaterTYPE VALIDATION = NONE 


CREATE CONTRACT  Q_CONTRACT_UserTasksQuery_UserService ( Q_MESSAGE_PaylaterTYPE SENT BY ANY )
CREATE QUEUE     Q_SRC_UserTasksQuery_UserService_GetUserName
CREATE SERVICE   Q_SERVICE_SRC_UserTasksQuery_UserService_GetUserName ON QUEUE Q_SRC_UserTasksQuery_UserService_GetUserName ( Q_CONTRACT_UserTasksQuery_UserService )
CREATE QUEUE     Q_DST_UserTasksQuery_UserService_GetUserName
CREATE SERVICE   Q_SERVICE_DST_UserTasksQuery_UserService_GetUserName ON QUEUE Q_DST_UserTasksQuery_UserService_GetUserName ( Q_CONTRACT_UserTasksQuery_UserService )
go


CREATE CONTRACT  Q_CONTRACT_UserService_UserTasksQuery ( Q_MESSAGE_PaylaterTYPE SENT BY ANY )
CREATE QUEUE     Q_SRC_UserService_UserTasksQuery_GetName
CREATE SERVICE   Q_SERVICE_SRC_UserService_UserTasksQuery_GetName ON QUEUE Q_SRC_UserService_UserTasksQuery_GetName ( Q_CONTRACT_UserService_UserTasksQuery )
CREATE QUEUE     Q_DST_UserService_UserTasksQuery_GetName
CREATE SERVICE   Q_SERVICE_DST_UserService_UserTasksQuery_GetName ON QUEUE Q_DST_UserService_UserTasksQuery_GetName ( Q_CONTRACT_UserService_UserTasksQuery )
go



