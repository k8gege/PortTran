using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

internal class a
{
    public static Dictionary<int, TcpClient> a = new Dictionary<int, TcpClient>();
    public static NetworkStream b = null;

    private static void a(string[] A_0)
    {
        if (A_0.Length != 2)
        {
            Console.WriteLine("PortTran by k8gege");
            Console.WriteLine("usage: PortTranS.exe TranPort ConnPort");
        }
        else
        {
            string state = A_0[0];
            string str2 = A_0[1];
            Console.WriteLine("[+] Listening TranPort " + state + " ...");
            Console.WriteLine("[+] Listening ConnPort " + str2 + " ...");
            ThreadPool.QueueUserWorkItem(new WaitCallback(a.c), state);
            ThreadPool.QueueUserWorkItem(new WaitCallback(a.b), str2);
            WaitHandle.WaitAll(new ManualResetEvent[] { new ManualResetEvent(false) });
        }
    }

    public static void a(TcpClient A_0)
    {
        NetworkStream stream = A_0.GetStream();
        byte[] buffer = new byte[4];
        if (((stream.Read(buffer, 0, buffer.Length) == 2) && (buffer[0] == 0x6f)) && (buffer[1] == 0x6b))
        {
            b = stream;
            Console.WriteLine("[+] Accept Connect OK!");
            Console.WriteLine("[+] Waiting Another Client on ConnPort ...");
        }
        else
        {
            a(BitConverter.ToInt32(buffer, 0), A_0);
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
            Console.WriteLine("transferring...");
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

    public static void a(int A_0, TcpClient A_1)
    {
        TcpClient client = null;
        if (a.ContainsKey(A_0))
        {
            a.TryGetValue(A_0, out client);
            a.Remove(A_0);
            A_1.SendTimeout = 0x493e0;
            A_1.ReceiveTimeout = 0x493e0;
            client.SendTimeout = 0x493e0;
            client.ReceiveTimeout = 0x493e0;
            object state = new TcpClient[] { A_1, client };
            object obj3 = new TcpClient[] { client, A_1 };
            ThreadPool.QueueUserWorkItem(new WaitCallback(a.a), state);
            ThreadPool.QueueUserWorkItem(new WaitCallback(a.a), obj3);
        }
    }

    public static void b(object A_0)
    {
        TcpListener listener = new TcpListener(int.Parse(A_0.ToString()));
        listener.Start();
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            int key = new Random().Next(0x3b9aca00, 0x77359400);
            a.Add(key, client);
            byte[] bytes = BitConverter.GetBytes(key);
            b.Write(bytes, 0, bytes.Length);
        }
    }

    public static void c(object A_0)
    {
        TcpListener listener = new TcpListener(int.Parse(A_0.ToString()));
        listener.Start();
        while (true)
        {
            a(listener.AcceptTcpClient());
        }
    }
}

