/**
 * TcpServer - Tcp socket server.
 * 
 * Using TcpListener server example.
 * 
 * Reference: [TcpListener](https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener?view=net-7.0)
 * 
 * License - MIT.
 */

using System;
using System.Net;
using System.Net.Sockets;


class TcpServer
{
    public static void Main()
    {
        TcpListener server = null;

        try
        {
            // Set the TcpListener on port 65532.
            Int32 port = 65532;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = string.Empty;

            // Enter the listening loop.
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");

                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                using TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = string.Empty;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("OK");

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                }
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            if (null != server)
                server.Stop();
        }

        Console.WriteLine("Server quit.\n");
    }
}
