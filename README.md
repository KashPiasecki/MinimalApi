# About #
### This project was created to try out new <b>MinimalApi</b> approach with <b>.NET 6</b>. Planning to use: ###
* Automatic database update mechanism
* Docker-compose to spin up sql server
* EntityFramework Core
# How to run # 
When spinned up docker-compose credentials are:
* server: `localhost,1433`
* username: `sa`
* password: `pa55w0rd!`

Afterwards please run locally on ports:
* http: `5010`
* https: `5000`

For testing use api client (e.g. postman/insomnia). endpoints are: 
### GET ###     
`https://localhost:5000/api/v1/commands`

`https://localhost:5000/api/v1/commands/{id:int}`
### POST ###
`https://localhost:5000/api/v1/commands`
### DELETE ###
`https://localhost:5000/api/v1/commands/{id:int}`

`Command` entity structure POST: 
```
{
    "HowTo" : "<string>",
    "Platform": "<string:maxLength(5)>",
    "Command": "string"
}
```