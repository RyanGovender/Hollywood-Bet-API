# Hollywood-Bet-API

This project has 4 layers.
#Hollywood Bets Betting Website API
#Hollywood Bets Admin Website API
#Models Layer (So models can be shared between both APIs)
#Repository Layer

This projects makes use of dependency injection (Constuctor Injection)
All database interactions within this project is made executing stored procs using Dapper.
All controllers use Log4Net.

Hollywood Bets Betting Website API

This API is mainly in charge of getting all the data from the database for display on the Angular Website.
It also is in charge of striking bets for punters.

Hollywood Bets Admin CRUD website API

This api is in charge of doing all the CRUD work. It ensures that the new sports,countries,tournaments and events can be added to the Hollywood Bets Betting Website.
