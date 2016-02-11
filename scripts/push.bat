cf push chart-dotnet-green -s windows2012R2 -b binary_buildpack -m 256M --no-start
cf enable-diego chart-dotnet-green
cf start chart-dotnet-green