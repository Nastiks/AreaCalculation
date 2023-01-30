CREATE DATABASE store;

CREATE TABLE products (
	id int IDENTITY NOT NULL,
	name nvarchar(MAX) NOT NULL
);

CREATE TABLE categories (
	id int IDENTITY NOT NULL,
	name nvarchar(MAX) NOT NULL
);

CREATE TABLE products_categories (
	product_id int NOT NULL,
	category_id int NOT NULL,
);

INSERT INTO products (name) VALUES ('Samsung Galaxy A53');
INSERT INTO products (name) VALUES ('Shopper bag Nike');
INSERT INTO products (name) VALUES ('Zhiguli');
INSERT INTO products (name) VALUES ('Tomato');

INSERT INTO categories (name) VALUES ('Smartphones');
INSERT INTO categories (name) VALUES ('Accessories');
INSERT INTO categories (name) VALUES ('Vegetables');

INSERT INTO products_categories (product_id, category_id) VALUES (1, 1);
INSERT INTO products_categories (product_id, category_id) VALUES (2, 2);
INSERT INTO products_categories (product_id, category_id) VALUES (4, 3);

select p.name, c.name 
from products p
LEFT JOIN products_categories pc 
ON p.id = pc.product_id
LEFT JOIN categories c 
ON pc.category_id = c.id;