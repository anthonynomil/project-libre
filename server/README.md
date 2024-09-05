# Clean Architecture 

  

# Entity layer: 

  

- Contains all entities needed to the core of the application to work. 

    - Persistent entities are sorted in their own folder to indicate which entities are meant to be persisted in the database. 

    - Primary entities inherit from the PrimaryKey abstract class to supplement them with an Id attribute. 

    - Entities which define different actors, such as a User and a Company, but own an attribute of the same type, such as an Address, shall both implement an interface, such as IAddressable. 

    - Other entities which shall not be persisted are stored in this layer until they will be stored in their own assembly to clean up the application code. 

- Following the Domain Driven Development principle: 

    - An entity shall never exist in an invalid state. 

    - Thus entities shall contain the business logic necessary for them to always be valid. 

    - Any development which would purposefully lead an entity to be in an invalid state shall be carefully handled at the Application layer. 

  

# Application layer 

  

- Contains services which shall each handle a single Actor of the application. 

    - This follows the Single Responsibility Principle but does not necessarily translate to a single Entity. In fact the AddressApplicationService could handle both Country and Address entities. 

- Contains models which the services will translate entities to for communication at the Infrastructure layer. 

    - Different models shall respond to different needs. Hence for each operation on a given entity, a different model shall be created, such as UserDto, UserDtoCreate, UserDtoUpdate. 

    - This allows for better Separation of Concern. Each model defines what attribute can be worked with for a given action. 

    - Model validation will be handled thanks to attributes defined in the models themselves. 

- Contains interfaces for internal dependencies. 

    - Application services shall rely on each other to promote code reuse and follow the Single Responsibility Principle. 

    - ServiceA shall implement an interface which allows ServiceB to only access the methods it needs from ServiceA. 

    - The emphasis is put on methods’ signature rather than implementation. Taking the previous point, it means ServiceB receives exactly what it needs, regardless of how ServiceA achieves it. 

    - This also means ServiceB is not exposed to methods it has no use for. 

- Contains interfaces for dependency inversion. 

    - Since the Infrastructure layer depends on the Application layer, and not the other way around, the Application layer shall hold the interfaces implemented at the Infrastructure layer. 

    - This allows for Application services to access methods from classes such as Repositories. 

  

# Infrastructure layer 

  

- Contains the logic needed to communicate with outside actors, such as Clients, Databases or third party APIs. 

 
