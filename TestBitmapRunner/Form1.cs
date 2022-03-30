namespace TestBitmapRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ToolTip hoverdata = new ToolTip();
        private bool Generated = false;
        private TerrainGenerator Generator;

        private void button1_Click(object sender, EventArgs e)
        {
            Generator.Generate();
            Generated = true;
            pictureBox1.Image = Generator.BiomeImage;
            pictureBox2.Image = Generator.ElevationImage;
            pictureBox3.Image = Generator.TemperatureImage;
            pictureBox4.Image = Generator.RainfallImage;
            lblStats.Text = $"Temperature Min/Avg/Max:\n{Generator.MinimumTemperature}/{Generator.AverageTemperature}/{Generator.MaximumTemperature}";
            lblStats.Text += $"\nRainfall Min/Avg/Max:\n{Generator.MinimumRainfall}/{Generator.AverageRainfall}/{Generator.MaximumRainfall}";
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Generated) return;
            Point mousePos = e.Location;
            Bitmap b = (Bitmap)(sender as PictureBox).Image;
            Color c = b.GetPixel(mousePos.X, mousePos.Y);
            hoverdata.Show(c.ToString(), this, mousePos);
        }

        private void pictureBox_Biome_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Generated) return;
            Point mousePos = e.Location;
            //Bitmap b = Generator.BiomeImage;
            //Color c = b.GetPixel(mousePos.X, mousePos.Y);
            Biome r = Generator.BiomeAt(mousePos.X, mousePos.Y);

            hoverdata.Show($"{Enum.GetName(typeof(Biome), r)} Heat: {Generator.GetHeatRankString(Generator.HeatAt(mousePos.X, mousePos.Y))} Rain: {Generator.GetRainRankString(Generator.RainAt(mousePos.X, mousePos.Y))}", this, mousePos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Generator = new TerrainGenerator(512, 512);
            //seaLevelTrackBar.DataBindings.Add("Value", Generator.biomeOptions.SeaLevel,"Value");
            //tundraTempTrackBar.DataBindings.Add("Value", Generator.biomeOptions.TundraTemp, "Value");
            //desertRainfallTrackBar.DataBindings.Add("Value", Generator.biomeOptions.DesertRainfall, "Value");
            heatFreqTrackBar.DataBindings.Add("Value", Generator.heatOptions.Frequency, "Value");
            heatOctivesTrackBar.DataBindings.Add("Value", Generator.heatOptions.Octaves, "Value");
            heatMaxHTrackBar.DataBindings.Add("Value", Generator.heatOptions.MaxHeight, "Value");
            heatMinHTrackBar.DataBindings.Add("Value", Generator.heatOptions.MinHeight, "Value");
            rainFreqTrackBar.DataBindings.Add("Value", Generator.rainOptions.Frequency, "Value");
            rainOctaveTrackBar.DataBindings.Add("Value", Generator.rainOptions.Octaves, "Value");
            rainMaxHTrackBar.DataBindings.Add("Value", Generator.rainOptions.MaxHeight, "Value");
            rainMinHTrackBar.DataBindings.Add("Value", Generator.rainOptions.MinHeight, "Value");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Generator.RemapBiomes();
            //pictureBox1.Image = Generator.BiomeImage;
        }
    }
}