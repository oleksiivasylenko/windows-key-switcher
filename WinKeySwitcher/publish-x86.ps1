cls

dotnet clean
dotnet restore
dotnet publish -c Release -r win-x86 -p:PlatformTarget=x86 --self-contained -p:PublishSingleFile=true