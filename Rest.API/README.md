
sudo apt-get install dotnet-sdk-3.1
sudo apt-get install dotnet-runtime-3.1

sudo dotnet nuget locals all -c

sudo dotnet add package NSwag.AspNetCore --version 13.2.5
sudo dotnet add package Microsoft.AspNetCore.Mvc.Versioning --version 4.1.1

sudo dotnet add package Swashbuckle.AspNetCore --version 5.0.0
dotnet add Rest.API.csproj package Swashbuckle.AspNetCore -v 5.0.0