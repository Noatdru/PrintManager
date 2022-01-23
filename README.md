# Running application
* Create database container 
> docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P4??word??" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04
> docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P4??word??" -p 1434:1433 -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04

