use Address_Book_System

insert into employee_names values
(
'ABC','XYZ','ALPHABET','STARTEND','CHARACTER',1226,123262524,'alphabate@yahoo.com'
)

insert into AddressBooks values
(
'Address2','2'
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


select * from employee_names
select * from AddressBooks
