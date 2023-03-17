-- 1679088541-LoadTables.sql

-- Autor: Héctor Trujillo Méndez
-- Objetivo: Carga de datos en tablas existentes de Base de Datos.
-- Fecha 2023-03-17.
-- Comentarios: Aquí se crean los objetos de Base de Datos (Tablas, vistas, SP, etc) asignados a un esquema de Base de Datos o bien asignados al esquema por default de Base de Datos.

-- 1. Catálogo de cuentas de usuario.
-------------------------------------
INSERT INTO [dbo].[mtUsers] ([first_name], [last_name], [username], [passwordhash], [createdate], [updatedate])
VALUES ('ADMINISTRADOR', 'DEL SISTEMA', 'root', 'root', GETUTCDATE(), null),
	   ('INVITADO', 'DEL SISTEMA', 'userguest', 'userguest', GETUTCDATE(), null);

-- 2. Catálogo de tipos de productos.
-------------------------------------
INSERT INTO [dbo].[mtProductTypes] ([description], [account_id], [creationdate], [updatedate])
VALUES ('BOTANAS', 1, GETUTCDATE(), null),
	   ('BEBIDAS NO ALCOHOLICAS', 1, GETUTCDATE(), null),
	   ('BEBIDAS ALCOHOLICAS', 1, GETUTCDATE(), null);

-- 3. Catálogo de tiendas.
-------------------------------------
INSERT INTO [dbo].[mtStores] ([name], [address], [account_id], [creationdate], [updatedate])
VALUES ('Sucursal CDMX', 'Av. Siempreviva 101.', 1, GETUTCDATE(), null),
	   ('Sucursal Guadalajara', 'Av. Siempreviva 102.', 1, GETUTCDATE(), null),
	   ('Sucursal Monterrey', 'Av. Siempreviva 103.', 1, GETUTCDATE(), null);

-- 4. Catálogo de artículos.
-------------------------------------
INSERT INTO [dbo].[mtArticles] ([name], [description], [price], [total_in_shelf], [total_in_vault], [producttype_id], [store_id], [account_id], [creationdate], [updatedate])
VALUES ('Bolsa de churros Neto','Bolsa de churros 100 grs', 25.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Paquetaxo Morado Grande','Paquetaxo picoso ultrahot', 45.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Paquetaxo Azul Grande','Paquetaxo sabor queso', 45.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
       ('Paquetaxo Amarillo Grande','Paquetaxo botanero normal', 45.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
       ('Paquetaxo Verde Grande','Paquetaxo botanero extremo', 45.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Cerveza Corona Chica','Cerveza 350 ml', 22.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Cerveza Indio Chica','Cerveza 350 ml', 22.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Cerveza Victoria Chica','Cerveza 350 ml', 22.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Cerveza Derrota Chica','Cerveza 350 ml', 22.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Cerveza Corona Grande','Cerveza 350 ml', 22.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null),
	   ('Coca Cola Grande','Coca Cola Sabor Original 3 L', 45.50, 1000, 5000, 1, 1, 1, GETUTCDATE(), null);

-- 1679088541-LoadTables.sql