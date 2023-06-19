1. In Program.cs file in roadApp directory,Please update your AppId and Appkey for API call at line 36 and 37 (String myAppId = ""; String myAppKey = "";)

2. After updating the keys, build the code with updated changes using the command "dotnet build" in the roadApp root directory.

3. Navigate to roadApp\bin\Debug\net6.0 and open the command prompt in the path. And execute the newly built app with commands below
	a.roadApp\bin\Debug\net6.0> "roadApp.exe A2"   For a valid road
	b.roadApp\bin\Debug\net6.0> "roadApp.exe A500" For a Invalid road
	c.roadApp\bin\Debug\net6.0> "roadApp.exe" For a no input error handling.

