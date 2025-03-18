using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace AromaCafeServer {
    internal static class Program {
        static void Main(string[] args) {
            using (ServiceHost host = new ServiceHost(typeof(AromaCafeService.ServiceImplementation))) {
                host.Open();
                Console.WriteLine("Servidor iniciado");
                Console.ReadLine();
            }
        }
    }
}
