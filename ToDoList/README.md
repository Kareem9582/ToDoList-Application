# ToDo List Application Read me Template 
## Description 
We are using Bearer which is not a web but it's simple and self contained and stateless . which means it doesn't need to back to the server to check it validity 
using SqlLite for demo purpose
Installed dotnet tool install --global dotnet-ef --version 8.* for database Migration
dotnet ef migrations add initalCreate
dotnet ef database update
Adding the postman Collection

WHY using CQRS and MIDator ? 
Application architure doesn't rely only on the current vision but also what about the application in the next 5 years. I believe that the application components need to scale in indpendant way 
Using midator has its pros and cons it may create bottleneck under heavy usage (Single point of failure) which can be resolved in the cloud side. but it provides Decoupling resuablitiy and Centralisation 
and as it  adds complexity I'm expecting this application to grow rapidly in the next few months. or let's say projects at CMC is already large and complex :) 


Why I structured the application this way? 

Adding the Backend in a seperate Library will help scale/descale it later at the infrastructure level 

Why I added Patterns and Ignored Patterns?
I believe the complexity is relative to the size of the application we need to find the right Balance between the size and amount of patterns we are using. Also Some patterns are used for demo purpose 
to demonstate skills. 
 
ef Migration Commands I used 
dotnet ef migrations add initalCreate --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.csproj
dotnet ef database update --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.csproj
 dotnet ef migrations add ToDoListItem --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.csproj
 
Why Not add the Migration in the correct place from the Beginning? 
I want to demonstate how the application Grow organicelly. 

Why you use Records instead of normal class?
Records is a spical type of classes that are immutable and have numerous benifits. you can review them in the reouses section. 
Why Using Data Annotation over Normal model Builder? 
To give more info about the entity by looking into it. 

Why Swagger Description is not showing up despite being added? Swagger Misconfigered ? 
	https://stackoverflow.com/questions/70800034/add-swagger-description-to-minimal-net-6-apis

why didn't I pass the Id in the route in the update?
I don't like to expose data in the URL in general I keep it in the body. 

why Mark as complete which is very similar to Update? 
Single responsiplity rule. 

Did you write the PredicateBuilder ? 
No the link is in the resouces I just used it.

Why you didn't use problemDetails Approch to handle the exceptions? 
I have concerns over it's performance

Why Choose Serilog? 
Simple and Handy and I wanted to keep the logs on file. maybe it will come handy if we are working with servers on-primse

Why the unit tests are not covering all the commands/queries? 
I wrote them as POC and I will work on them later when I have time.

Why you didn't test the Services in the API layer? 
As it is one line of code I tested only the logic behind. however in standard situation I should test both Service and Domain layers. 
	
Resources 
CQRS AND MediatR 
	https://www.gofpattern.com/design-patterns/module6/benefits-pitfalls-mediatorPattern.php
	https://www.youtube.com/watch?v=yozD5Tnd8nw
	https://medium.com/codex/start-using-c-records-for-dtos-instead-of-regular-classes-1f84bd5997ca
	https://www.albahari.com/nutshell/predicatebuilder.aspx

STR 001 : Add The Database and Create the Authentication and Authentication
STR 002 : Add The Data Access Layer and Moving the Migration into the Correct place

# Things needs to be done. 
# frontend 
