PortTran by k8gege<br>
.NET端口转发工具 支持任意权限<br> 

0x001 VPS监听<br>
PortTranS.exe 8000 338<br>
<img src=https://github.com/k8gege/PortTran/blob/master/img/vps.PNG></img><br>
0x002 目标端口转发<br>
PortTranC.exe 192.168.85.169 3389 192.168.85.142 8000<br>
<img src=https://github.com/k8gege/PortTran/blob/master/img/target.PNG></img><br>

0x003 VPS连接3389<br>
mstsc /console /v:127.0.0.1:338<br>
<img src=https://github.com/k8gege/PortTran/blob/master/img/3389.PNG></img><br>
