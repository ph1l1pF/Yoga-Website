# Yoga Website

Code for the Yoga Website from my mom: http://yoga-schule-heepen.de

## Start locally

Run `start.sh` to run backend and frontend with docker compose.

## Parts

- Backend: .NET Web API
- Frontend: Angular App

## Environment

- create `.env` file at repo root level (is ignored by git)

## Build and deployment

- The application (frontend + backend) is deployed on a remote machine
- a github workflow is used for that
- it executes a shell script via ssh on the remove server ([tutorial](https://nbailey.ca/post/github-actions-ssh/))
- the script has the content of [start_on_server.sh](start_on_server.sh)
- that script has to be copied to /bin on the remove machine before hand (this step is not automated)
- also the repo has to be cloned to ~/git before hand (this step is not automated)
