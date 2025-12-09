



create table Employees(
Id int primary key identity(1,1),
Name nvarchar(50),
Department nvarchar(50),
Salary int
);

INSERT INTO Employees (Name, Department, Salary)
VALUES 
    ('Arjun Kumar', 'Engineering', 85000),
    ('Meera Joseph', 'Human Resources', 52000),
    ('Rahul Singh', 'Engineering', 92000),
    ('Sana Patel', 'Marketing', 60000),('Vikas Menon', 'Finance', 75000),
    ('Nisha Reddy', 'Marketing', 58000),('Irfan Ali', 'Product', 98000),
    ('Pooja Sharma', 'Engineering', 88000),('Kiran Mathew', 'Finance', 70000), ('Deepika Nair', 'Customer Support', 45000);



    create proc DepartmentData
    @DepartmentName nvarchar(50),
    @TotalSalary int output 
    as 
    begin 
   select @TotalSalary =sum(salary) from employees where Department=@DepartmentName;
   select Id,Name,Salary,Department from employees where Department=@DepartmentName;
    end;

    drop proc DepartmentData

