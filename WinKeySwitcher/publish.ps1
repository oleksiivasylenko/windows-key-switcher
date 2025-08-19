cls
dotnet clean
dotnet restore

$platform = Read-Host "Enter platform (x86/x64/arm64) [default: x64]"
if ([string]::IsNullOrWhiteSpace($platform)) { $platform = "x64" }

$selfContainedAnswer = Read-Host "Build as self-contained? (y/n) [default: n]"
$useSelfContained = ($selfContainedAnswer -match '^(y|Y)$')

$publishSingleFile = "true"
$enableCompression = "false"
$includeNativeForSelfExtract = if ($useSelfContained) { "true" } else { "false" }
$publishReadyToRun = if ($useSelfContained) { "true" } else { "false" }

Write-Host ""
Write-Host ">>> Publishing with parameters:"
Write-Host "PlatformTarget=$platform"
Write-Host "Self-contained=$($useSelfContained.ToString().ToLower())"
Write-Host "PublishSingleFile=$publishSingleFile"
Write-Host "EnableCompressionInSingleFile=$enableCompression"
Write-Host "IncludeNativeLibrariesForSelfExtract=$includeNativeForSelfExtract"
Write-Host "PublishReadyToRun=$publishReadyToRun"
Write-Host ""

dotnet publish WinKeySwitcher.csproj `
  -c Release `
  -r win-$platform `
  -p:PlatformTarget=$platform `
  --self-contained=$($useSelfContained.ToString().ToLower()) `
  -p:PublishSingleFile=$publishSingleFile `
  -p:EnableCompressionInSingleFile=$enableCompression `
  -p:IncludeNativeLibrariesForSelfExtract=$includeNativeForSelfExtract `
  -p:PublishReadyToRun=$publishReadyToRun
