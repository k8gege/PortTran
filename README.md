PortTran by k8gege<br>
.NET端口转发工具 支持任意权限<br> 

0x001 VPS监听
PortTranS.exe 8000 338
<img src=https://github.com/k8gege/PortTran/blob/master/img/vps.PNG></img><br>
0x002 目标端口转发
PortTranC.exe 192.168.85.169 3389 192.168.85.142 8000
<img src=https://github.com/k8gege/PortTran/blob/master/img/target.PNG></img><br>

0x003 VPS连接3389
mstsc /console /v:127.0.0.1:338
<img src=https://github.com/k8gege/PortTran/blob/master/img/3389.PNG></img><br>
