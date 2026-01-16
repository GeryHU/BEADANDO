namespace electromosautok
{
    public class Auto
    {
        string marka;
        string model;
        string sae;
        int sebesseg;
        string szenzorok;
        string gps;
        int vezevoiBeav;
        string vezetesiMod;

        public string Marka { get => marka; set => marka = value; }
        public string SAE { get => sae; set => sae = value; }
        public int Sebesseg { get => sebesseg; set => sebesseg = value; }
        public string Szenzorok { get => szenzorok; set => szenzorok = value; }
        public string Gps { get => gps; set => gps = value; }
        public int VezevoiBeav { get => vezevoiBeav; set => vezevoiBeav = value; }
        public string VezetesiMod { get => vezetesiMod; set => vezetesiMod = value; }
        public string Model { get => model; set => model = value; }

        public Auto(string sr)
        {
            string[] adatok = sr.Split("; ");
            string[] markaModel = adatok[0].Split(' ');
            Marka = markaModel[0];
            Model = markaModel[1];
            if (markaModel.Length > 2)Model += " " + markaModel[2];
            SAE = adatok[1];
            Sebesseg = Convert.ToInt32(adatok[2]);
            Szenzorok = adatok[3];
            gps = adatok[4];
            VezevoiBeav = Convert.ToInt32(adatok[5]);
            VezetesiMod = adatok[6];
        }
        override public string ToString()
        {
            return $"Marka:" + Marka +" - "+ Model  + "\n\t SAE szint: " + SAE + "\n\t Sebbesség: " + Sebesseg + "\n\t Szenzorok: " + Szenzorok + "\n\t GPS: " + gps + "\n\t Vezezői beavatkozás: " + VezevoiBeav + "\n\t Vezetési mód: " + VezetesiMod;
        }
        public string NagyBetu()
        {
            return marka.ToUpper()+" "+model.ToUpper();
        }
    }

}
