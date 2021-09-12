# Message Processor Service

## Building the application

Install the [.NET Core SDK](https://www.microsoft.com/net/download). Then run these commands from the CLI under messageprocessor.application folder.

```bash
dotnet build
dotnet run
```
These commands will install any needed dependencies, build the project, and run the project respectively.

## REST API
Once the application is up and running, navigate to [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html) to access Swagger UI and to interact with the API endpoints.

### Create a Message

#### Sample request
`POST /api/Messaging`
```bash
{
  "from": "6588882222",
  "to": "6511111111",
  "type": "text",
  "text": "Hello",
  "sendTime": "2021-08-23 09:00"
}
```

#### Response
```bash
Status: 201 Created
```
