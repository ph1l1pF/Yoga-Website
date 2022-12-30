# Yoga Website

Code for the Yoga Website from my mom: http://yoga-schule-heepen.de

## Start locally

Run [start.sh](start.sh) to run backend and frontend with docker compose.

## Parts

- Backend: .NET Web API
- Frontend: Angular App

## Environment

create `.env` file at repo root level (is ignored by git) with the following content:

```env
MailCompany=somemail
PasswordMailCompany=somepassword
SmptServerMailCompany=smtpserver
SmptPortMailCompany=587
MongoConnectionString=a mongo connection string
```

## Build and deployment

- The application (frontend + backend) is deployed on a remote machine
- a github workflow is used for that
- the workflow is triggered when a push to the main branch is executed
- it executes [start_on_server.sh](start_on_server.sh) via ssh on the remove server ([tutorial](https://nbailey.ca/post/github-actions-ssh/))
- the repo has to be cloned to ~/git before hand (this step is not automated)

### Future Ideas

- push the docker images to docker hub and then only pull the docker images on the remote machine instead of cloning the full repo and pulling the latest code
