# Hollywood-Bet-API

This project has 4 layers.
#Hollywood Bets Betting Website API
#Hollywood Bets Admin Website API
#Models Layer (So models can be shared between both APIs)
#Repository Layer

## ERD Diagram

All database interactions within this project is made executing stored procs using Dapper.
![erd](https://user-images.githubusercontent.com/7023242/88667498-be785e80-d0e1-11ea-9c0b-2befa6dbd2a3.png)

All controllers use Log4Net.
This projects makes use of dependency injection (Constuctor Injection)

Hollywood Bets Betting Website API

This API is mainly in charge of getting all the data from the database for display on the Angular Website.
It also is in charge of striking bets for punters.

Hollywood Bets Admin CRUD website API

This api is in charge of doing all the CRUD work. It ensures that the new sports,countries,tournaments and events can be added to the Hollywood Bets Betting Website.

