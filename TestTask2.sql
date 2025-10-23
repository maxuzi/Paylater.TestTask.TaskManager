DECLARE @StartValue datetime = '2025-01-01';
DECLARE @EndValue datetime = '2025-01-15';


;WITH Days AS
(
    SELECT @StartValue AS Day
     UNION ALL
    SELECT day + 1
      FROM Days
     WHERE day < @EndValue
)
,Calendar
(
    SELECT day
      FROM Days
    OPTION (MAXRECURSION 0); -- Интервалы дат могут охватывать несколько лет
) 

select * from clendar
