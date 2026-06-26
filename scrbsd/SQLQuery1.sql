USE AimLabsDB;
GO

-- =============================================================================
-- 1. INSERÇÃO/GARANTIA DAS CATEGORIAS (Precisão e Tracking)
-- =============================================================================
-- Ativamos a inserção manual de IDs temporariamente para fixar Precisão=1 e Tracking=2
SET IDENTITY_INSERT dbo.Categories ON;

IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE ID_Cat = 1)
    INSERT INTO dbo.Categories (ID_Cat, Nome_Categoria) VALUES (1, 'Precisão');

IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE ID_Cat = 2)
    INSERT INTO dbo.Categories (ID_Cat, Nome_Categoria) VALUES (2, 'Tracking');

SET IDENTITY_INSERT dbo.Categories OFF;
GO


-- =============================================================================
-- 2. INSERÇÃO DOS EXERCÍCIOS (SpiderShot mapeado oficialmente como ID 4)
-- =============================================================================
-- Ativamos a inserção manual de IDs na tabela Exercicios
SET IDENTITY_INSERT dbo.Exercicios ON;

-- ID 1: GridShot (Categoria: Precisão)
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 1)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) 
    VALUES (1, 1, 'GridShot', 60, 'Média');

-- ID 2: SixShot (Categoria: Precisão)
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 2)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) 
    VALUES (2, 1, 'SixShot', 60, 'Difícil');

-- ID 3: Outro modo de precisão que tenhas no teu menu (ex: MicroShot)
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 3)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) 
    VALUES (3, 1, 'ModoTres', 60, 'Média');

-- ID 4: SpiderShot (Categoria: Precisão) -> Mapeado exatamente como o teu 4º exercício!
IF NOT EXISTS (SELECT 1 FROM dbo.Exercicios WHERE ID_Ex = 4)
    INSERT INTO dbo.Exercicios (ID_Ex, ID_Cat, Nome, Tempo, Dificuldade) 
    VALUES (4, 1, 'SpiderShot', 60, 'Média');

SET IDENTITY_INSERT dbo.Exercicios OFF;
GO


-- =============================================================================
-- 3. VERIFICAÇÃO DOS DADOS NO BANCO
-- =============================================================================
SELECT * FROM dbo.Categories;
SELECT * FROM dbo.Exercicios;