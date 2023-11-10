# Blazor Server Template Project

This repository contains a Blazor Server Application that follows Clean Architecture and has both authentication and authorization with MudBlazor for the front-end. 

## How to Use

In order to use this project, you will need to provide a valid connection string to MSSQL DB and run the appropriate migrations (remember, you can generate the database structure using the ScriptDbContext command). You will also need to provide a random string as the JWTKey. Both of these have to be provided in the `appsettings.json` file that can be found on the Presentation.Blazor.Server project.

## Warning

This project has not been updated in a while, since I'm not using Blazor for the time being. Things may have changed, or things may break if you update the packages.
