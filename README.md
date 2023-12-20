# ToDo List Application Read me Template

## Please Use the Postman Collection to test the backend

## Questions and Answers

**Why using Bearer Tokens for Authenication ?**

We are using Bearer which is not a web but it's simple and self contained and stateless . which means it doesn't need to back to the server to check it validity

**Which Database you choosed to use?**
using SqlLite for demo purpose

**What are the commands you used for Migration?**

```
dotnet tool install --global dotnet-ef --version 8.\* for database Migration

dotnet ef migrations add InitialCreate --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.Api.csproj

dotnet ef database update --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.api.csproj

dotnet ef migrations add ToDoListItem --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.Api.csproj
```

**WHY using CQRS and MIDator ?**
Application architure doesn't rely only on the current vision but also what about the application in the next 5 years. I believe that the application components need to scale in indpendant way
Using midator has its pros and cons it may create bottleneck under heavy usage (Single point of failure) which can be resolved in the cloud side. but it provides Decoupling resuablitiy and Centralisation
and as it adds complexity I'm expecting this application to grow rapidly in the next few months. or let's say projects at CMC is already large and complex :)

**Why I structured the application this way?**

Adding the Backend in a seperate Library will help scale/descale it later at the infrastructure level

**Why I added Patterns and Ignored Patterns?**
I believe the complexity is relative to the size of the application we need to find the right Balance between the size and amount of patterns we are using. Also Some patterns are used for demo purpose
to demonstate skills.

ef Migration Commands I used
dotnet ef migrations add initalCreate --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.csproj
dotnet ef database update --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.csproj
dotnet ef migrations add ToDoListItem --verbose --project ./ToDoList.Persistence.csproj --startup-project ../ToDoList/ToDoList.csproj

**Why Not add the Migration in the correct place from the Beginning?**
I want to demonstate how the application Grow organicelly.

**Why you use Records instead of normal class?**
Records is a spical type of classes that are immutable and have numerous benifits. you can review them in the reouses section.

**Why Using Data Annotation over Normal model Builder?**
To give more info about the entity by looking into it.

**Why Swagger Description is not showing up despite being added? Swagger Misconfigered ?**
https://stackoverflow.com/questions/70800034/add-swagger-description-to-minimal-net-6-apis

**why didn't I pass the Id in the route in the update?**
I don't like to expose data in the URL in general I keep it in the body.

**why Mark as complete which is very similar to Update?**
Single responsiplity rule.

**Did you write the PredicateBuilder ?**
No the link is in the resouces I just used it.

**Why you didn't use problemDetails Approch to handle the exceptions?**
I have concerns over it's performance

**Why Choose Serilog?**
Simple and Handy and I wanted to keep the logs on file. maybe it will come handy if we are working with servers on-primse

**Why the unit tests are not covering all the commands/queries?**
I wrote them as POC and I will work on them later when I have time.

**Why you didn't test the Services in the API layer?**
As it is one line of code I tested only the logic behind. however in standard situation I should test both Service and Domain layers.

Resources

- [MediatR](https://www.gofpattern.com/design-patterns/module6/benefits-pitfalls-mediatorPattern.php).

- [MediatR For Tim Corey](https://www.youtube.com/watch?v=yozD5Tnd8nw)

- [Records](https://medium.com/codex/start-using-c-records-for-dtos-instead-of-regular-classes-1f84bd5997ca)
- [Predicate Builder](https://www.albahari.com/nutshell/predicatebuilder.aspx).

##Task List

- **STR 001** : Add The Database and Create the Authentication and Authentication

- **STR 002** : Add The Data Access Layer and Moving the Migration into the Correct place

- **STR 003** : Add Vertical Slice from the Database to the endpoint using Get All

- **STR 004** : Add AutoMapper and the rest of the end points

- **STR 005** : Unit Tests, Logging and Exception Handling

- **STR 006** : Read me File Polish and Postman Collection

# Things needs to be done.

##Backend

- Proper CQRS
- Unit of Work Pattern
- More Unit Tests Coverage For the Service Layer and Controller

##Frontend

- Have an issue with first login. I need to refresh the page to get the data 
- An Issue with the search with text change I needed to add the button 
- Add Responseiveness to the application
- Add Tests to the frontend 
- Enhance the CSS 
