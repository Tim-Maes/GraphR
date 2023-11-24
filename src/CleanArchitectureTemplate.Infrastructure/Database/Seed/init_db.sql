CREATE TABLE Category (
    CategoryID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

INSERT INTO Category (CategoryID, Name) VALUES 
(1, 'Bestseller'),
(2, 'Educational'),
(3, 'Cookbook'),
(4, 'Manual');
GO

CREATE TABLE Author (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Biography NVARCHAR(255)
);
GO

INSERT INTO Author (Name, Biography) VALUES
('Author One', 'Biography of Author One'),
('Author Two', 'Biography of Author Two'),
('Author Three', 'Biography of Author Three');
GO

CREATE TABLE Book (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    CategoryID INT NOT NULL,
    AuthorID INT NOT NULL,
    CONSTRAINT FK_Book_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    CONSTRAINT FK_Book_Author FOREIGN KEY (AuthorID) REFERENCES Author(Id)
);
GO

INSERT INTO Book (Title, Description, CategoryID, AuthorID) VALUES
('Book Title One', 'Description of Book One', 1, 1),
('Book Title Two', 'Description of Book Two', 2, 2),
('Book Title Three', 'Description of Book Three', 3, 3);
GO
