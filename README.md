# xScreen  -  Captures screenshots automatically


## Features
* capture screenshots automatically
* configurate the cycle in which the screenshots should be captured
* **portable**, no installation
* image formats: **jpeg**, **png**, **bmp** and more
* **skip similar images** (optional, similarity adjustable)
* adjustable image quality
* write the current timestamp on the image (optional)
* **save in ZIP packages** (optional)
	* with optional password
	* split in parts (part size is configurable)
	* one ZIP per day (optional)
* autostart with windows (optional)
* writes a logfile
## Screenshots
![home_mainform](https://user-images.githubusercontent.com/26574474/32983857-d4d5b332-cc9b-11e7-9bd7-6412aaf4cef5.png)
![home_configform](https://user-images.githubusercontent.com/26574474/32983858-d4f23764-cc9b-11e7-8724-3af2168f8869.png)
## Requirements
* .NET framework 4.5
## How to install
* No installation is required. Just make sure that the _Ionic.Zip.dll_ is located in the same directory as the _xScreen.exe_.
## Features ideas
* Option: capture only acivated window
* Option: suppress capturing, if certain window is activated (configurable)
* Option: suppress capturing, if certain processes are running (configurable)
* Event based screenshots (like: activated window changed)
* **Do you have feature ideas?**
## Changelog
* 1.6.0 - 2017-11-21
	* Migrated to github
* 1.5.4(a) - 2016-08-31
	* bugfix: sometimes the user configuration got lost
* 1.5.3 - 2016-08-07
	* Log image similarity in logfile as %
* 1.5.2 - 2016-07-30
	* user configuration doesn't get lost when a new version is released
* 1.5.1 - 2016-07-29
	* first public release
* 1.5 - 2016-07-22
	* detailed logging
	* info form
	* open last screenshot via mouse click
	* Button: open logfile
* 1.4 - 2016-07-21
	* timestamp now in Universal Sortable Format
	* configuration is logged
* 1.3 - 2016-07-06
	* New feature: Write timestamp on screenshot
	* icon remove from context menu quit
* 1.2 - 2016-07-05
	* New feature: Silent mode (no error message boxes
	* Global logging
* 1.1 - 2016-02-18
	* Check for similar images is faster
	* Last taken screen is disposed => the application requires less RAM
* 1.0 - 2016-02-17
	* first version with version history
	* New feature: New ZIP file per day
