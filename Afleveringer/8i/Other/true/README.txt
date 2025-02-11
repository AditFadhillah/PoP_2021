Hvordan man oversætter og kører koden:
	- Unzip mappen (handin.zip)
	- Gå ind på terminalen
	- Navigere til den unzippet mappe (handin/) på terminalen
	- Navigere til mappen (src/) på terminalen
	- Taste (fsharpc -a img_util.fsi img_util.fs) på terminalen, 
	  for at lave en (img_util.dll) fil

	- (!!!) Hvis det ikke virker kopiere den her kommando ind på terminalen: 
	fsharpc --nologo -I "c:/Program Files (x86)/Mono/lib/gtk-sharp-2.0" -r gdk-sharp.dll -r gtk-sharp.dll -a img_util.fsi img_util.fs
	
 	- (img_util.dll) filen bruges til at køre 8i0.fsx filen
	- For at køre 8i0.fsx taste (fsharpc -r img_util.dll 8i0.fsx)
	- Taste derefter (mono 8i0.exe) på terminalen 

