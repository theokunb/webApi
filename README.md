# webApi
Тестил в Постмане. Примерно вот такие запросы вроде работают.

post
https://localhost:7214/WeatherForecast
Body:
{
    "Header" : "makarov ak",
    "Description" : "ssssss",
    "CompletionDate" : "2023-09-17T07:56:06.615Z"
}

put
https://localhost:7214/WeatherForecast
{
  "id": 1,
  "header": "task1",
  "description": "text",
  "completionDate": "2023-09-20T09:41:52.754Z",
  "status": 1
}

delete
https://localhost:7214/WeatherForecast?id=1
Key = id, Value = 1

get
https://localhost:7214/WeatherForecast?id=1
Key = id, Value = 1
