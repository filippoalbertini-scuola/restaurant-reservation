
# Authentication

Install Necessary Packages

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.AspNetCore.Identity

# Database (Postgres)
dotnet add package Npgsql
dotnet add package Newtonsoft.Json

## body for login 

### it fail

{
    "email": "username@email.com",
    "password": "password"
}

### success

{
    "email": "john.doe@example.com",
    "password": "password"
}