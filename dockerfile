FROM microsoft/dotnet:2.1-sdk

RUN apk --no-cache add wget
RUN mkdir connectfour
RUN wget  https://github.com/RichTeaMan/Hiscores/archive/master.zip -O hiscores.zip
RUN tar -xzf hiscores.zip --strip-components=1 -C PolytrisHiScore
RUN dotnet build /PolytrisHiScore/PolytrisHiScore.csproj --configuration Release
WORKDIR /PolytrisHiScore/PolytrisHiScore/bin/Release/netcoreapp2.0
ENTRYPOINT dotnet PolytrisHiScore.dll
