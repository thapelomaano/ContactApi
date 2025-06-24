    # Contacts Manager App

    This is a simple contacts management system built using:

    - ASP.NET Core Web API (backend)
    - SQLite (database)

    It supports CRUD operations for contacts.

    ---

    ## Features

    - Create, Read, Update, and Delete (CRUD) contacts
    - API tested via Swagger or REST clients
    - Responsive UI and styled tables/forms

    ---

    ## Project Structure

    ContactAPI - ASP.NET Core Web API (.NET 7+)
    contacts.db - SQLite DB

    ---

    ## ⚙️ Prerequisites

    - [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
    - Visual Studio 2022+ or VS Code
    - SQLite

    ---

    ## 🛠️ Setup Instructions

    ### 1. Clone the Repository

    git clone https://github.com/your-username/ContactAPI.git
    cd ContactAPI

    ### 2. Run Api 
    cd ContactAPI
    dotnet ef database update   # Apply DB migrations
    dotnet run

    # Sql script can be found in the scripts folder
