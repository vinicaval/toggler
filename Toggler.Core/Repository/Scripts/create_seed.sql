
Create Table [dbo].[Application](
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	[Name] VARCHAR(100) NOT NULL,
	[Url] VARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Feature](
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	[Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(200) NOT NULL
)

CREATE TABLE [dbo].[ApplicationFeature](
	[IdApplication] UNIQUEIDENTIFIER NOT NULL,
	[IdFeature] UNIQUEIDENTIFIER NOT NULL,
	[Active] BIT NOT NULL
	FOREIGN KEY(IdApplication) REFERENCES [Application](Id),
	FOREIGN KEY(IdFeature) REFERENCES [Feature](Id)
)


Insert into Application(Name,Url) Values
('test1','www.test1.com'),
('test2','www.test2.com')

Insert into Feature(Name, Description) values
('isButtonBlue', 'change color of the button'),
('isBackgroundAnimated', 'set default animation for background')

