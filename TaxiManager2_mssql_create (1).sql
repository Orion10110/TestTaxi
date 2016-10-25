CREATE TABLE [street] (
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(128) NOT NULL,
	id_district integer NOT NULL,
  

)
GO
CREATE TABLE [district] (
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(128) NOT NULL,
  

)
GO
CREATE TABLE [client] (
	id int IDENTITY(1,1) PRIMARY KEY,
	first_name varchar(128) NOT NULL,
	second_name varchar(128) NOT NULL,
	 patronymic varchar(128) NOT NULL,
	phone_number varchar(128) NOT NULL,
	id_discount integer NOT NULL,
 
)
GO
CREATE TABLE [driver] (
	id int IDENTITY(1,1) PRIMARY KEY,
	first_name varchar(128) NOT NULL,
	second_name varchar(128) NOT NULL,
	 patronymic varchar(128) NOT NULL,
	phone_number varchar(128) NOT NULL,
	date_of_birth date NOT NULL,
	date_of_employment date NOT NULL,
	category integer NOT NULL,
	id_district integer NOT NULL,
	id_car integer NOT NULL,
 

)
GO
CREATE TABLE [status] (
	id int IDENTITY(1,1) PRIMARY KEY,
	status varchar(64) NOT NULL,


)
GO
CREATE TABLE [order] (
	id int IDENTITY(1,1) PRIMARY KEY,
	phone_number varchar(64) NOT NULL,
	id_client integer NOT NULL,
	id_status integer NOT NULL,
	date_order varchar(64) NOT NULL,
	start_value integer NOT NULL,
	end_value integer NOT NULL,
	id_application_user integer NOT NULL,
	id_street_from integer NOT NULL,
	id_street_to integer NOT NULL,
	id_driver integer NOT NULL,


)
GO
CREATE TABLE [discount] (
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(64) NOT NULL,
	discount_percent integer NOT NULL,
 

)
GO
CREATE TABLE [car] (
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(128) NOT NULL,
	id_brand integer NOT NULL,
	id_type integer NOT NULL,
	place integer NOT NULL,
	gos_number varchar(128) NOT NULL,
	stars integer NOT NULL,
	active binary NOT NULL,


)
GO
CREATE TABLE [application_user] (
	id int IDENTITY(1,1) PRIMARY KEY,
	email varchar(256) NOT NULL,
	email_confirmed binary NOT NULL,
	password_hash varchar NOT NULL,
	phone_number varchar NOT NULL,
	phone_number_confirmed binary NOT NULL,
	user_name varchar NOT NULL,
 

)
GO
CREATE TABLE [brand] (
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(128) NOT NULL,
  

)
GO
CREATE TABLE [type_car] (
	id int IDENTITY(1,1) PRIMARY KEY,
	type varchar(128) NOT NULL,
 

)
GO
ALTER TABLE [street] WITH CHECK ADD CONSTRAINT [street_fk0] FOREIGN KEY ([id_district]) REFERENCES [district]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [street] CHECK CONSTRAINT [street_fk0]
GO


ALTER TABLE [client] WITH CHECK ADD CONSTRAINT [client_fk0] FOREIGN KEY ([id_discount]) REFERENCES [discount]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [client] CHECK CONSTRAINT [client_fk0]
GO

ALTER TABLE [driver] WITH CHECK ADD CONSTRAINT [driver_fk0] FOREIGN KEY ([id_district]) REFERENCES [district]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [driver] CHECK CONSTRAINT [driver_fk0]
GO
ALTER TABLE [driver] WITH CHECK ADD CONSTRAINT [driver_fk1] FOREIGN KEY ([id_car]) REFERENCES [car]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [driver] CHECK CONSTRAINT [driver_fk1]
GO


ALTER TABLE [order] WITH CHECK ADD CONSTRAINT [order_fk0] FOREIGN KEY ([id_client]) REFERENCES [client]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [order] CHECK CONSTRAINT [order_fk0]
GO
ALTER TABLE [order] WITH CHECK ADD CONSTRAINT [order_fk1] FOREIGN KEY ([id_status]) REFERENCES [status]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [order] CHECK CONSTRAINT [order_fk1]
GO
ALTER TABLE [order] WITH CHECK ADD CONSTRAINT [order_fk2] FOREIGN KEY ([id_application_user]) REFERENCES [application_user]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [order] CHECK CONSTRAINT [order_fk2]
GO
ALTER TABLE [order] WITH CHECK ADD CONSTRAINT [order_fk3] FOREIGN KEY ([id_street_from]) REFERENCES [street]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [order] CHECK CONSTRAINT [order_fk3]
GO
ALTER TABLE [order] WITH CHECK ADD CONSTRAINT [order_fk4] FOREIGN KEY ([id_street_to]) REFERENCES [street]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [order] CHECK CONSTRAINT [order_fk4]
GO
ALTER TABLE [order] WITH CHECK ADD CONSTRAINT [order_fk5] FOREIGN KEY ([id_driver]) REFERENCES [driver]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [order] CHECK CONSTRAINT [order_fk5]
GO


ALTER TABLE [car] WITH CHECK ADD CONSTRAINT [car_fk0] FOREIGN KEY ([id_brand]) REFERENCES [brand]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [car] CHECK CONSTRAINT [car_fk0]
GO
ALTER TABLE [car] WITH CHECK ADD CONSTRAINT [car_fk1] FOREIGN KEY ([id_type]) REFERENCES [type_car]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [car] CHECK CONSTRAINT [car_fk1]
GO




