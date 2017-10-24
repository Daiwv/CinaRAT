YggdrasilRAT
=========
[![Build status](https://ci.appveyor.com/api/projects/status/fu42uhll4e204cuq?svg=true)](https://ci.appveyor.com/project/wearelegal/yggdrasilrat) [![License](http://img.shields.io/badge/license-MIT-green.svg)](https://github.com/wearelegal/YggdrasilRAT/blob/master/LICENSE)

**Free, Open-Source Remote Administration Tool for Windows**

Yggdrasil is a fast and light-weight remote administration tool coded in C#. Providing high stability and an easy-to-use user interface, Yggdrasil is the perfect remote administration solution for you. This project is based on QuasarRAT.

Features
---
* TCP network stream (IPv4 & IPv6 support)
* Fast network serialization (NetSerializer)
* Compressed (QuickLZ) & Encrypted (AES-128) communication
* Multi-Threaded
* UPnP Support
* No-Ip.com Support
* Visit Website (hidden & visible)
* Show Messagebox
* Task Manager
* File Manager
* Startup Manager
* Remote Desktop
* Remote Webcam
* Remote Shell
* Download & Execute
* Upload & Execute
* System Information
* Computer Commands (Restart, Shutdown, Standby)
* Keylogger (Unicode Support)
* Reverse Proxy (SOCKS5)
* Password Recovery (Common Browsers and FTP Clients)
* Registry Editor

Requirements
---
* .NET Framework 4.0 Client Profile ([Download](https://www.microsoft.com/en-us/download/details.aspx?id=24872))
* Supported Operating Systems (32- and 64-bit)
  * Windows XP SP3
  * Windows Server 2003
  * Windows Vista
  * Windows Server 2008
  * Windows 7
  * Windows Server 2012
  * Windows 8/8.1
  * Windows 10

What need I to know?
--
  * Yggdrasil use the QuasarRAT as base, all the credits are saved.

Screenshots
--
>! [demo1](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo1.png)
>! [demo2](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo2.png)
>! [demo3](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo3.png)
>! [demo4](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo4.png)
>! [demo5](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo5.png)
>! [demo6](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo6.png)
>! [demo7](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo7.png)
>! [demo8](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo8.png)
>! [demo9](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo9.png)
>! [demo10](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo10.png)
>! [demo11](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo11.png)
>! [demo12](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo12.png)
>! [demo13](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo13.png)
>! [demo14](https://raw.githubusercontent.com/wearelegal/YggdrasilRAT/master/docs/img/demo/demo14.png)

Compiling
---
Open the project in Visual Studio and click build, or use one of the batch files included in the root directory.

| Batch file        | Description
| ----------------- |:-------------
| build-debug.bat   | Builds the application using the debug configuration (for testing)
| build-release.bat | Builds the application using the release configuration  (for publishing)

Building a client
---
| Build configuration         | Description
| ----------------------------|:-------------
| debug configuration         | The pre-defined [Settings.cs](/Client/Config/Settings.cs) will be used. The client builder does not work in this configuration. You can execute the client directly with the specified settings.
| release configuration       | Use the client builder to build your client otherwise it is going to crash.

ToDo
---
* [Open Issues](https://github.com/wearelegal/YggdrasilRAT/issues)

Contributing
---
See [CONTRIBUTING](/CONTRIBUTING.md)

License
---
See [LICENSE](/LICENSE.md)

Credits
---
Chicle (Wearelegal)

NetSerializer  
Copyright (c) 2015 Tomi Valkeinen  
https://github.com/tomba/netserializer

ResourceLib  
Copyright (c) 2008-2013 Daniel Doubrovkine, Vestris Inc.  
https://github.com/dblock/resourcelib

GlobalMouseKeyHook  
Copyright (c) 2004-2015 George Mamaladze  
https://github.com/gmamaladze/globalmousekeyhook

Mono.Cecil  
Copyright (c) 2008 - 2015 Jb Evain, Copyright (c) 2008 - 2011 Novell, Inc.  
https://github.com/jbevain/cecil

Mono.Nat  
Copyright (c) 2006 Alan McGovern, Copyright (c) 2007 Ben Motmans  
https://github.com/nterry/Mono.Nat

QuasarRAT  
Copyright (c) 2016 MaxX0r  
https://github.com/quasar/QuasarRAT/

Thank you!
---
I really appreciate all kinds of feedback and contributions. Thanks for using and supporting Yggdrasil!
