Dropzonejs Demo
==============

Full Demo for dropzonejs

This demo provides step by step workdown for implementing dropzonejs in ASP.NET MVC 5.

STEPS FOR IMPLEMENTING DROPZONE.JS
==
1.	Create ASP.NET MVC Project with the option empty or internet.
2.	Add dropzonejs using nugget package manager.
3.	Copy the following files to your project in their respective directories.
    a.	HomeController.cs in Controllers folder
    b.	ImageStoreModel.cs in Models folder
    c.	Index.cshtml in Home folder of Views folder
    d.	Upload.cshtml in Home folder of Views folder
4.	Add the following lines in root Web.config of <system.web> and <system.webServer> respectively.
    a.	<httpRuntime targetFramework="4.5" maxRequestLength="1048576" />
    b.	<security>
         <requestFiltering>
          <requestLimits maxAllowedContentLength="1073741824" />
      	 </requestFiltering>
        </security>

DESCRIPTION OF STEPS
===

AUTHORS
==
Development and documentation done by Bibek Maharjan

CONTRIBUTORS
==
Bugs, fixes and other feedbacks will be taken positively.

REFERENCES
==
Dropzonejs: www.dropzonejs.com

LICENSE
==
Copyright (c) 2014 Prolific IT Solutions

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


