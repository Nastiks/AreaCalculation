IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'store')
BEGIN
    CREATE DATABASE store
END

USE store;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'products_categories')  
	ALTER TABLE [dbo].[products_categories]
	DROP CONSTRAINT [FK_products_categories_to_categories]
	ALTER TABLE [dbo].[products_categories]
	DROP CONSTRAINT [FK_products_categories_to_products]
	DROP TABLE products_categories;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'products')
	DROP TABLE products;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'categories')
	DROP TABLE categories;
GO

CREATE TABLE products (
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)
);

CREATE TABLE categories (
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_categories]
	PRIMARY KEY CLUSTERED ( [id] ASC )
);

CREATE TABLE products_categories (
	[product_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	CONSTRAINT [FK_products_categories_to_categories] 
	FOREIGN KEY([category_id])
	REFERENCES [dbo].[categories] ([id]),
	CONSTRAINT [FK_products_categories_to_products]
	FOREIGN KEY([product_id])
	REFERENCES [dbo].[products] ([id])
);


INSERT INTO products (name) VALUES ('Samsung Galaxy A53');
INSERT INTO products (name) VALUES ('Shopper bag Nike');
INSERT INTO products (name) VALUES ('Zhiguli');
INSERT INTO products (name) VALUES ('Tomato');

INSERT INTO categories (name) VALUES ('Smartphones');
INSERT INTO categories (name) VALUES ('Accessories');
INSERT INTO categories (name) VALUES ('Vegetables');

INSERT INTO products_categories (product_id, category_id) VALUES (1, 1);
INSERT INTO products_categories (product_id, category_id) VALUES (1, 2);
INSERT INTO products_categories (product_id, category_id) VALUES (2, 2);
INSERT INTO products_categories (product_id, category_id) VALUES (4, 3);

select p.name, c.name 
from products p
LEFT JOIN products_categories pc 
ON p.id = pc.product_id
LEFT JOIN categories c 
ON pc.category_id = c.id;