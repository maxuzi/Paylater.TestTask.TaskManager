if object_id('ClientPayments') IS NULL
begin
CREATE TABLE ClientPayments (
 Id       bigint     NOT NULL  -- первичный ключ таблицы
,ClientId bigint     NOT NULL  -- Id клиента
,Dt       datetime             -- дата платежа
,Amount   money                -- сумма платежа
)

-- первичный ключ этой detail таблицы должен быть:
ALTER TABLE ClientPayments ADD CONSTRAINT XPK_ClientPayments PRIMARY KEY CLUSTERED ( ClientId, Id )

insert ClientPayments
select 1,1,'2022-01-03 17:24:00',100  union all
select 2,1,'2022-01-05 17:24:14',200  union all
select 3,1,'2022-01-05 18:23:34',250  union all
select 4,1,'2022-01-07 10:12:38',50	  union all
select 5,2,'2022-01-05 17:24:14',278  union all
select 6,2,'2022-01-10 12:39:29',300 

end


go

CREATE OR ALTER FUNCTION ClientPaymentsByDateSpan( @ClientId BIGINT, @StartValue DATETIME, @EndValue DATETIME )
RETURNS TABLE
AS 
RETURN (

 WITH Calendar AS
(
    SELECT @StartValue AS Day
     UNION ALL
    SELECT day + 1
      FROM Calendar
     WHERE day < @EndValue
)
,ClientPaymentsGrouped AS 
(
    SELECT  CAST( cp.Dt as Date )     AS Dt
    	   ,SUM( cp.Amount )          AS Amount
      FROM  ClientPayments cp
      WHERE cp.ClientId = @ClientId
      GROUP BY CAST( cp.Dt as Date ), ClientId
    )
    
    SELECT c.Day                     AS Dt
          ,isnull( cpg.Amount, 0 )   AS Amount
      FROM Calendar c
     LEFT JOIN ClientPaymentsGrouped cpg ON cpg.Dt = c.day

  -- OPTION (MAXRECURSION 730) -- Интервалы дат могут охватывать несколько лет

)

go

DECLARE @ClientId BIGINT     = 1 
DECLARE @StartValue datetime = '2022-01-02';
DECLARE @EndValue datetime   = '2022-01-07';

select * from dbo.ClientPaymentsByDateSpan( @ClientId, @StartValue, @EndValue )



SET @ClientId   = 2 
SET @StartValue = '2022-01-04';
SET @EndValue   = '2022-01-11';

select * from dbo.ClientPaymentsByDateSpan( @ClientId, @StartValue, @EndValue )