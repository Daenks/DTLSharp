namespace TestBitmapRunner
{
    public class BiomeConfiguration
    {
        public NotifyInt SeaLevel { get; set; }
        public NotifyInt TundraTemp { get; set; }
        public NotifyInt DesertRainfall { get; set; }
        public NotifyInt SSRainfall { get; set; }
        public NotifyInt SteppeTemp { get; set; }

        public BiomeConfiguration()
        {
            SeaLevel = new NotifyInt(90,"sealevel");
            TundraTemp = new NotifyInt(5,"tundratemp");
            DesertRainfall = new NotifyInt(60,"desertrainfall");
            SSRainfall = new NotifyInt(80,"ssrainfall");
            SteppeTemp = new NotifyInt(20,"steppetemp");
        }        
    }

    public class PerlinConfiguration
    {
        public NotifyDouble Frequency { get; set; }
        public NotifyInt Octaves { get; set; }
        public NotifyInt MaxHeight { get; set; }
        public NotifyInt MinHeight { get; set; }

        public PerlinConfiguration()
        {
            Frequency = new NotifyDouble(3d);
            Octaves = new NotifyInt(8);
            MaxHeight = new NotifyInt(255);
            MinHeight = new NotifyInt(0);
        }
        public PerlinConfiguration(double frequency, uint octaves, int maxHeight, int minHeight)
        {
            Frequency = new NotifyDouble(frequency);
            Octaves = new NotifyInt((int)octaves);
            MaxHeight = new NotifyInt(maxHeight);
            MinHeight = new NotifyInt(minHeight);
        }
    }
}