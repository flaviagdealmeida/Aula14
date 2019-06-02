CREATE TABLE [dbo].[Aluno] (
    [IdAluno]        INT            IDENTITY (1, 1) NOT NULL,
    [Nome]           NVARCHAR (150) NOT NULL,
    [Matricula]      NVARCHAR (50)  NOT NULL,
    [Sexo]           CHAR (1)       NOT NULL,
    [DataNascimento] DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAluno] ASC),
    UNIQUE NONCLUSTERED ([Matricula] ASC)
);

CREATE TABLE [dbo].[Professor] (
    [IdProfessor] INT            IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (150) NOT NULL,
    [Email]       NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdProfessor] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[Turma] (
    [IdTurma]     INT            IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (150) NOT NULL,
    [DataInicio]  DATE           NOT NULL,
    [IdProfessor] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTurma] ASC),
    FOREIGN KEY ([IdProfessor]) REFERENCES [dbo].[Professor] ([IdProfessor])
);

CREATE TABLE [dbo].[TurmaAluno] (
    [IdTurma] INT NOT NULL,
    [IdAluno] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTurma] ASC, [IdAluno] ASC),
    FOREIGN KEY ([IdTurma]) REFERENCES [dbo].[Turma] ([IdTurma]),
    FOREIGN KEY ([IdAluno]) REFERENCES [dbo].[Aluno] ([IdAluno])
);




