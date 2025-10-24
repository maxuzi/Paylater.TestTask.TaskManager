if object_id('UserTM') IS NULL
begin
CREATE TABLE UserTM ( 
   Id      INT             IDENTITY(1,1) NOT NULL
  ,Name    VARCHAR(100)
)

ALTER TABLE UserTM ADD CONSTRAINT XPK_UserTM PRIMARY KEY CLUSTERED ( Id ) WITH ( IGNORE_DUP_KEY = ON )

end


if object_id('UserTasksTM') IS NULL
begin
CREATE TABLE UserTasksTM ( 
   UserId       INT               NOT NULL
  ,Id           INT IDENTITY(1,1) NOT NULL              
  ,Title        VARCHAR(100)
  ,Description  VARCHAR(1000)
  ,Status       VARCHAR(20)
  ,CreatedAt    DATETIME 
  ,UpdatedAt	DATETIME
)

ALTER TABLE UserTasksTM ADD CONSTRAINT XPK_UserTasks PRIMARY KEY CLUSTERED ( UserId, Id )

ALTER TABLE UserTasksTM ADD CONSTRAINT FK_UserTasks_User FOREIGN KEY( UserId ) REFERENCES UserTM ( Id )

end

go

