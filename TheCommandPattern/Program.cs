using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommandPattern
{
    // Command interface
    public interface INaredba
    {
       void Izvrši();
    }

    // Concrete commands
    public class NaredbaKreni : INaredba
    {
        private Vlak vlak;

        public NaredbaKreni(Vlak vlak)
        {
            this.vlak = vlak;
        }

        public void Izvrši()
        {
            vlak.kreni();
        }
    }

    public class NaredbaStani : INaredba
    {
        private Vlak vlak;

        public NaredbaStani(Vlak vlak)
        {
            this.vlak = vlak;
        }

        public void Izvrši()
        {
            vlak.stani();
        }
    }

    // Receiver
    public class Vlak
    {
        private bool kretanje;
        
        public void kreni()
        {
            if (!kretanje)
            {
                kretanje = true;
                Console.WriteLine("Krenuo sam.\n");
            }
            else Console.WriteLine("Već se krećem!\n");
        }
        public void stani()
        {
            if (kretanje)
            {
                kretanje = false;
                Console.WriteLine("Stao sam.\n");
            }
            else Console.WriteLine("Već stojim!\n");
        }
    }

    // Invoker
    public class DaljinskiUpravljač
    {
        private INaredba naredba;       // ili List<INaredba>

        public void stisniGumb(INaredba odabranaNaredba)
        {
            naredba = odabranaNaredba;
            naredba.Izvrši();
            //dodaj u listu naredbi
        }
    }


    // Client (GUI or CLI)
    class Klijent
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tKlijentski program - Obrazac naredbe\n");
            Console.WriteLine("Naredbe vlaku : kreni, stani ili E za kraj.\n");

            Vlak vlak = new Vlak();
            DaljinskiUpravljač daljinski = new DaljinskiUpravljač();
            
            while (true)
            {
                Console.Write("Unesi naredbu : ");
                string unos = Console.ReadLine();
                

                if (unos.Equals("E")) break;

                else if (unos.ToLower()=="kreni" || unos.ToLower()=="k")
                {
                    daljinski.stisniGumb(new NaredbaKreni(vlak));
                }
                else if (unos.ToLower() == "stani" || unos.ToLower() == "s")
                {
                    daljinski.stisniGumb(new NaredbaStani(vlak));
                }
                else Console.WriteLine("Nepoznata naredba.\n");
            }
        }
    }





}
