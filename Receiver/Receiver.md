###### RECEIVER
 
Program.cs - 
    Reads each Battery Parameter (Temperature, State Of Charge) from the Sender and gets the minimum and maximum readings of each and prints the same.
    After 5 Parameters are read, it calculates the average value and prints.
    
    C:\Users\hnc1kor\source\repos>dotnet run --project Sender\BMSSender\BMSSender.csproj   | dotnet run --project Receiver\BatteryReceiver\BatteryReceiver.csproj
    
    Temperature: 9.55 Charge Rate: 0.73
    Minimum Temperature - 0 Maximum Temperature - 0
    Minimum StateOfCharge - 0.73 Maximum StateOfCharge - 0.73
    Temperature: 29.6 Charge Rate: 0.51
    Minimum Temperature - 0 Maximum Temperature - 0
    Minimum StateOfCharge - 0.51 Maximum StateOfCharge - 0.73
    Temperature: 19.85 Charge Rate: 0.65
    Minimum Temperature - 0 Maximum Temperature - 0
    Minimum StateOfCharge - 0.51 Maximum StateOfCharge - 0.73
    Temperature: 28.61 Charge Rate: 0.58
    Minimum Temperature - 0 Maximum Temperature - 0
    Minimum StateOfCharge - 0.51 Maximum StateOfCharge - 0.73
    Temperature: 39.44 Charge Rate: 0.73
    Minimum Temperature - 0 Maximum Temperature - 0
    Minimum StateOfCharge - 0.51 Maximum StateOfCharge - 0.73
    Average Temperature - 0 Average StateOfCharge - 0.64


BatteryReceiverParser.cs - Gets the input from the Sender and stores the values.

BatteryReceiverCalculator.cs - Provides the functions for all the required calculations
