# ReCapProject
We can do crud operations and some other operations for car,brand,color,user,customer and rental. I used sql server which is in visual studio and used foreign key for relation between this tables. We can rent a car with this system. 

When I made this app, I used layered architecture . Layers are Entity, DataAcces, Business, Core(same codes all project) and Web Api. I used Web Api and tested this in Postman.
I used entity framework to ORM.
I also added autofac for IoC, fluent validation, caching, transaction, performance for cross cutting concerns and used AOP .

This system includes authentication and authorization. I used jwt for authentication. When someone wants to add car,brand,color, must be login and admin adjust who can add car,brand color. So admin can give authorization for add operations. Every car has minimum findeks point. If someone wants to rent a car he or she must have minimum findeks point to that car.
