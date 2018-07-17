# Movie_App

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.2.0.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running lint

Run `npm run lint` to check linting errors.(https://eslint.org/).

## Running unit tests

Run `npm run test` to execute both Mocha and angular test cases [Mocha] & [Karma] (https://mochajs.org/) & (https://karma-runner.github.io) 

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
Before running the tests make sure you are serving the app via `ng serve`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## Command used to generate this project
Project is originally generated usign Angular CLI, and was added the express part manually

Below is the command used to generate the code
`ng new --directory movie_app --source-dir webapp --prefix movie --routing true --skip-install true movie_app`

## The TMDB API to be used as data source
- To get upcoming movies use the following end point. [Upcoming movies endpoint]
(https://api.themoviedb.org/3/movie/upcoming?api_key=<<api_key>>&language=en-US&page=1)

- To get trending movies use the following endpoint. [Popular movies endpoint]
(https://api.themoviedb.org/3/movie/popular?api_key=<<api_key>>&language=en-US&page=1)

- To get recommendations for a movie use the following end point. [Recommendations movie endpoint]
(https://api.themoviedb.org/3/movie/{movie_id}/recommendations?api_key=<<api_key>>&language=en-US&page=1)

P.S :- You need to generate the API_KEY for the above endpoints and replace 
`<<api_key>>` with it.

## To register for an API key, follow these steps:

You need to signup to [TMDB] (https://www.themoviedb.org/account/signup).

	
- After login, click into your account settings [screenshot](https://www.themoviedb.org/assets/static_cache/da34d170e2ffdb3db4a317314e64b186/images/api-create-1.png)
- Click the API menu item on the left [screenshot](https://www.themoviedb.org/assets/static_cache/41b35724525a13c05bb1d63fe7af7621/images/api-create-2.png)
- Click "Create" from the API page [screenshot](https://www.themoviedb.org/assets/static_cache/af031c5c6f6787caa956d374c1c3ce9b/images/api-create-3.png)