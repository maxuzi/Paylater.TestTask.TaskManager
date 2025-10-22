
CREATE VIEW UserTasksV
AS
SELECT 
    t.UserId
   ,t.Title
   ,t.Description
   ,t.DateId                        AS CreatedAt 
   ,JSON_VALUE(h.value, '$.DateId') AS UpdatedAt
   ,JSON_VALUE(h.value, '$.Status') AS Status
  FROM UserTasks t
 CROSS APPLY  OPENJSON(t.History) h
 WHERE  JSON_VALUE(h.value, '$.DateId') = ( SELECT MAX(JSON_VALUE(h2.value, '$.DateId'))
                                              FROM OPENJSON(t.History) h2
                                          );



