using Common;
using SecurityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Server
{
    public class SecurityServer : IServerTimer
    {
         public static int secondsCounter = 0;
         public static int counter = 0;
         public int provera= 1;

         public static System.Timers.Timer mojTimer = new System.Timers.Timer(1000);


        //[PrincipalPermission(SecurityAction.Demand, Role = "StartStop")]
        public void pokreniTimer()
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string userName = Formatter.ParseName(principal.Identity.Name);



            if (Thread.CurrentPrincipal.IsInRole("StartStop"))
            {
                mojTimer.Start();
                mojTimer.Enabled = true;
                Console.WriteLine("Tajmer je pokrenut!\n");

                if (provera == 1)
                {
                    mojTimer.Elapsed += mojTimer_Elapsed;
                    provera++;
                }
                try
                {
                    Audit.PokreniTimerUspesno(userName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Klijent {0} nema permisiju za akciju pokreni tajmer!\n", userName);
            }
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "StartStop")]
        public void zaustaviTimer()
        {

            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string userName = Formatter.ParseName(principal.Identity.Name);
            if(Thread.CurrentPrincipal.IsInRole("StartStop"))
            {
                mojTimer.Stop();
                mojTimer.Enabled = false;
                mojTimer.Elapsed -= mojTimer_Elapsed;
                Console.WriteLine("Tajmer je zaustavljen!\n");
                try
                {
                    Audit.ZaustaviTimerUspesno(userName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Klijent {0} nema permisiju za akciju zaustavi tajmer!\n", userName);
            }    
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Change")]
        public void ponistiTimer()
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string userName = Formatter.ParseName(principal.Identity.Name);
            if (Thread.CurrentPrincipal.IsInRole("Change"))
            {
                secondsCounter = 0;
                mojTimer.Stop();
                mojTimer.Enabled = false;
                mojTimer.Elapsed -= mojTimer_Elapsed;
                Console.WriteLine("Tajmer je ponisten!\n");
            }
            else
            {
                Console.WriteLine("Klijent {0} nema permisiju za akciju ponisti tajmer!\n", userName);
            }
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Change")]   //ovde treva da sifrujemo Des kriptografskim algoritmom u CBC modu
        public void postaviTimer(int i)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string userName = Formatter.ParseName(principal.Identity.Name);
            if (Thread.CurrentPrincipal.IsInRole("Change"))
            {
                counter = i;
                Console.WriteLine("Tajmer je postavljen na vrednost: " + counter);
            }
            else
            {
                Console.WriteLine("Klijent {0} nema permisiju za akciju postavi tajmer!\n", userName);
            }
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "See")]
        public int ocitajTimer()
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string userName = Formatter.ParseName(principal.Identity.Name);
            if (Thread.CurrentPrincipal.IsInRole("See"))
            {
                Console.WriteLine("Tajmer je ocitan!\n");
                return secondsCounter;
            }
            else
            {
                Console.WriteLine("Klijent {0} nema permisiju za akciju ocitaj tajmer!\n", userName);
                return 0;
            }
        }

        private static void mojTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            secondsCounter++;
            Console.WriteLine(secondsCounter + " Seconds");

            if (secondsCounter == counter)
            {
                mojTimer.Stop();
                mojTimer.Enabled = false;
                mojTimer.Elapsed -= mojTimer_Elapsed;

                secondsCounter = 0;
                Console.WriteLine("Tajmer je istekao!\n");
            }            
        }
    }
}
