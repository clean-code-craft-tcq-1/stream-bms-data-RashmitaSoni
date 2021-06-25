pushd "%~dp0"

dotnet run --project Sender\BMSSender\BMSSender.csproj | dotnet run --project Receiver\BatteryReceiver\BatteryReceiver.csproj

popd
