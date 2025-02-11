Hvordan man oversætter og kører koden:
	- Unzip mappen (7g_gruppe7.zip)
	- Gå ind på terminalen
	- Navigere til den unzippet mappe (7g_gruppe7/) på terminalen
	- Navigere til mappen (src/) på terminalen
	- Taste (fsharpc -a rotate.fsi rotate.fs) på terminalen, 
	  for at lave en (rotate.dll) fil
	- (rotate.dll) filen bruges til at køre en .fsx fil

Hvordan man kører white-box test:
	- Taste (fsharpc -r continuedFraction.dll whiteboxtest.fsx) på terminalen
	- Taste derefter (mono whiteboxtest.exe) på terminalen

Hvordan man kører black-box test:
	- Taste (fsharpc -r continuedFraction.dll blackboxtest.fsx) på terminalen
	- Taste derefter (mono blackboxtest.exe) på terminalen
