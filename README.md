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
This request validates whether the input is in one of the accepted json formats. If the json schema is valid, the message will be stored in the database or else the enpoint will return appropriate error.

#### Request
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

```bash
{
  "message": 
  {
    "type": "text",
    "id": "4e9faf2b-325c-41e5-9db1-642d4d94b43f",
    "text": "Hello"
  },
  "source": 
  {
    "type": "user",
    "userId": "qwerty"
  },
  "timestamp": 1629680508
}
```

```bash
{
  "msisdn": "6588882222",
  "message": 
  {
    "msgText": "Hello",
    "msgTime": "2021-08-23 09:00"
  }
}
```

#### Response
```bash
Status: 201 Created
```
