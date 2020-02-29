#!/usr/bin/env bash

if [ "$#" -ne 1 ]; 
    then echo "illegal number of parameters"
    exit 1
fi

git tag $1 -d
git tag $1
rm -rf *.nupkg
./pack.sh
rm -rf ~/.nuget/packages/netmicro*
