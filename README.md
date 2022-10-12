# FootballLeague

Football League application for managing your virtual league

## Business requirements

- Create a system, which will be used to display the following:
	- Teams ranking
	- Teams played matches

- The system should have the following functionality:
	- CRUD operations for teams
	- CRUD operations for matches(only for played matches)
	- After the result is added, the table with the rankings and results in the customers portal should be updated accordingly
	- Should have following scoring: win: 3 points, draw: 1 point and loss: 0 points

## DB Migration

- Identity: Project Infrastructure - Update-Database Initial -Context AppIdentityDbContext
- Data: Project Data - Update-Database Initial -Context FootballLeagueDbContext

## Development Authentication Credentials

```
{
  "userName": "admin@footballleague.com",
  "password": "!1qaz2Wsx"
}
```

## NOTE: Production Creadentials are stored in appsettings.json, DONT USE IN ACTUAL PRODUCTION ENVIRONMENT

## Endpoints

### Public

- Matches
 - GET /api/v1/Matches
 - GET /api/v1/Matches/id
- Teams
 - GET /api/v1/Teams/rankings
 - GET /api/v1/Teams/played
 - GET /api/v1/Teams
 - GET /api/v1/Teams/id

### Authorized ( Administrator Only )

- Matches
 - POST /api/v1/Matches
 - PUT /api/v1/Matches
 - DELETE /api/v1/Matches
- Teams
 - POST /api/v1/Teams
 - PUT /api/v1/Teams
 - DELETE /api/v1/Teams