use Address_Book_System

insert into employee_names values
(
'ABC','XYZ','ALPHABET','STARTEND','CHARACTER',1226,123262524,'alphabate@yahoo.com','2020-09-09'
)

insert into AddressBooks values
(
'Address2','3'
)

create proc UpdateContactInformation
@id int,
@firstname varchar(20),
@lastname varchar(20),
@address varchar(40),
@city varchar(20),
@state varchar(20),
@zip int,
@phonenumber bigint,
@email varchar(40),
@addressbookname varchar(40)
as
begin
update employee_names set firstname = @firstname, lastname =@lastname,
address = @address, city = @city, state = @state, zip = @zip, phone_number = @phonenumber,
email = @email where id = @id
update AddressBooks set addressBookName = @addressbookname where id = @id
end

exec UpdateContactInformation @id=2,@firstname='ABC',@lastname='XYZ',@address='ALPHABET',@city='STARTEND',@state='CHARACTER',@zip=1226,@phonenumber=123262524,@email='alphabate@yahoo.com',@addressbookname='address1'

alter table employee_names add joinDate DateTime null

update employee_names set joinDate = '2017-11-30' where id = 1

update employee_names set joinDate = '2019-05-01' where id = 2

select * from employee_names where joinDate between '2020-01-01' and '2021-05-01'


select * from employee_names
select * from AddressBooks
