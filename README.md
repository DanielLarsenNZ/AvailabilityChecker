# Availability Checker

Azure Monitor Custom Availability Test host that runs as a Web Job in an Azure App Service. This test host can be used to check other Functions and Web Apps in the same App Service Plan, or in the same private network.

## Getting started

    dotnet build -c Release
    dotnet run -c Release

## Deployment

    dotnet publish -c Release

Upload `publish` folder to an App Service Web Job. Or publish from Visual Studio. Or deploy using `az webapp deployment source config-zip`.
