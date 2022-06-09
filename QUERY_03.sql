
WITH Q AS(
SELECT 		
	C.Nome,
	P.DataVencimento,
	P.DataPagamento,
	DATEDIFF(day, P.DataVencimento, P.DataPagamento) AS Dias
FROM 
	Cliente	C
INNER JOIN
	Financiamento	F	ON	F.IdCliente	=	C.IdCliente
INNER JOIN
	Parcela	P	ON	P.IdFinanciamento	=	F.IdFinanciamento
WHERE
	F.ValorTotal > 10000.00
	AND DataPagamento IS NOT NULL
), Q2 AS (
SELECT 
	Nome,
	COUNT(*) As Qtd
FROM 
	Q 
WHERE Dias > 10
GROUP BY
	Nome
)

SELECT * FROM Q2 WHERE Qtd >= 2
	


	