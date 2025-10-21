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


select * from UserTasks 


Title	Description	 History
'111'	'11111'	'[{"DateId":"2025-10-20 15:00:00.100","Status":"NEW"},{"DateId":"2025-10-20 16:00:00.100","Status":"IN_PROGRESS"},{"DateId":"2025-10-20 17:00:00.100","Status":"COMPLETED"}]'
'222'	'22222'	'[{"DateId":"2025-10-20 15:00:00.100","Status":"NEW"},{"DateId":"2025-10-20 16:00:00.100","Status":"IN_PROGRESS"}]'

SELECT 
    t.Title,
    t.Description,
    t.History,
    JSON_VALUE(h.[value], '$.DateId') AS DateId,
    JSON_VALUE(h.[value], '$.Status') AS Status
FROM 
    UserTasks t
CROSS APPLY 
    OPENJSON(t.History) h
WHERE 
    JSON_VALUE(h.[value], '$.DateId') = ( SELECT MAX(JSON_VALUE(h2.[value], '$.DateId'))
        FROM OPENJSON(t.History) h2
    );





















DECLARE @TheTable table(TheJSON nvarchar(max), Condition int )
DECLARE @mystring nvarchar(100)='{"id": 3, "name": "Three"}'

SELECT TheJSON FROM @TheTable

INSERT INTO @TheTable SELECT '[{"id": 1, "name": "One"}, {"id": 2, "name": "Two"}]', 1

SELECT TheJSON FROM @TheTable

UPDATE @TheTable
SET TheJSON = JSON_MODIFY(TheJSON, 'append $', JSON_QUERY(N'{"id": 3, "name": "Three"}'))
WHERE Condition = 1;

SELECT TheJSON FROM @TheTable

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

begin tran

declare @d datetime = getDate()
exec dbo.UpdateUserTaskStatus '2025-10-17 15:19:49.820','2025-10-20 22:08:17.100', @d, 'IN_PROGRESS'

select history, * from UserTasks

rollback


declare @HistId datetime = getdate()
       ,@Status VARCHAR(10) = 'IN_PROGRESS';

	   
declare @newHistory VARCHAR(256) = '{"DateId":"'+cast( @HistId as varchar(100) )+'","Status":"'+@Status+'"}';








   


























