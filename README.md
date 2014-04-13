Dropzonejs Demo
==============

Full Demo for dropzonejs

This demo provides step by step workdown for implementing dropzonejs in ASP.NET MVC 5.

Summary
==

1.	Project setup
    - Create ASP.NET MVC 5 project
2.	Dropzonejs minimal setup
    -   Upload files
    -   Display files
    -   Delete files
3.  Dropzonejs optimal setup
4.  Dropzonejs extensive setup

Description
===

## Project setup

### Create ASP.NET MVC 5 project

1. Create ASP.NET MVC 5 Project with the option empty or internet.

    -	Open Visual Studio
    -	Select File => New => Project
    -	Select Web => ASP.NET MVC Application
    -	Give project Name DropzoneDemo
    -	Click Ok
    -	Select Empty project Template
    -	Select Razor as view engine.
    -	Click Ok.

## Dropzonejs minimal setup

1.	Add dropzonejs using nugget package manager.
    -	Right Click Solution
    -	Select Manage Nuget Package For Solutions …
    -	Select Online in the Nuget Package Manager and search for Dropzonejs
    -	Install Dropzonejs created by MatiasMeno
    -	Select the projects and click Ok
    -	Close Nuget Package Manager

2.	Add Contoller
    -	Right Click Controllers
    -	Select Add => Controller
    -	Name Controller as HomeController
    -	Select Empty MVC controller Template
    -	Click Add

3.	Add View
    -	Open HomeController.cs
    -	Right Click on View()
    -	Click Add View
    -	Leave everything default (View Name: Index, View engine: Razor, Create a strongly-typed view: unchecked, Create as a partial view: unchecked, Use a layout or master: checked)
    -	Click Add
    -   Add Reference<br/>
Add reference to basic.css, dropzone.css and dropzone.min.js. jquery-{version}.min.js can be added if needed. But, dropzonejs can be implemented without jquery.

&lt;link href="~/Scripts/dropzone/css/basic.css" rel="stylesheet" /&gt;<br/>
&lt;link href="~/Scripts/dropzone/css/dropzone.css" rel="stylesheet" /&gt;<br/>
&lt;script src="~/Scripts/dropzone/dropzone.min.js"&gt;&lt;/script&gt;<br/>
&gt;script src="~/Scripts/jquery-2.1.0.min.js"&gt;&lt;/script&gt;<br/>

-   Add form using Html Helper and set Action: Upload, Controller: Home, Method: Post, Enctype: “multipart/form-data”, class: dropzone and id: dropzoneForm
-   Action Upload will be created in the HomeController in a while. Id can be anything. But, class name should be dropzone for dropzonejs to work. Also, enctype = “multipart/form-data” for uploading larger files to the server.

<code>
@using (Html.BeginForm("Upload", "Home", FormMethod.Post, <br/>
new {enctype = "multipart/form-data", @class = "dropzone", id = "dropzoneForm"}))<br/>
{<br/>
<br/>
}<br/>
</code>

For supporting fallback, add the following code inside the form tag. In old browsers, the old school file upload will be shown. Dropzonejs can work without this tag but won’t support old browsers.

&lt;div class="fallback"&gt;
&lt;input name="file" type="file" multiple /&gt;
&lt;/div>

This minimal setting should get dropzonejs to upload the file. Oops! Error. Upload action yet to be created.

### Upload files (Upload action (HomeController.aspx))

Create Upload action in the HomeController

<code>
    [HttpPost]<br/>
    public ActionResult Upload()<br/>
    {<br/>
        //Loop through the HttpFileCollection to get the keys (names) of the files<br/>
        foreach (string fileName in Request.Files)<br/>
        {<br/>
            //Use the key (filename) to get the HttpPostedFileBase object<br/>
            HttpPostedFileBase file = Request.Files[fileName];<br/>
    
            //Check for the null reference i.e file is not null and content length is greater than zero
            if (file != null && file.ContentLength > 0)
            {
                //Give the directory name where the file will be uploaded
                string path = Server.MapPath("/UploadImages/");
    
                //Check if the directory exists
                if(!Directory.Exists(path))
                    //Create the diretory
                    Directory.CreateDirectory(path);
    
                //Get the name of the file being uploaded
                string fName = file.FileName;
    
                //Create full path combining path and fileName
                string fullPath = Path.Combine(path + fName.ToString());
    
                //Save the file
                file.SaveAs(fullPath);
            }
            
        }
        //Return null for remaining in the same page
        return null;
    }
</code>

Now, the file can be uploaded to the server folder. This time the file gets automatically uploaded as soon as the file browser dialog closes.

### Display files
### Delete files
## Dropzonejs optimal setup
## Dropzonejs extensive setup

Authors
==
Development and documentation done by Bibek Maharjan

Contributors
==
Bugs, fixes and other feedbacks will be taken positively.

References
==
1. [Dropzonejs] (http://www.dropzonejs.com/ "dropzonejs link")

License
==
Copyright (c) 2014 Prolific IT Solutions

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


