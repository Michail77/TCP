using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Horak_TCP2
{
    class Program
    {
        //public static string message = "Prohra";
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int Cislo = rnd.Next(10);
            TcpListener server = null;



            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);

                server.Start();

                Byte[] bytes = new Byte[256];
                String data = null;



                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        if (Convert.ToInt32(data) == Cislo)
                        {
                            Console.WriteLine("Uhodl jsi!");
                        }
                        else
                        {
                            Console.WriteLine("PROHRAL JSI!");
                            //try
                            //{
                            //    client.Connect(localAddr, 13000);

                            //    Byte[] data2 = System.Text.Encoding.ASCII.GetBytes(message);

                            //    stream.Write(data2, 0, data2.Length);

                            //    Console.WriteLine("Sent: {0}", message);

                            //    data2 = new Byte[256];

                            //    String responseData = String.Empty;

                            //    Int32 bytes2 = stream.Read(data2, 0, data.Length);
                            //    responseData = System.Text.Encoding.ASCII.GetString(data2, 0, bytes2);
                            //    Console.WriteLine("Received: {0}", responseData);
                            //}
                            //catch { Console.WriteLine("Error Connection... ."); Console.Clear(); }
                        }
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
