/*Create News table*/
if not exists (select * from sysobjects where name='News' and xtype='U')
    CREATE TABLE News (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(255) NOT NULL,
    DateOfPost DateTime NOT NULL,
    ShortDescription nvarchar(255) NOT NULL,
	LongDescription nvarchar(MAX) NOT NULL,
	Photo nvarchar(MAX) NOT NULL
);
go