# Personal Task Manager

A **console-based task management application** written in C# for managing your personal tasks offline.  
This project demonstrates usage of **OOP, collections, LINQ, JSON serialization, async/await, and exception handling** in a practical, real-world scenario.

---

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Technologies](#technologies)
- [Contributing](#contributing)

---

## Features

- **Add, Read, Update, Delete tasks** (CRUD operations)  
- Store task data locally in **JSON format** (`tasks.json`)  
- Filter tasks by **priority** or **deadline**  
- Mark tasks as **completed**  
- Automatic saving after every operation  
- Input validation and error handling for robust usage  

---

## Getting Started

### Prerequisites
- [.NET SDK 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) or later  
- Compatible OS: Windows, Linux, macOS  

### Installation
1. Clone this repository:
```bash
git clone https://github.com/Muradxanyann/Projects/tree/main/Personal_Task_Manager
2. Navigate into the project directory:
```bash
cd PersonalTaskManager:
3. Run the project:
```bash
dotnet run

Usage:
When running, the program presents a menu:
Choose the operation:
1 - Read
2 - Write
3 - Update
4 - Delete

	•	Read: View all tasks, filter by priority or deadline.
	•	Write: Add a new task (title, description, priority, deadline).
	•	Update: Modify an existing task.
	•	Delete: Remove a task.

Tasks are saved automatically in tasks.json in the current working directory. If the file does not exist, it is created automatically.

Contributing

Feel free to open issues or submit pull requests.
Best practices: maintain clean code, OOP principles, and SOLID architecture.
