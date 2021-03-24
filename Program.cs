using System;
using System.IO;
using System.Net;

namespace FtpDemo
{
    class Program
    {

        public static bool ReadFileInServer()
        {
            string host = "ftp://127.0.0.1";
            string UserId = "testuser";
            string Password = "testuser";
            string path = "/hello_world.txt";
            bool IsCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(host + path);
                request.Credentials = new NetworkCredential(UserId, Password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Stream responseStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    Console.WriteLine(reader.ReadToEnd());
                    Console.WriteLine(resp.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                IsCreated = false;
            }
            return IsCreated;
        }

        static void Main(string[] args)
        {
            bool res = ReadFileInServer();
            Console.WriteLine(res);
        }
    }
}
