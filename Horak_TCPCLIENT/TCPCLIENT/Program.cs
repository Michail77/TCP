using System;
using System.Net.Sockets;

namespace TCPCLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect_To_Server();
        }
        public static bool isConnected { get; set; }
        public static NetworkStream Writer { get; set; }
        public static NetworkStream Reciever { get; set; }

        public static string message;
        
        public static void Connect_To_Server()
        {
            TcpClient Connecting = new TcpClient(); string IP = "127.0.0.1"; while (isConnected == false)
            {
                try
                {
                    Console.WriteLine("Zadejte cislo od 1-10: ");
                    message = Console.ReadLine();
                    Connecting.Connect(IP, 13000);
                    isConnected = true; Writer = Connecting.GetStream(); Reciever = Connecting.GetStream(); Console.WriteLine("Connected: " + IP);

                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    //String data2 = null;

                    NetworkStream stream = Connecting.GetStream();

                    //int i;
                    //Byte[] bytes2 = new Byte[256];
                    //while ((i = stream.Read(bytes2, 0, bytes2.Length)) != 0)
                    //{
                    //    data2 = System.Text.Encoding.ASCII.GetString(bytes2, 0, i);
                    //    if (data2 == "Prohra")
                    //    {
                    //        isConnected = false;
                    //    }
                    //}

                        stream.Write(data, 0, data.Length);

                    Console.WriteLine("Sent: {0}", message);

                    data = new Byte[256];

                    String responseData = String.Empty;

                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);

                    stream.Close();
                    Connecting.Close();
                }
                catch { Console.WriteLine("Error Connection... ."); Console.Clear(); }

                Console.WriteLine("\n Press Enter to continue...");
                Console.Read();
            }
            Console.ReadKey();
        }
    }
}
    

