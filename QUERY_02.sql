WITH Q AS (
SELECT 	
	DISTINCT
	C.Nome
FROM 
	Cliente	C
INNER JOIN
	Financiamento	F	ON	F.IdCliente	=	C.IdCliente
INNER JOIN
	Parcela	P	ON	P.IdFinanciamento	=	F.IdFinanciamento
WHERE
	DataPagamento IS NULL AND DATEDIFF(day, P.DataVencimento, GETDATE()) > 5
) 
SELECT 	
	TOP 4
	Nome
	
FROM 
	Q

	