USE AimLabsDB;
GO

-- Atualiza o nome do Exercício 3 para MicroGridShot
UPDATE dbo.Exercicios
SET Nome = 'MicroGridShot'
WHERE ID_Ex = 3;

-- Confirma se a alteração foi feita com sucesso
SELECT * FROM dbo.Exercicios;