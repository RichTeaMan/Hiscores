FROM microsoft/dotnet:2.1-sdk

ARG branch=master

RUN mkdir PolytrisHiScore
ADD https://github.com/RichTeaMan/Hiscores/archive/$branch.tar.gz hiscores.tar.gz
RUN tar -xzf hiscores.tar.gz --strip-components=1 -C PolytrisHiScore
RUN dotnet restore /PolytrisHiScore/PolytrisHiScore/PolytrisHiScore.csproj
RUN dotnet publish /PolytrisHiScore/PolytrisHiScore/PolytrisHiScore.csproj --configuration Release
WORKDIR /PolytrisHiScore/PolytrisHiScore/bin/Release/netcoreapp2.0
EXPOSE 80
ENTRYPOINT ["dotnet", "PolytrisHiScore.dll", "--", "/var/hiscore/scores.json"]
