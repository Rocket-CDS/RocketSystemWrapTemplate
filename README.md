# RocketSystemWrapTemplate

VS template to create a system which called another system

Example: RocketBusinessAPI

This project is used when we need to reuse code of a system with another systemkey, so we can run the same system multiple times on a webisite.  

It also offers a more understandable name when building web projects.  

**Use https://github.com/Rocket-CDS/RenameProj**

## RocketDirectoryAPI
This project is designed as a wrapper to the RocketDirectoryAPI, but it can also work for other systems if required.  
The concept is that the systemkey of the wrapper project is replaced by the systemkey of the wrapped project.  In this project it is replaced "rocketdirectoryapi" in the "StartConnect" class.  

## Wrapper System Templates

In this project there are no templates. However templates can be used to overwrite existing system templates.  
The system is designed to search for the "AppTheme Template", "System Template  (Wrapper Project)" and "RocketDirectoryAPI Template" in that order.  When it finds a template it uses that one.
```
var razorTempl = _dataObject.AppTheme.GetTemplate(templateName);
if (razorTempl == "") razorTempl = _dataObject.AppThemeSystem.GetTemplate(templateName);
if (razorTempl == "") razorTempl = _dataObject.AppThemeDirectory.GetTemplate(templateName);
return razorTempl;
```
## Razor Tokens
It is sometimes required that a wrapper system will have a special razor token.  IN these cases the razor token is included in the Razor Toekn class, "RocketSystemWrapTemplate.cs" (Renamed to the wrapper sytsem name)

The AppTheme templates can then use these tokens by the razor template inheriting the razor token class.   

## Scheduler Provider
Each wrapper system can run it's own scheduler.  If the scheduler is not required the scheudler class can be removed and the "scheduler" provider XML in system.rules file can have the active node as "false" or be deleted from the file.  


