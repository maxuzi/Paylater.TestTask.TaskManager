
CREATE PROCEDURE Publish_ServiceA_ServiceB_GetB( @Message VARCHAR(MAX) )
AS
  DECLARE @ConversationHandle UNIQUEIDENTIFIER

    BEGIN DIALOG CONVERSATION @ConversationHandle
     FROM SERVICE  Q_SERVICE_SRC_ServiceA_ServiceB_GetB
       TO SERVICE 'Q_SERVICE_DST_ServiceA_ServiceB_GetB'
       ON CONTRACT Q_CONTRACT_ServiceA_ServiceB
     WITH ENCRYPTION = OFF;

    SEND ON CONVERSATION @ConversationHandle
    MESSAGE TYPE Q_MESSAGE_TYPE( @Message )
go

-- exec dbo.Publish_ServiceA_ServiceB_GetB 'YYY'


CREATE OR ALTER PROCEDURE Consume_ServiceA_ServiceB_GetB @MessageOUT varchar(1000) OUT 
AS
declare @ConversationHandle UNIQUEIDENTIFIER
declare @MessageBody varchar(100)

    WAITFOR(
    RECEIVE top(1) 
	         @ConversationHandle = conversation_handle
	    	,@MessageBody = cast( message_body as varchar(1000)) 
  	   FROM Q_DST_ServiceA_ServiceB_GetB  )
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

--  declare @MessageOUT varchar(1000) EXEC Consume_ServiceA_ServiceB_GetB @MessageOUT OUT; select  @MessageOUT
--       select * from sys.conversation_endpoints order by 7 desc



CREATE OR ALTER PROCEDURE Publish_ServiceB_ServiceA_GetA( @Message VARCHAR(1000) )
AS
  DECLARE @ConversationHandle UNIQUEIDENTIFIER

    BEGIN DIALOG CONVERSATION @ConversationHandle
     FROM SERVICE  Q_SERVICE_SRC_ServiceB_ServiceA_GetA
       TO SERVICE 'Q_SERVICE_DST_ServiceB_ServiceA_GetA'
       ON CONTRACT Q_CONTRACT_ServiceB_ServiceA
     WITH ENCRYPTION = OFF;

    SEND ON CONVERSATION @ConversationHandle
    MESSAGE TYPE Q_MESSAGE_TYPE( @Message )
go

-- exec dbo.Publish_ServiceA_ServiceB_GetB 'YYY'


CREATE OR ALTER PROCEDURE Consume_ServiceB_ServiceA_GetA @MessageOUT varchar(1000) OUT
AS
declare @ConversationHandle UNIQUEIDENTIFIER
declare @MessageBody varchar(1000)

    WAITFOR(
    RECEIVE top(1) 
	         @ConversationHandle = conversation_handle
	    	,@MessageBody = cast( message_body as varchar(1000)) 
  	   FROM Q_DST_ServiceB_ServiceA_GetA  )
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


   