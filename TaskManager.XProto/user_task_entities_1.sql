if object_id('UserTasks') IS NULL
begin
CREATE TABLE UserTasks ( 
   UserId         DATETIME      NOT NULL
  ,DateId         DATETIME      NOT NULL
  ,Title          VARCHAR(100)
  ,Description    VARCHAR(1000)
  ,History        VARCHAR(4000)
)

ALTER TABLE UserTasks ADD CONSTRAINT XPK_UserTasks PRIMARY KEY CLUSTERED ( UserId, DateId ) WITH ( IGNORE_DUP_KEY = ON )

end

go

CREATE OR ALTER PROCEDURE UpdateUserTaskStatus( @UserId DATETIME, @TaskId DATETIME, @HistId DATETIME, @Status VARCHAR(10) )
AS

declare @newHistory VARCHAR(256) = '{"DateId":"' + FORMAT(@HistId, 'yyyy-MM-dd HH:mm:ss.fff') + '","Status":"'+@Status+'"}';

print @newHistory

UPDATE UserTasks 
   SET history = JSON_MODIFY( History, 'append $', JSON_QUERY( @newHistory ))
 WHERE userId = @UserId
   and dateId = @TaskId

go

SELECT 
    t.Title,
    t.Description,
    JSON_VALUE(h.value, '$.DateId') AS DateId,
    JSON_VALUE(h.value, '$.Status') AS Status
  FROM UserTasks t
 CROSS APPLY  OPENJSON(t.History) h
 WHERE  JSON_VALUE(h.value, '$.DateId') = ( SELECT MAX(JSON_VALUE(h2.value, '$.DateId'))
                                              FROM OPENJSON(t.History) h2
                                           );