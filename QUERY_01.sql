WITH Q AS
(
SELECT 
	DISTINCT
	C.Nome,	
	(SELECT COUNT(*) FROM Parcela PA INNER JOIN  Financiamento FI ON FI.IdFinanciamento = PA.IdFinanciamento WHERE FI.IdFinanciamento = F.IdFinanciamento AND PA.DataPagamento IS NOT NULL) AS Pagas,
	(SELECT COUNT(*) FROM Parcela PA INNER JOIN  Financiamento FI ON FI.IdFinanciamento = PA.IdFinanciamento WHERE FI.IdFinanciamento = F.IdFinanciamento) AS Total

FROM 
	Cliente	C
INNER JOIN
	Financiamento	F	ON	F.IdCliente	=	C.IdCliente
INNER JOIN
	Parcela	P	ON	P.IdFinanciamento	=	F.IdFinanciamento
	where UF = 'SP'
)

SELECT 
	*,
	CONCAT(CAST(CAST(Pagas AS DECIMAL) / CAST(Total AS DECIMAL) * 100 AS INT), '%')  AS 'Percentual'
FROM 
	Q
WHERE CAST(CAST(Pagas AS DECIMAL) / CAST(Total AS DECIMAL) * 100 AS INT) >= 60
	


