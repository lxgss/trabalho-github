USE AimLabsDB;
GO

-- Apaga a tabela antiga se ela existir para não dar conflito
IF OBJECT_ID('Leaderboard', 'U') IS NOT NULL DROP TABLE Leaderboard;
GO