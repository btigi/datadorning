## Introduction

Datadorning is plugin based console application intended for printing daily information to an ESC/POS compatible printer, i.e. from a cron job or Windows Task Scheduler.

## Download

Compiled downloads are not available.

## Compiling

To clone and run this application, you'll need [Git](https://git-scm.com) and [.NET](https://dotnet.microsoft.com/) installed on your computer. From your command line:

```
# Clone this repository
$ git clone https://github.com/btigi/asciiz

# Go into the repository
$ cd src

# Build  the app
$ dotnet build
```

## Usage

> [!NOTE] 
> Edit appsettings.json and sert 'printerName' to the name of the ESC/POS compatible printer you wish to print to.


As a plugin based application, by default Datadorning has no functionality. Plugins are configured via appsettings.json, with each node accepting:
- assembly - a string representing the path to the plugin assembly file
- config - a string representing the per-plugin configuration file
- preseparator - a boolean indicating if a separator line should be printed before output from this plugin
- postseparator - a boolean indicating if a separator line should be printed after output from this plugin

The default plugins contains in the repo are:

### BankHoliday
Print information on the next Bank Holiday in England and Wales, sourced from the [UK Government website](https://www.gov.uk/bank-holidays.json). The plugin expects no config file.

### RandomLine
Print a random line from a text file. The plugin expects a JSON config file containing:
- intro - the intro text to print
- filename - the path to the text file

###  Reminders
Print reminders from a local file. The plugin expects a JSON config file containing an array of:
- Name - the name of the event
- Date - the date the event occurs e.g. 2025-01-02
- EventType - "annual" or "weekly"
- For eventType of annual, an array of notificationOffsets, containing:
    - offset - the number of days prior to the event to provide a reminder

Weekly reminders are printed on the day of the event.


###  WeatherApi
Print a summary of the weather for the next day, retrieved from [weatherapi.com](https://weatherapi.com/). The plugin expects a JSON config file containing:
- BaseAddress - the base URL of weatherapi.com, i.e. "https://api.weatherapi.com/v1/"
- ApiKey - the weatherapi.com API key
- Days - the days offset to retrieve the forecast for, e.g. 1
- Location - the location to retrieve the forecast for, e.g. London

## Build notes
The plugins contained in this repository each contain a post-build event to copy the output to the plugins folder in the Debug folder of the main application on build. If this plugins folder does not exist the post-build event will fail.

## Licencing

Datadorning is licenced under CC BY-NC-ND 4.0 https://creativecommons.org/licenses/by-nc-nd/4.0/ Full licence details are available in licence.md