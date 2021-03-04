# Availability Checker

[Azure Monitor Availability Test](https://docs.microsoft.com/en-us/azure/azure-monitor/app/monitor-web-app-availability) custom host that runs as a Web Job in an Azure App Service. This test host can be used to check other Functions and Web Apps in the same App Service Plan, or in the same private network.

## Getting started

    copy appsettings.example.json appsettings.json
    
    # Add connection string and instrumentation key to app settings.json

    dotnet build -c Release
    dotnet run -c Release

## Deployment

    dotnet publish -c Release

Upload `publish` folder to an App Service Web Job. Or publish from Visual Studio. Or deploy using `az webapp deployment source config-zip`.

## Links & references

[Get started with the Azure WebJobs SDK for event-driven background processing](https://docs.microsoft.com/en-us/azure/app-service/webjobs-sdk-get-started)

[Select .NET 5 as the .NET Framework Version](https://devblogs.microsoft.com/aspnet/announcing-asp-net-core-in-net-5/#:~:text=select%20.NET%205%20as%20the%20.NET%20Framework%20Version)

<https://docs.microsoft.com/en-us/azure/azure-monitor/app/monitor-web-app-availability>

[AzureWebJobsDisableHomepage](https://docs.microsoft.com/en-us/azure/azure-functions/functions-app-settings#azurewebjobsdisablehomepage)

<https://github.com/projectkudu/kudu/wiki/WebJobs#soft-vs-hard-shutdowns>
