## Web Solutions

All of the web solutions are missing /wwwroot/lib/*.  The file */libman.json* contains the list of files that need to be downloaded. 

Occassionally, the online library directory structure changes slightly.  After restoring the libraries, check the references in *_Layout.cshtml* and update if needed.


### Visual Studio

You can restore the client-side libraries by right clicking on the libman.json file and selecting "Restore Client-Side Libraries".

Lightbulbs while edition libman.json will suggest updated versions.

### Visual Studio Code

Use the command line interface to restore the client-side libraries.
*install the tool*
```bash
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

*restore the libraries*
```bash
libman restore
```