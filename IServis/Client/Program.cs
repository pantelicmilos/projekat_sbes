using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Client
{
    public class Program
    {
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


            int b, c;

            while (true)
            {
                kanal = factory.CreateChannel();

                Console.WriteLine(" 1.POKRENI TAJMER\n 2.ZAUSTAVI TAJMER\n 3.PONISTI TAJMER\n 4.POSTAVI TAJMER\n 5.OCITAJ TAJMER\n Izaberite neku od ponudjenih opcija:");
                string a = Console.ReadLine();
                b = int.Parse(a);


                switch (b)
                {
                    case 1:
                        Console.WriteLine("Opcija 1\n");
                        kanal.pokreniTimer();
                        break;
                    case 2:
                        Console.WriteLine("Opcija 2\n");
                        kanal.zaustaviTimer();
                        break;
                    case 3:
                        Console.WriteLine("Opcija 3\n");
                        kanal.ponistiTimer();
                        break;
                    case 4:
                        Console.WriteLine("Opcija 4\n");
                        Console.WriteLine("Na koju vrednost zelite da postavite tajmer: \n");
                        c = int.Parse(Console.ReadLine());
                        kanal.postaviTimer(c);
                        break;
                    case 5:
                        Console.WriteLine("Opcija 5\n");
                        int d = kanal.ocitajTimer();
                        Console.WriteLine("Tajmer je na: " + d + " sekundi.\n");
                        break;
                    default:
                        break;


                }

            }

        }

  
    }
}
