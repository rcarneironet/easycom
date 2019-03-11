CREATE TABLE [dbo].[Student] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [LastName] VARCHAR (50) NOT NULL,
    [Phone]    VARCHAR (15) NOT NULL,
    [Address]  VARCHAR (50) NOT NULL,
    [City]     VARCHAR (50) NOT NULL,
    [State]    VARCHAR (2)  NOT NULL,
    [Country]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([ID] ASC)
);

