use Dummy 
Go

select * from employee;

Drop table employee

Create table Employee
(
  id int identity Primary Key,
  Name varchar(Max),
  Weight int 
)

Insert into Employee Values('John',60),('Cena',80),('Kohli',70),('Dhoni',60),('Dinesh',70),('Rohith',80);

Select * from Employee

Alter database Dummy
add FileGroup Weight_60
Go

Alter database Dummy
add FileGroup Weight_70
Go

Alter database Dummy
add FileGroup Weight_80
Go

Alter database Dummy
add File
(
  name=Part_Weight_60,
  FileName='C:\Users\rajes\OneDrive\Desktop\NDf Files\Part_Weight_60',
  Size=1024 KB,
  MaxSize=Unlimited,
  FileGrowth=200KB
)
To FileGroup Weight_60

Alter database Dummy
add File
(
  name=Part_Weight_70,
  FileName='C:\Users\rajes\OneDrive\Desktop\NDf Files\Part_Weight_70',
  Size=1024 KB,
  MaxSize=Unlimited,
  FileGrowth=200KB
)
To FileGroup Weight_70

Alter database Dummy
add File
(
  name=Part_Weight_80,
  FileName='C:\Users\rajes\OneDrive\Desktop\NDf Files\Part_Weight_80',
  Size=1024 KB,
  MaxSize=Unlimited,
  FileGrowth=200KB
)
To FileGroup Weight_80


create Partition Function Pt_Weightwise_fun (int)
as range left for values
(60,70)

select * from sys.filegroups

Create Partition Scheme Pt_weightwise_Sch
as 
Partition Pt_Weightwise_fun
To
(Weight_60,weight_70,weight_80)

select * from employee

create table Pt_Employee
(
 id int,
 Name varchar(Max),
 Weight int
)On Pt_weightwise_Sch(Weight)

Insert into Pt_Employee(id,Name,Weight)(select * from Employee)

Select * from Pt_Employee

select $Partition.Pt_weightwise_fun(Weight) as PartitionNumber ,*
from  Pt_Employee

SELECT part.partition_number AS [Partition Number],
		fle.name AS [Partition Name],
		part.rows AS [Number of Rows]
FROM sys.partitions AS part
JOIN SYS.destination_data_spaces AS dest ON
part.partition_number = dest.destination_id
JOIN sys.filegroups AS fle ON
dest.data_space_id = fle.data_space_id
WHERE OBJECT_NAME(OBJECT_ID) = 'Pt_Employee'

select * from sys.filegroups

