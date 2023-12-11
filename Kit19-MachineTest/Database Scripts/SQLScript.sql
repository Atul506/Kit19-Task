Create database ProductsDB
GO
USE ProductsDB
GO
CREATE TABLE Product (
    ProductId INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(255),
    Size NVARCHAR(50),
    Price DECIMAL(18, 2),
    MfgDate DATE,
    Category NVARCHAR(50)
);
GO
insert into Product values('Red T-Shirt', 'L', 100, GETDATE(), 'Standard');
insert into Product values('Jeans', 'M', 500, '2013-12-07', 'Standard');
insert into Product values('Pant', 'S', 275, '2012-11-07', 'Standard');
insert into Product values('Shoes', 'L', 299, GETDATE(), 'Premium');
insert into Product values('Skirt', 'M', 500, '2018-10-17', 'Economy');
insert into Product values('Short', 'S', 275, '2020-11-23', 'Premium');
GO
CREATE PROCEDURE usp_SearchProducts
    @ProductName NVARCHAR(255) = NULL,
    @Size NVARCHAR(50) = NULL,
    @Price DECIMAL(18, 2) = NULL,
    @MfgDate DATE = NULL,
    @Category NVARCHAR(50) = NULL,
	@SearchChoice varchar(3) = NULL
AS
BEGIN

	IF (@ProductName is NULL and @Size is NULL and @Price is NULL and @MfgDate is NULL and @Category is NULL and 
	@SearchChoice is NULL)
	BEGIN
		SELECT ProductId, ProductName, Size, Price, MfgDate, Category
		FROM Product
	END
	ELSE IF @SearchChoice is null or @SearchChoice = 'OR'
	BEGIN
	SELECT ProductId, ProductName, Size, Price, MfgDate, Category
		FROM Product
		WHERE
			(ProductName LIKE '%' + @ProductName + '%')
			OR (Size = @Size)
			OR (Price = @Price)
			OR (MfgDate = @MfgDate)
			OR (Category = @Category)
	END
	ELSE
	BEGIN
		SELECT ProductId, ProductName, Size, Price, MfgDate, Category
		FROM Product
		WHERE
			(@ProductName is null or ProductName LIKE '%' + @ProductName + '%')
			AND (@Size is null or Size = @Size)
			AND (@Price is null or Price = @Price)
			AND (@MfgDate is null or MfgDate = @MfgDate)
			AND (@Category is null or Category = @Category)
	END
END;