cf push chart-dotnet-blue -s windows2012R2 -b binary_buildpack -m 256M --no-start
cf enable-diego chart-dotnet-blue
cf start chart-dotnet-blue