# KML_Player
Quick example of how to play real time or historical data in Google Earth.

This is a C# application reading a log file generated from my Yuneec Drone. It then updates a KML file that Google Earth is reading at 1Hz. 
The flight log is recording at about 25Hz so messages are being purposly skipped to make it closer to actual flight time.

You can run this application from Visual Studio 2017 or greater. Or you can try and run the 'Kml_Player.exe' Here are the steps to run in Google Earth.

1. Install Google Earth Pro for your desktop. I don't think this will work with the online version. 
2. Find the GoogleEarthStartup_Path.kml and the GoogleEarthStartup_Point.kml files in this project. They will be under the '..KML_Player\bin\Debug\KML' directory. Be sure to select the ones under the bin directory because this is where the KML file will be written. 
3. Open the GoogleEarthStartup_Path.kml and the GoogleEarthStartup_Point.kml in Google Earth
4. Ensure that Google Earth has a green link. This means that it has found the files referenced in the GoogleEarthStartup_Path.kml and the GoogleEarthStartup_Point.kml files.
5. Launch the KML_Player.exe or debug from VS.
6. Open the flight log file 'Telemetry_00079.csv'. This should be in the '...\KML_Player\bin\Debug\Data' directory.
7. Select 'Play'
8. Switch back to the Google Earth and double click on the GoogleEarthStartup_Point.kml. This should snap you to the flight log data.

From this point you should be able to see 1Hz update rates in Google Earth and the path that the vehcile has traveled. 
