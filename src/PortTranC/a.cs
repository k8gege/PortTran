using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

internal class a
{
    public static NetworkStream a = null;

    private static void a(string[] A_0)
    {
        if (A_0.Length != 4)
        {
            Console.WriteLine("PortTran by K8gege");
            Console.WriteLine("usage: PortTranC.exe TragetIP TargetPort VpsIP TranPort");
        }
        else
        {
            try
            {
                string str = A_0[0];
                int num = int.Parse(A_0[1]);
                string str2 = A_0[2];
                int num2 = int.Parse(A_0[3]);
                Console.WriteLine(string.Concat(new object[] { "[+] Make a Connection to ", str2, ":", num2, "..." }));
                b(str, num, str2, num2);
                a(str, num, str2, num2);
                WaitHandle.WaitAll(new ManualResetEvent[] { new ManualResetEvent(false) });
            }
            catch
            {
            }
        }
    }

    public static void a(object A_0)
    {
        TcpClient client = ((TcpClient[]) A_0)[0];
        TcpClient client2 = ((TcpClient[]) A_0)[1];
        NetworkStream stream = client.GetStream();
        NetworkStream stream2 = client2.GetStream();
        while (true)
        {
            try
            {
                byte[] buffer = new byte[0x2800];
                int count = stream.Read(buffer, 0, buffer.Length);
                stream2.Write(buffer, 0, count);
            }
            catch
            {
                stream.Dispose();
                stream2.Dispose();
                client.Close();
                client2.Close();
                return;
            }
        }
    }

    public static void a(string A_0, int A_1, string A_2, int A_3)
    {
        while (true)
        {
            byte[] buffer = new byte[4];
            a.Read(buffer, 0, buffer.Length);
            TcpClient client = new TcpClient(A_2, A_3);
            TcpClient client2 = new TcpClient(A_0, A_1);
            client.SendTimeout = 0x493e0;
            client.ReceiveTimeout = 0x493e0;
            client2.SendTimeout = 0x493e0;
            client2.ReceiveTimeout = 0x493e0;
            client.GetStream().Write(buffer, 0, buffer.Length);
            object state = new TcpClient[] { client, client2 };
            object obj3 = new TcpClient[] { client2, client };
            ThreadPool.QueueUserWorkItem(new WaitCallback(a.a), state);
            ThreadPool.QueueUserWorkItem(new WaitCallback(a.a), obj3);
        }
    }

    private static void b(string A_0, int A_1, string A_2, int A_3)
    {
        a = new TcpClient(A_2, A_3).GetStream();
        byte[] bytes = Encoding.Default.GetBytes("ok");
        a.Write(bytes, 0, bytes.Length);
    }
}

