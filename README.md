***** Mapping API *****
This was a task made to mimic and facilitate the mapping of a reservation models. 

API Details:
	The application offers a single endpoint with the following details:
		[POST] /map
		Query Params: sourceType (required), targetType (required)
		Body: { --any data-- } (required)
	
	
Project Details:
	The solution is created using .NET 9 and doesnt require DB access for now. It consists of 3 projects that help maintain the segregation of different entities like models, API endpoints etc. Below are the details:
	(1) DataModels.proj - Consists of Internal and External folders. The External folders hold further folders with respect to the third-party models we support (e.g; Google). The Internal folder holds our internal data models. This project also holds a generic model "Error" for error handling.
		DataModels
		|
		|-External
		|	|-Google
		|		|-Hotel.cs
		|		|-Room.cs
		|		...
		|-Internal
		|	|-Hotel.cs
		|	|-Room.cs
		|	...
		|-Error.cs
		|
	
  (2) MappingAPI.proj - Consists of the controllers (MapController only for now) that exposes the endpoints for interaction.
	
  (3) MappingUtilities.proj - This consists of the handlers and validators that deal with model mapping and validations. Consists of 3 folders:
		MappingUtilities
		|
		|-Extensions (These contain extension methods to predefined types; generic or otherwise)
		|-Handlers 
		|	|-DataModelHandler (Methods related to getting types or instances from data models)
		|	|-MapHandler (Methods related to mapping)
		|	|-ValidationHandler (Validation methods)
		|-Mappers
		|	|-HotelMappers
		|	...


Extensibility:
  For adding new models and mappings, follow the steps given below:
  (1) Depending on whether the model is external or internal, create your model class and add it to the respective folder (you might have to create a new one) in DataModels project.
  	
  (2) Go to MappingUtilities project and open Handlers -> DataModelHandler.cs -> DataModelsEnum. Add an Enum entry (any name used for conveniently accessing the new model) and a description (this is the name we are expecting the user to give when sending a request). For example; 
    		[Description("internal.location")] //internal.location is the name user passes
  			INTERNAL_LOCATION, //enum value used to refer to this model internally
  			
  (3) Staying in the same file, go to the method "Type GetType(string typeName)" and add an entry for your enum name and add the data model name (the one you created in DataModels project).
  	
  (4) In the same project, go to Mappers folder and create a class for your mapper (e.g; InternalToGoogleHotel.cs) and add to the relevant folder (HotelMappers, etc. or create new). Ensure that IMapper interface is implemented. Define source and target models in class and add the mapping. 
  	
  (5) Build the solution and enjoy! :)
  
 P.S.: There is a dummy request file.
	
	
