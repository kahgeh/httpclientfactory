
# Objective
A sample to show how to use the new HttpClientFactory. In addition to that show how we can configure the httpclient to use standard message handlers, e.g. a logging handler , flowing the correlation id from inbound request to outbound request 

See issue with possibility of exhausting connection -   https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

# Setup

At the point this was built, this sample uses a pre-release version of .net, ensure that you have the following package sources added to your NuGet.config file:
1. https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
2. https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json


you can add package source either by :

1. Introducing the NuGet.config file locally or change the global config file here C:\Users\<your name\AppData\Roaming\NuGet\NuGet.Config
2. Run nuget `nuget add -source https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json`

# Coding

1. Add http client factory to the services catalog

    `services.AddHttpClient();`

2. Define the typed http client e.g. `ValuesClient` and `OutboundLoggingHandler` 

3. Register the http client and add the message handler to it 
        ```
         services
                .AddHttpClient<ValuesClient>()
                .AddHttpMessageHandler(sp=>{
                    return sp.GetService<OutboundLoggingHandler>();
                })
        ```