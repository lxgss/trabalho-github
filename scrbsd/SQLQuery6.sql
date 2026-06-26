USE AimLabsDB;
GO

-- 1. Utilizadores
CREATE TABLE Users (
    ID_User INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL
);

-- 2. Categorias
CREATE TABLE Categories (
    ID_Cat INT PRIMARY KEY IDENTITY(1,1),
    Nome_Categoria VARCHAR(50) NOT NULL
);

-- 3. Exercícios (Aponta para Categorias)
CREATE TABLE Exercicios (
    ID_Ex INT PRIMARY KEY IDENTITY(1,1),
    ID_Cat INT NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    Tempo INT DEFAULT 60,
    Dificuldade VARCHAR(20),
    CONSTRAINT FK_Exercicio_Categoria FOREIGN KEY (ID_Cat) REFERENCES Categories(ID_Cat)
);

-- 4. Rankings (Aponta para Users e Exercicios)
CREATE TABLE Rankings (
    ID_Rank INT PRIMARY KEY IDENTITY(1,1),
    ID_User INT NOT NULL,
    ID_Ex INT NOT NULL,
    Pontos INT NOT NULL,
    Data_Treino DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Ranking_User FOREIGN KEY (ID_User) REFERENCES Users(ID_User),
    CONSTRAINT FK_Ranking_Exercicio FOREIGN KEY (ID_Ex) REFERENCES Exercicios(ID_Ex)
);
GO