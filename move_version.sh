#!/usr/bin/env bash

tag=$(git describe --tags $(git rev-list --tags --max-count=1))

git tag $tag -d
git tag $tag
rm -rf *.nupkg
./pack.sh
rm -rf ~/.nuget/packages/netmicro*
