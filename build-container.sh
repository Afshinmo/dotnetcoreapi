#!bin/bash
set -e
dotnet restore
dotnet build src/dotnetcoreapi/project.json
dotnet test test/dotnetcoreapi/project.json -xml $(pwd)/testresults/testresults-unit.xml
rm -rf $(pwd)/publish/web
dotnet publish src/dotnetcoreapi/project.json -c release -o $(pwd)/publish/web
