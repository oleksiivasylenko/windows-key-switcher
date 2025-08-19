cls

dotnet clean
dotnet restore
dotnet publish -c Release -r win-x64 -p:PlatformTarget=x64 --self-contained -p:PublishSingleFile=true