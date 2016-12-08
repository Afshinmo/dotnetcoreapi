# dotnetcoreapi

[![Build Status](http://ec2-35-164-228-65.us-west-2.compute.amazonaws.com:8080/buildStatus/icon?job=dotnetcoreapi_ci)](http://ec2-35-164-228-65.us-west-2.compute.amazonaws.com:8080/job/dotnetcoreapi_ci)

The .NET Core Web API reference project.

When starting a new .NET core software project use this repository as a starting point.

## This application consists of:

*   A .NET core web API (1.0.1) created using Visual Studio 15 Update 3.

## Features

*   Bare project
*   Unit test [xUnit]

## Overview
* The source is in the subdirectory src. This project consists of only the webapi dotnetcoreapi, thus the subfolder

## Run project

*   Clone this repository
```
cd dotnetcoreapi
dotnet restore
cd src
cd dotnetcoreapi
dotnet build
dotnet run
```
*   Navigate a browser to http://localhost:5000/api/values to see ["value1","value2"]

## Run test

*   we assume that you already Cloned this repository
```
cd dotnetcoreapi
cd test
cd dotnetcoreapiTest
dotnet test
```

## Contributor guidelines
* All code should be reviewed by someone else before merged
* Use [Microsoft Coding Conventions](https://msdn.microsoft.com/en-us/library/ff926074.aspx)
* We version [semantically](http://semver.org/)

## References
* Here there will be references to related repositories

We would love to hear your feedback and get your help of enhancing this architecture. 

## 
