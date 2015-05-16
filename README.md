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
The follow has been added to the `Logging` project's post-build event:
```batch
REM "$(SolutionDir)OutputLibrary\Logging"
IF NOT EXIST "$(SolutionDir)OutputLibrary\Logging" mkdir "$(SolutionDir)OutputLibrary\Logging"
if $(ConfigurationName) == Release copy "$(TargetDir)$(TargetFileName)" "$(SolutionDir)OutputLibrary\Logging\$(TargetFileName)"
if $(ConfigurationName) == Release copy "$(TargetDir)log4net.dll" "$(SolutionDir)OutputLibrary\Logging\log4net.dll"
if $(ConfigurationName) == Release copy "$(TargetDir)log4net.config" "$(SolutionDir)OutputLibrary\Logging\logging.config"
```