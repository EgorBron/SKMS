using System;
using System.Net.Sockets;
using System.Text;
using PDK.Connections;

namespace DESPDKExamples2 {
    // Custom TCP handler
    public class OurSockProc : BaseTcpProcessor {
        public OurSockProc(string ip, int port) : base(ip, port) { }
        // When client connects, Process method calls in external thread.
        public override void Process(TcpClient client) {
            try {
                var stream = client.GetStream();
                while (true) {
                    if (!client.Connected) {
                        Console.WriteLine("Connection closed");
                        break;
                    }
                    while (!stream.DataAvailable) ; // do nothing and wait

                    byte[] bytes = new byte[client.Available];

                    stream.Read(bytes, 0, bytes.Length);

                    string recv = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine(recv);
                }
            } catch (Exception) { }
        }
    }
}
