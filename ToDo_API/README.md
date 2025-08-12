Todo API

A minimalistic ToDo RESTful API built with ASP.NET Core and Entity Framework Core (InMemory database).

⸻

Features
	•	Create, read, update, and delete ToDo tasks.
	•	Simple in-memory data storage (no database setup required).
	•	Clean and clear RESTful endpoints.
	•	Auto-generated Swagger UI for API exploration and testing.

Getting Started!!!

	1.	Clone the repository or download the source code.
	2.	Navigate to the project directory: (cd TodoApi)
    3.  Run application(dontet run)
    4.	The API will be accessible at: (https)//localhost:5001
    5.	To explore and test endpoints, open the Swagger UI in your browser at:(//localhost:5001/swagger)
    

    Sample Request Body for Creating a Task(json)
    {
        "title": "Finish homework",
        "isCompleted": false
    }

    Notes
	•	Data is stored in memory and will be lost when the application stops.
	•	Designed for learning and demonstration purposes.
	•	Can be extended to use persistent databases like SQLite or SQL Server.
