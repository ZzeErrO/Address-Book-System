use address_book_system

create table employee_names
(
id int identity(1,1) primary key not null,
firstname varchar(20) not null,
lastname varchar(20) not null,
address varchar(40) not null,
city varchar(20) not null,
state varchar(20) not null,
zip int not null,
phone_number bigint not null,
email varchar(40) not null
)

create table AddressBooks
(
bookid int identity(1,1) primary key not null,
addressBookName varchar(40) not null,
id int not null,
foreign key(id) references employee_names(id)
)

select * from employee_names
select * from addressBooks

insert into employee_names values
(
'Hello','World','Universe','Earth','Milkey Way',000000,0000000000,'helloworld@gmail.com'
)
insert into AddressBooks values
(
'Unknown',1
)