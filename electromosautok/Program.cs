namespace electromosautok
{
    public class Program{
        static List<Auto> autok = new List<Auto>();

        public static void Main(string[] args){

            using (StreamReader sr = new StreamReader("autok.txt"))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Auto auto = new Auto(sor);
                    autok.Add(auto);
                }
            }

            Console.WriteLine("fl05");
            Console.WriteLine($"\tAutók száma: {autok.Count}");
            Console.WriteLine("fl16:");
            foreach (Auto auto in autok)
            {
                Console.WriteLine("\t"+auto.ToString());
            }
            List<Auto> f07 = autok.Where(a => a.SAE == "félautomatikus" && a.VezetesiMod == "manuális").ToList();
            Console.WriteLine("fl07: ");
            if (f07.Count == 0)
            {
                Console.WriteLine("\tNincs Ilyen autó!");
            }
            else
            {
                Console.WriteLine($"\tFélautomatikus manuális módban: {f07.Count}");
            }
            Auto fl08 = autok.Where(x => x.VezevoiBeav == autok.Max(x => x.VezevoiBeav)).ToList().First();
            Console.WriteLine($"fl08:\n\t A legkevésbé önálló autó:\n\t{fl08.ToString()}");
            Console.WriteLine($"fl09:\n\t{autok.Select(x => x.Gps.Split('|').First()).Min()} A legkissebb x irányú koordináta");
            Console.WriteLine("fl10: Márkák:");
            string[] fl10 = autok.Select(x => x.Marka).Distinct().OrderBy(x => x).ToArray();
            if (fl10.Length == 0)
            {
                Console.WriteLine("\tNincs ilyen márka!");
            }
            else
            {
                foreach (string marka in fl10)
                {
                    Console.WriteLine("\t"+marka);
                }
            }
            Console.WriteLine("fl11: 85-95 km/h és legalább 3 szenzorral rendelkező autók:");
            int[] fl11 = autok.Where(x => x.Sebesseg >= 85 && x.Sebesseg <= 95 && x.Szenzorok.Split(',').Length >= 3).Select(x => autok.IndexOf(x) + 1).ToArray();
            foreach (int i in fl11)
            {
                Console.WriteLine($"\tAzonosító: {i}");
            }

            using (StreamWriter sw = new StreamWriter("./autok_SAE.txt"))/*Linux allat nem tudom tökéletesen tesztelni, nálam működik :D*/
            {
                foreach (Auto auto in autok)
                {
                    sw.WriteLine($"{auto.NagyBetu()};{auto.SAE}");
                }
            }
        }
    }
}
