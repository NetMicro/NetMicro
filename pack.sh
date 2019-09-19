#!/usr/bin/env bash

for csproj in `find . -name '*.csproj'`
do
    dotnet pack -c Release ${csproj} -o $(pwd)
done
