# Overview

The files in this folder have been modified from [here](https://github.com/microsoft/mssql-docker/tree/80e2a51d0eb1693f2de014fb26d4a414f5a5add5/linux/preview/examples/mssql-customize).

Build the image:

```
docker build -t fmcgarry/wedding .
```

Spin up a new container, setting `SA_PASSWORD` with your own value:

```
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=StrongPassw0rd' -p 1433:1433 --name wedding-db -d fmcgarry/wedding
```