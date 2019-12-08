if OBJECT_ID('UserTable' , 'U') is not null drop table UserTable;
if OBJECT_ID('OrderTable' , 'U') is not null drop table OrderTable;
if OBJECT_ID('CustomerTable' , 'U') is not null drop table CustomerTable;
if OBJECT_ID('ProductTable' , 'U') is not null drop table ProductTable;
if OBJECT_ID('CategoryTable' , 'U') is not null drop table CategoryTable;



CREATE TABLE UserTable(
U_ID INT PRIMARY KEY,
U_FULLNAME NVARCHAR(30) NOT NULL,
U_EMAIL NVARCHAR(50) NOT NULL,
U_USERNAME NVARCHAR(20) NOT NULL,
U_PASSWORD NVARCHAR(50) NOT NULL,
U_TYPE NVARCHAR(20) NOT NULL);

CREATE TABLE CustomerTable(
CU_ID INT PRIMARY KEY,
CU_NAME NVARCHAR(30) NOT NULL,
CU_EMAIL NVARCHAR(50)NOT NULL,
CU_CONTACT NVARCHAR(30) NOT NULL,
CU_ADDRESS NVARCHAR(50) NOT NULL);

CREATE TABLE CategoryTable(
CA_ID INT PRIMARY KEY,
CA_TITLE NVARCHAR(30) NOT NULL,
CA_DESCRIPTION NVARCHAR(100) NOT NULL);

CREATE TABLE ProductTable(
P_ID INT PRIMARY KEY,
P_NAME NVARCHAR(100) NOT NULL,
P_PRICE NVARCHAR(20) NOT NULL,
CATEGORY_ID INT NOT NULL,
FOREIGN KEY (CATEGORY_ID) REFERENCES CategoryTable(CA_ID));

CREATE TABLE OrderTable(
O_ID INT PRIMARY KEY,
O_QUANTITY INT NOT NULL,
CUSTOMER_ID INT NOT NULL,
PRODUCT_ID INT NOT NULL,
FOREIGN KEY (PRODUCT_ID) REFERENCES ProductTable(P_ID),
FOREIGN KEY (CUSTOMER_ID) REFERENCES CustomerTable(CU_ID));


GO 
INSERT INTO UserTable VALUES(1,'Abdulrahman Abdulqawi','abdulrahmanabdulqawi76@gmail.com','abdul76','Passw0rd','Admin');
INSERT INTO UserTable VALUES(2,'Nizar Kamal','Nizar2019@gmail.com','Nizar2019','1123456789','User');

GO
INSERT INTO CustomerTable VALUES(1,'BILL JACK' ,'BJ20@GMAIL.COM' , '+3673459204' , 'BUDAPEST');
INSERT INTO CustomerTable VALUES(2,'HANI SAL' ,'HANI5@GMAIL.COM' , '+3670449702' , 'BUDAPEST');
INSERT INTO CustomerTable VALUES(3,'AHMED NASSIR' ,'AHMED@GMAIL.COM' , '+3673453234' , 'BUDAPEST');

GO
INSERT INTO CategoryTable VALUES(1,'cigarettes' , 'This category contains only the following page.C (Cigarette)');
INSERT INTO CategoryTable VALUES(2,'cigars' , 'This category contains only the following page.C (Cigars)');
INSERT INTO CategoryTable VALUES(3,'tobacco' , 'This category contains only the following page.C (Tobacco)');

GO 
INSERT INTO ProductTable VALUES(1 ,'Davidoff White 200s',50,1);
INSERT INTO ProductTable VALUES(2 ,'Pall Mall Red 200s',41.90,1);
INSERT INTO ProductTable VALUES(3 ,'Marlboro Gold 3.0 100s', 47.5,1);
INSERT INTO ProductTable VALUES(4 ,'Davidoff Mini Cigarillos Escurio 5x20s',71,2);
INSERT INTO ProductTable VALUES(5 ,'Al Capone Filter 5x10s' , 16.30,2);
INSERT INTO ProductTable VALUES(6 ,'Moods Panella 3x4s',20.50,2);

GO
INSERT INTO OrderTable VALUES(1,10,1,1);




