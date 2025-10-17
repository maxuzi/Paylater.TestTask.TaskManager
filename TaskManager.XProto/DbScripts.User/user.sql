if object_id('UserTM') IS NULL
begin
CREATE TABLE UserTM ( 
   DateId     DATETIME      NOT NULL
  ,Name       VARCHAR(100)
)

ALTER TABLE UserTM ADD CONSTRAINT XPK_UserTM PRIMARY KEY CLUSTERED ( DateId )

end