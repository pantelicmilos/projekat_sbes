using IServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Client
{
    public class Program
    {
        public static int secondsCounter = 0;
        public static Timer mojTimer = new Timer(1000);
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/Server";



            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;


            ChannelFactory<IServerTimer> factory = new ChannelFactory<IServerTimer>(binding, address);
            IServerTimer kanal;

            //Console.WriteLine("Korisnik koji je pokrenuo servera :" + WindowsIdentity.GetCurrent().Name);


            mojTimer.Elapsed += mojTimer_Elapsed;
            mojTimer.Enabled = true;
            mojTimer.AutoReset = true;
            mojTimer.Start();




            while (true)
            {
                Console.WriteLine("radi!!\n");
                kanal = factory.CreateChannel();

                kanal.pokreniTimer(3);

                Console.ReadLine();
            }

        }

        private static void mojTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            secondsCounter++;
            Console.WriteLine(secondsCounter + " Seconds");
        }
    }
}
