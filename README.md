# webApi
Тестил в Постмане. Примерно вот такие запросы вроде работают.

post
Получает в теле запроса объект CreateTaskDto маппит в CreateTaskCommand и выполняет запись в бд
https://localhost:7214/WeatherForecast
Body:
{\n
    "Header" : "makarov ak",
    "Description" : "ssssss",
    "CompletionDate" : "2023-09-17T07:56:06.615Z"
}

put
получает в теле запроса UpdateTaskDto маппит в UpdateTaskCommand ищет в бд таску, если есть, то вносит изменения в бд.
https://localhost:7214/WeatherForecast
{
  "id": 1,
  "header": "task1",
  "description": "text",
  "completionDate": "2023-09-20T09:41:52.754Z",
  "status": 1
}

delete
получает в качестве параметра id таски, если такая есть в бд, удаляет
https://localhost:7214/WeatherForecast?id=1
Key = id, Value = 1

get
получает в качестве параметра id таски, если такая есть получает ее из бд и маппит в GetTaskListVm, возвращает клиенту
https://localhost:7214/WeatherForecast?id=1
Key = id, Value = 1

get list
получает в качестве параметров searchBy (поле) pattern (значение поля) pageIndex (номер страницы) pageSize (размер страницы). Получает объект GetTaskListVm и возращает клиенту
https://localhost:7214/WeatherForecast?searchBy=Header&pattern=task&pageIndex=3&pageSize=2
searchBy = Header
pattern = task
pageIndex = 3
pageSize = 2
