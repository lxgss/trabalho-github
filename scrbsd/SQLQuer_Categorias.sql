USE AimLabsDB;
GO

-- =============================================================================
-- 1. GARANTIR QUE AS CATEGORIAS EXISTEM
-- =============================================================================
SET IDENTITY_INSERT dbo.Categories ON;

IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE ID_Cat = 1)
    INSERT INTO dbo.Categories (ID_Cat, Nome_Categoria) VALUES (1, 'Precisão');

IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE ID_Cat = 2)
    INSERT INTO dbo.Categories (ID_Cat, Nome_Categoria) VALUES (2, 'Tracking');

SET IDENTITY_INSERT dbo.Categories OFF;
GO


-- =============================================================================
-- 2. INSERÇÃO DOS EXERCÍCIOS (Incluindo o StrafeTrack na Categoria 2)
-- =============================================================================
SET IDENTITY_INSERT dbo.Exercicios ON;

-- ID 1 a 3: Modos de Precisão (Categoria 1)
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 1)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) VALUES (1, 1, 'GridShot', 60, 'Média');

IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 2)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) VALUES (2, 1, 'SixShot', 60, 'Difícil');

IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 3)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) VALUES (3, 1, 'ModoTres', 60, 'Média');

-- ID 4: SpiderShot (Categoria 1 - O que estamos a testar agora no C#)
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 4)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) VALUES (4, 1, 'SpiderShot', 60, 'Média');

-- ID 5: StrafeTrack (Associado à categoria 2: Tracking!)
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 5)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) VALUES (5, 2, 'StrafeTrack', 60, 'Média');

SET IDENTITY_INSERT dbo.Exercicios OFF;
GO


-- =============================================================================
-- 3. VERIFICAÇÃO DOS DADOS
-- =============================================================================
SELECT * FROM dbo.Categories;
SELECT * FROM dbo.Exercicios;