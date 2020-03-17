USE CarServiceDB;

SELECT * FROM 
(
	SELECT M.Second_Name AS 'Фамилия',
	M.First_Name AS 'Имя',
	M.Middle_Name AS 'Отчество',
	 R.Production_Date AS 'Дата поступления',
	 ISNULL(cast(C.Brand as nvarchar(50)), 
		case 
			when GROUPING(M.Second_Name)=0 and GROUPING(M.First_Name)=1 and GROUPING(M.Middle_Name)=1 and GROUPING(R.Production_Date)=1 and GROUPING(C.Brand)=1 then CONCAT(M.Second_Name,'-','Промежуточный итог') 
			when GROUPING(M.Second_Name)=1 and GROUPING(R.Production_Date)=1 and GROUPING(C.Brand)=1 then 'Общий итог'
		end) AS 'Марка',
	 SUM(R.Cost) AS 'Стоимость работ, руб.'
	FROM RepairCars AS R 
	JOIN Masters AS M 
	ON R.Master_Id = M.Id 
	JOIN Cars AS C 
	ON R.Car_Id = C.Id 
	WHERE (R.Production_Date BETWEEN '2020-05-01' AND '2020-05-31') AND (R.Expiration_Date IS NULL) 
	GROUP BY 
	ROLLUP (M.Second_Name, M.First_Name, M.Middle_Name, R.Production_Date, C.Brand)
)T
ORDER BY T.[Стоимость работ, руб.]
