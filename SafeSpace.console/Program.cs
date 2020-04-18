using SafeSpace.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeSpace.console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kiran Self Reporting
            UserService kiran = new UserService("kiran.singal@gmail.com", true, true, true, true, 15);
            UserService dheeraj = new UserService("dsingal@fsscommerce.com", true, true, true, true, 15);
            UserService kristi = new UserService("ksingal@trutsesolutions.com", true, true, true, true, 12);
            UserService rashmi = new UserService("rashmi.singal@gmail.com", true, true, true, true, 15);

            kiran.AddToContacts(dheeraj);
            kiran.AddToContacts(kristi);
            kiran.AddToContacts(rashmi);

            Console.WriteLine($"Status: {kiran.SafeStatus()}");

            Console.ReadLine();

            // Dheeraj turns yellow
            // - send alert to kiran to self quarantine
            // Dheeraj turns red
            // - send alert to kiran to self quarantine
            // Dheeraj turns green
            // - send alert to kiran all green
            // Go out - status of last person sterlized location, time of last sterlization
        }
    }
}
