namespace VizibicikliKolcsonzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat
            StreamReader sr = new StreamReader("kolcsonzesek.txt");
            List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Kolcsonzes kolcsonzes = new Kolcsonzes();
                kolcsonzes.Name = sor[0];
                kolcsonzes.VehiclePlate = sor[1][0];
                kolcsonzes.StartHour = int.Parse(sor[2]);
                kolcsonzes.StartMinute = int.Parse(sor[3]);
                kolcsonzes.EndHour = int.Parse(sor[4]);
                kolcsonzes.EndMinute = int.Parse(sor[5]);
                kolcsonzesek.Add(kolcsonzes);
            }
            sr.Close();

            //foreach (var item in kolcsonzesek)
            //{
            //    Console.WriteLine(item.Name);
            //}

            // 5. feladat
            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {kolcsonzesek.Count}");

            // 6. feladat
            Console.Write("6. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine();
            Console.WriteLine($"\t{nev} köncsönzései:");
            bool volt = false;
            foreach (var item in kolcsonzesek)
            {
                if (item.Name == nev)
                {
                    Console.WriteLine($"\t{item.StartHour}:{item.StartMinute} - {item.EndHour}:{item.EndMinute}");
                    volt = true;
                }
            }
            if (!volt)
            {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
            }

            // 7. feladat
            Console.Write("7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            string[] idopont = Console.ReadLine().Split(':');
            int ora = int.Parse(idopont[0]);
            int perc = int.Parse(idopont[1]);
            Console.WriteLine("\tA vízen lévő járművek:");
            foreach (var item in kolcsonzesek)
            {
                if (((item.StartHour <= ora && item.EndHour >= ora) && (item.StartMinute <= perc && item.EndMinute >= perc)) || ((item.StartHour <= ora && item.EndHour >= ora) && (item.StartMinute <= perc && item.EndMinute <= perc)) || ((item.StartHour <= ora && item.EndHour <= ora) && (item.StartMinute <= perc && item.EndMinute >= perc)))
                {
                    Console.WriteLine($"\t{item.StartHour}:{item.StartMinute}-{item.EndHour}:{item.EndMinute} : {item.Name}");
                }
            }

            // 8. feladat
            int income = 0;
            foreach (var item in kolcsonzesek)
            {
                //calculate the time in minutes
                int time = (item.EndHour - item.StartHour) * 60 + (item.EndMinute - item.StartMinute);
                //calculate the price
                income += (time / 30) * 2400;
            }
            Console.WriteLine("8. feladat: A nap bevétele: " + income + " Ft");

            // 9. feladat
            StreamWriter sw = new StreamWriter("F.txt");
            foreach (var item in kolcsonzesek)
            {
                if (item.VehiclePlate == 'F')
                {
                    sw.WriteLine($"{item.StartHour}:{item.StartMinute}-{item.EndHour}:{item.EndMinute} : {item.Name}");
                }
            }
            sw.Close();

            // 10. feladat
            Console.WriteLine("10. feladat: Statisztika");
            int[] stat = new int[10];
            foreach (var item in kolcsonzesek)
            {
                stat[item.VehiclePlate - 'A']++;
            }
            for (int i = 0; i < stat.Length; i++)
            {
                Console.WriteLine($"\t{(char)(i + 'A')} - {stat[i]}");
            }

            //52:26 a 40 p helyett
        }
    }
}