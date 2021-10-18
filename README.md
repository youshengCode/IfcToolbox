<p align="center">
  <img width="128" align="center" src="https://bimmars.com/wp-content/uploads/2021/09/IfcToolbox_Applogo.png">
</p>
<h1 align="center">
  IFC Toolbox
</h1>
<p align="center">
  Simple tools for processing IFC files.
</p>
<p align="center">
  <a style="text-decoration:none" href="https://www.microsoft.com/en-us/p/ifc-toolbox/9n77phd2h471#activetab=pivot:overviewtab">
    <img src="https://img.shields.io/badge/Microsoft%20Store-Download-blue" alt="Store link" />
  </a>
  <a style="text-decoration:none">
    <img src="https://img.shields.io/badge/Latest%20Version-1.1.9.0-brightgreen" alt="Version" />
  </a>
  <a style="text-decoration:none" href="https://bimmars.com">
    <img src="https://img.shields.io/badge/More%20Info-BIM Mars-red" alt="More" />
  </a>
</p>





IfcToolbox is a **.Net** kit of simple tools for processing IFC files. It provides tools to optimize, convert, split, relocate and anonymize IFC files easily. Based on open-source libraries like [Xbim](https://docs.xbim.net/) and [IfcOpenShell](http://ifcopenshell.org/). 

IfcToolbox is one of the proposals in [openBIM Marketplace - buildingSMART Technical](https://technical.buildingsmart.org/misc/openbim-marketplace/). Thank you all for ❤️ IFC Toolbox and bring IFC Toolbox to buildingSMART International Summit 2021. 

## Tools in the box

- IFC Optimizer – Reduce the size of large IFC files by optimizing the IFC resource layer instance, and eliminate floating-point offsets through FPR geometric optimization.
- IFC Converter – Easily convert IFC to OBJ(.obj), Collada(.dae), STEP(.stp), IGES(.igs), XML(.xml) and SVG(.svg).
- IFC Splitter – Split IFC files by type/container (site, building, level) or simply split selected objects in the hierarchy.
- IFC Relocator – Relocate the IFC world coordinate system and the project coordinate system. Align the origin of the two models.
- IFC Anonymizer – Anonymous user-related information and specific product-related information. Simplify model submission in bidding activities or design competitions.

## GUI App in Microsoft Store 

There is also a GUI version desktop app, which contains all the implementations of these tools. The IfcToolbox App is **designed for No-Code users and to provide a better user experience.**

**[Download IFC Toolbox from Microsoft Store](https://www.microsoft.com/en-us/p/ifc-toolbox/9n77phd2h471#activetab=pivot:overviewtab)**

### Videos

IFC Toolbox is part of [OSArch](https://osarch.org/) Community, you can find more technical details in our monthly meetup recording here

- [IFC Toolbox - OSArch MonthlyMeetup #18 - YouTube](https://www.youtube.com/watch?v=UIzos3MJF3c&list=PLeQc3-WBIZnPGdBduq9PsqjOZIMo4yTE5)

For quick intro of IFC Toolbox you can found this short video for [Speckle Connect! 2021](https://speckle.systems/blog/connect/)

- [IFC Toolbox in 5mins - Connect! 2021 - IFC Toolbox (Yousheng Wang) - YouTube](https://www.youtube.com/watch?v=ctOM7cfJDO0)

And [Javad Hamidi](https://www.linkedin.com/in/javad-hamidi-8086a7150/) from our community made this first tuto video for IFC Toolbox

- [How to Edit IFC Files - IFCToolbox - Best IFC Editor - YouTube](https://www.youtube.com/watch?v=iwL_e6LAOQk)

### Screenshots

<p align="center">
  <img align="center" src="https://bimmars.com/wp-content/uploads/2021/09/StoreHeroImage2k.png">
</p>
<p align="center">
  <img align="center" src="https://bimmars.com/wp-content/uploads/2021/09/PostOptimizer_2k.png">
</p>
<p align="center">
  <img align="center" src="https://bimmars.com/wp-content/uploads/2021/09/PostSplitter_2k.png">
</p>
<p align="center">
  <img align="center" src="https://bimmars.com/wp-content/uploads/2021/09/PostConverter_2k.png">
</p>


IFC Toolbox GUI App is a free software, if you like my work, please consider:

- Star this project on GitHub
- Leave me a review in Microsoft Store
- [Sponsor me on GitHub Sponsors](https://github.com/sponsors/youshengCode)

## Source code projects

- IfcToolbox.Core - Lower extension for IFC processing.
- IfcToolbox.Tools - Higher implementation for each tool in IfcToolbox. 
- IfcToolbox.Test - Unit tests with xUnit for Core and Tools.
- IfcToolbox.Examples - .Net core console app for tools example.

[Documentation of IFC Toolbox](https://youshengcode.github.io/IfcToolbox.Doc/#/)

## Third Party Licences

- Xbim.Essentials https://docs.xbim.net/ - [CDDL License](https://docs.xbim.net/license/license.html)
- IfcOpenShell http://ifcopenshell.org/ - [LGPL-3.0 License](https://github.com/IfcOpenShell/IfcOpenShell/blob/v0.6.0/COPYING)
- MoreLINQ https://morelinq.github.io/ - [Apache-2.0 License](https://licenses.nuget.org/Apache-2.0)
- RestSharp https://restsharp.dev/ - [Apache-2.0 License](https://licenses.nuget.org/Apache-2.0)
- Serilog https://serilog.net/ - [Apache-2.0 License](https://licenses.nuget.org/Apache-2.0)
- Newtonsoft.Json https://www.newtonsoft.com/json - [MIT Licence](https://licenses.nuget.org/MIT)

## License

[GPL-3.0 License](https://github.com/youshengCode/IfcToolbox/blob/master/LICENSE) © 2021 [Yousheng Wang](https://github.com/youshengCode)
