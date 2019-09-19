#!/usr/bin/env bash

for nupkg in `find . -name '*.nupkg'`
do
    dotnet nuget push -s https://api.nuget.org/v3/index.json -k $(cat ~/.nuget_keys) ${nupkg}
done
