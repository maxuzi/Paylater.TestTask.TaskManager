
CREATE PROCEDURE Publish_UserTasksQuery_UserService_GetUserName( @Message VARCHAR(MAX) )
AS
  DECLARE @ConversationHandle UNIQUEIDENTIFIER

    BEGIN DIALOG CONVERSATION @ConversationHandle
     FROM SERVICE  Q_SERVICE_SRC_UserTasksQuery_UserService_GetUserName
       TO SERVICE 'Q_SERVICE_DST_UserTasksQuery_UserService_GetUserName'
       ON CONTRACT Q_CONTRACT_UserTasksQuery_UserService
     WITH ENCRYPTION = OFF;

    SEND ON CONVERSATION @ConversationHandle
    MESSAGE TYPE Q_MESSAGE_PaylaterTYPE( @Message )
go

-- exec dbo.Publish_UserTasksQuery_UserService_GetUserName 'YYY'


CREATE OR ALTER PROCEDURE Consume_UserTasksQuery_UserService_GetUserName @MessageOUT varchar(1000) OUT 
AS
declare @ConversationHandle UNIQUEIDENTIFIER
declare @MessageBody varchar(100)

    WAITFOR(
    RECEIVE top(1) 
	         @ConversationHandle = conversation_handle
	    	,@MessageBody = cast( message_body as varchar(1000)) 
  	   FROM Q_DST_UserTasksQuery_UserService_GetUserName  )
   ,TIMEOUT 50000;

    IF @ConversationHandle IS NOT NULL
    BEGIN
        END CONVERSATION @ConversationHandle;
        SET @MessageOUT = @MessageBody;
    END
    ELSE
    BEGIN
        SET @MessageOUT = 'XXX';
    END
go
   

--======================================================

--  declare @MessageOUT varchar(1000) EXEC Consume_UserTasksQuery_UserService_GetUserName @MessageOUT OUT; select  @MessageOUT
--       select * from sys.conversation_endpoints order by 7 desc



CREATE OR ALTER PROCEDURE Publish_UserService_UserTasksQuery_GetName( @Message VARCHAR(1000) )
AS
  DECLARE @ConversationHandle UNIQUEIDENTIFIER

    BEGIN DIALOG CONVERSATION @ConversationHandle
     FROM SERVICE  Q_SERVICE_SRC_UserService_UserTasksQuery_GetName
       TO SERVICE 'Q_SERVICE_DST_UserService_UserTasksQuery_GetName'
       ON CONTRACT Q_CONTRACT_UserService_UserTasksQuery
     WITH ENCRYPTION = OFF;

    SEND ON CONVERSATION @ConversationHandle
    MESSAGE TYPE Q_MESSAGE_PaylaterTYPE( @Message )
go

-- exec dbo.Publish_UserTasksQuery_UserService_GetUserName 'YYY'


CREATE OR ALTER PROCEDURE Consume_UserService_UserTasksQuery_GetName @MessageOUT varchar(1000) OUT
AS
declare @ConversationHandle UNIQUEIDENTIFIER
declare @MessageBody varchar(1000)

    WAITFOR(
    RECEIVE top(1) 
	         @ConversationHandle = conversation_handle
	    	,@MessageBody = cast( message_body as varchar(1000)) 
  	   FROM Q_DST_UserService_UserTasksQuery_GetName  )
   ,TIMEOUT 50000;

    IF @ConversationHandle IS NOT NULL
    BEGIN
        END CONVERSATION @ConversationHandle;
        SET @MessageOUT = @MessageBody;
    END
    ELSE
    BEGIN
        SET @MessageOUT = 'XXX';
    END
go


   