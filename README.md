# Log4NetSetup
A setup project for log4net.

## Config
`logging.config` contains all of the settings for the `Logging` project.  The `logging.config` file is set to always be copied to the output directory via properties.

`AssemblyInfo.cs`

```c#
// Add this line to AssemblyInfo.cs
// to set log4net to use this as its
// config file.
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "logging.config", Watch = true)]
```
