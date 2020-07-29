# Hollywood-Bet-API

This project has 4 layers.
#Hollywood Bets Betting Website API
#Hollywood Bets Admin Website API
#Models Layer (So models can be shared between both APIs)
#Repository Layer

## ERD Diagram

All database interactions within this project is made executing stored procs using Dapper.
![erd](https://user-images.githubusercontent.com/7023242/88667498-be785e80-d0e1-11ea-9c0b-2befa6dbd2a3.png)

## Hollywood Bets Admin CRUD website API

This api is in charge of doing all the CRUD work. It ensures that the new sports,countries,tournaments and events can be added to the Hollywood Bets Betting Website.

The Front End For the Admin Website. https://github.com/RyanGovender/HollywoodBets-Admin

![erd](https://user-images.githubusercontent.com/7023242/88770139-a6561d00-d17d-11ea-9c6a-1f454836b441.png)

## Hollywood Bets Betting Website API

This API is mainly in charge of getting all the data from the database for display on the Angular Website.
It also is in charge of striking bets for punters.
 
The Front End Bet Striking Website. https://github.com/RyanGovender/HollywoodBets
![erd](https://user-images.githubusercontent.com/7023242/88769324-8d993780-d17c-11ea-8934-244b33f21b99.png)




