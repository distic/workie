Copyright (c) 2018 Distic. All rights reserved.


Last reviewed:				 14/April/2019
Authored by:				 Ahmad Chatila

-----------------------------------------------------------------------------------

File => kestrel-WorkieWebAdmin.service
	- Needs to be placed in "/etc/systemd/system/" directory on a Linux system.

File => httpd.conf
	- Needs to be placed in "/etc/httpd/conf.d/" directory on a Linux system.


-==-==-==-==-==-==-=
-== KNOWN ISSUES ==-
-==-==-==-==-==-==-=

1) Httpd on some Linux installations might encounter file permission problem
	while reading the custom config file in /etc/httpd/conf/httpd.conf. 

2) By default, especially when testing the web app in a virtual machine, apache
	might not serve the website because of blocked outbound connections.


-==-==-==-==-==-==-=
-==  WORKAROUNDS ==-
-==-==-==-==-==-==-=

1) First, 'cd' to /etc/httpd/conf.d and open the file using the 'vi' tool. Then,
	save the file in the same directory with a suffix '-tmp'. Finally, delete the old
	conf file and rename the new file again without the '-tmp' suffix.

2) Open the terminal and type '/usr/sbin/setsebool -P httpd_can_network_connect 1'