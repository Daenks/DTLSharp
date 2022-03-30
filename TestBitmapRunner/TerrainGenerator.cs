namespace TestBitmapRunner
{
    class TerrainGenerator
    {
        //Input
        private int size_x = 512;
        private int size_y = 512;
        public BiomeConfiguration biomeOptions { get; set; }
        public PerlinConfiguration heatOptions { get; set; }
        public PerlinConfiguration rainOptions { get; set; }

        //Generated
        private int[,] temperature;
        private int[,] rainfall;
        private int[,] elevation;
        
        //Computed
        private int[,] biome;
        
        public TerrainGenerator(int width, int height)
        {
            size_x = width; size_y = height;
            temperature = new int[size_x, size_y];
            rainfall = new int[size_x, size_y];
            elevation = new int[size_x, size_y];
            biome = new int[size_x, size_y];
            biomeOptions = new BiomeConfiguration();
            heatOptions = new PerlinConfiguration();
            rainOptions = new PerlinConfiguration();
        }

        public TerrainGenerator()
        {
            temperature = new int[size_x, size_y];
            rainfall = new int[size_x, size_y];
            elevation = new int[size_x, size_y];
            biome = new int[size_x, size_y];
            biomeOptions = new BiomeConfiguration();
            heatOptions = new PerlinConfiguration(3d, 8, 20, 60);
            rainOptions = new PerlinConfiguration(3d, 8, 0, 60);
        }

        public void Generate()
        {
            //Elevation
            double truncated_proporiton = 0.5f;
            double mountain_proportion = 0.5f;
            double frequency = 5.0f;
            uint octaves = 7;
            int max_height = 200;
            GenerateElevation(truncated_proporiton, mountain_proportion, frequency, octaves, max_height);

            //Temperature
            GenerateTemperatures(
                frequency: heatOptions.Frequency.Value,
                (uint)heatOptions.Octaves.Value,
                heatOptions.MaxHeight.Value,
                heatOptions.MinHeight.Value);

            //Precipitation
            GeneratePrecipitation(
                frequency: rainOptions.Frequency.Value,
                (uint)rainOptions.Octaves.Value,
                rainOptions.MaxHeight.Value,
                rainOptions.MinHeight.Value);
            
            //Biome
            ComputeBiomes();
        }

        public void GenerateDefault()
        {
            //Elevation
            double truncated_proporiton = 0.5f;
            double mountain_proportion = 0.5f;
            double frequency = 5.0f;
            uint octaves = 7;
            int max_height = 200;
            GenerateElevation(truncated_proporiton, mountain_proportion, frequency, octaves, max_height);

            //Temperature
            GenerateTemperatures(frequency: 3d, 8, 20, 60);

            //Precipitation
            GeneratePrecipitation(frequency: 3d, 8, 0, 60);

            //Biome
            ComputeBiomes();
        }

        private void GenerateElevation(double truncated_proporiton, double mountain_proportion, double frequency, uint octaves, int max_height)
        {
            new DTL.Shape.PerlinSolitaryIsland(truncated_proporiton, mountain_proportion, frequency, octaves, max_height).Draw(elevation);
        }

        private void GenerateTemperatures(double frequency, uint octaves, int maxHeight, int minHeight)
        {
            new DTL.Shape.PerlinIsland(frequency: frequency, octaves, maxHeight, minHeight).Draw(temperature);
            //Adjust temperature based on altitude, higher == colder
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                    temperature[row, col] -= (int)((elevation[row, col] - 100.0f) * 0.3f);
        }

        private void GeneratePrecipitation(double frequency, uint octaves, int maxHeight, int minHeight)
        {
            new DTL.Shape.PerlinIsland(frequency: frequency, octaves, maxHeight, minHeight).Draw(rainfall);
            //TODO:Adjust Rainfall by altitude too?? Makes sense, right???
        }

        private void ComputeBiomes()
        {
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                {

                    //Classify each point into 8 ranks of humidity
                    int rainfall = this.rainfall[row, col];
                    int rainrank = GetRainRank(rainfall);

                    //Classify each point into 6 ranks based on 0-130
                    int heat = temperature[row, col];
                    int heatrank = GetHeatRank(heat);

                    if (rainrank == 1) //Super-Arid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.SuperArid_Tropical_Desert;
                        if (heatrank == 2) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 3) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 4) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 5) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 6) biome[row, col] = (int)Biome.NullBiome;
                    }
                    if (rainrank == 2) //Per-Arid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.PerArid_Tropical_DesertScrub;
                        if (heatrank == 2) biome[row, col] = (int)Biome.PerArid_Subtropical_Desert;
                        if (heatrank == 3) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 4) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 5) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 6) biome[row, col] = (int)Biome.NullBiome;
                    }
                    if (rainrank == 3) //Arid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.Arid_Tropical_ThornWoodland;
                        if (heatrank == 2) biome[row, col] = (int)Biome.Arid_Subtropical_DesertScrub;
                        if (heatrank == 3) biome[row, col] = (int)Biome.Arid_CoolTeperate_Desert;
                        if (heatrank == 4) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 5) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 6) biome[row, col] = (int)Biome.NullBiome;
                    }
                    if (rainrank == 4) //Semi-Arid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.SemiArid_Tropical_VeryDryForest;
                        if (heatrank == 2) biome[row, col] = (int)Biome.SemiArid_Subtropical_ThornSteppeWoodland;
                        if (heatrank == 3) biome[row, col] = (int)Biome.SemiArid_CooolTemperate_DesertScrub;
                        if (heatrank == 4) biome[row, col] = (int)Biome.SemiArid_Boreal_Desert;
                        if (heatrank == 5) biome[row, col] = (int)Biome.NullBiome;
                        if (heatrank == 6) biome[row, col] = (int)Biome.NullBiome;
                    }
                    if (rainrank == 5) //Sub-Humid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.SubHumid_Tropical_DryForest;
                        if (heatrank == 2) biome[row, col] = (int)Biome.SubHumid_Subtropical_DryForest;
                        if (heatrank == 3) biome[row, col] = (int)Biome.SubHumid_CoolTempearate_Steppe;
                        if (heatrank == 4) biome[row, col] = (int)Biome.SubHumid_Boreal_DryScrub;
                        if (heatrank == 5) biome[row, col] = (int)Biome.SubHumid_SubPolar_DryTundra;
                        if (heatrank == 6) biome[row, col] = (int)Biome.NullBiome;
                    }
                    if (rainrank == 6) //Humid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.Humid_Tropical_MoistForest;
                        if (heatrank == 2) biome[row, col] = (int)Biome.Humid_Subtropical_MoistForest;
                        if (heatrank == 3) biome[row, col] = (int)Biome.Humid_CoolTemperate_MoistForest;
                        if (heatrank == 4) biome[row, col] = (int)Biome.Humid_Boreal_MoistForest;
                        if (heatrank == 5) biome[row, col] = (int)Biome.Humid_SubPolar_MoistTundra;
                        if (heatrank == 6) biome[row, col] = (int)Biome.Humid_Polar_Desert;
                    }
                    if (rainrank == 7) //Per-Humid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.PerHumid_Tropical_WetForest;
                        if (heatrank == 2) biome[row, col] = (int)Biome.PerHumid_Subtropical_WetForest;
                        if (heatrank == 3) biome[row, col] = (int)Biome.PerHumid_CoolTemperate_WetForest;
                        if (heatrank == 4) biome[row, col] = (int)Biome.PerHumid_Boreal_WetForest;
                        if (heatrank == 5) biome[row, col] = (int)Biome.PerHumid_SubPolar_WetTundra;
                        if (heatrank == 6) biome[row, col] = (int)Biome.PerHumid_Polar_Desert;
                    }
                    if (rainrank == 8) //Super-Humid
                    {
                        if (heatrank == 1) biome[row, col] = (int)Biome.SuperHumid_Tropical_RainForest;
                        if (heatrank == 2) biome[row, col] = (int)Biome.SuperHumid_Subtropical_RainForest;
                        if (heatrank == 3) biome[row, col] = (int)Biome.SuperHumid_CoolTempearate_RainForest;
                        if (heatrank == 4) biome[row, col] = (int)Biome.SuperHumid_Boreal_RainForest;
                        if (heatrank == 5) biome[row, col] = (int)Biome.SuperHumid_SubPolar_RainTundra;
                        if (heatrank == 6) biome[row, col] = (int)Biome.SuperHumid_Polar_Desert;
                    }
                    //SeaLevel
                    if (elevation[row, col] < biomeOptions.SeaLevel.Value) biome[row, col] = 0;
                }

        }

        private void BiomeSelector()
        {
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                {
                    //Sea
                    if (elevation[row, col] < biomeOptions.SeaLevel.Value) biome[row, col] = 0;

                    //Tundra
                    else if (temperature[row, col] < biomeOptions.TundraTemp.Value) biome[row, col] = 1;

                    //Desert
                    else if (rainfall[row, col] < biomeOptions.DesertRainfall.Value) biome[row, col] = 2;

                    else if (rainfall[row, col] < 80)
                    {
                        //Steppe
                        if (temperature[row, col] < biomeOptions.SteppeTemp.Value) biome[row, col] = 3;
                        //Savannah
                        else biome[row, col] = 4;
                    }
                    //Coniferous forest
                    else if (temperature[row, col] < 3) biome[row, col] = 5;
                    //Temperate deciduous forest
                    else if (temperature[row, col] < 12) biome[row, col] = 6;
                    //Laurel forest
                    else if (temperature[row, col] < 20) biome[row, col] = 7;
                    //Rainy green forest
                    else if (rainfall[row, col] < 2500) biome[row, col] = 8;
                    //Subtropical Rainforest
                    else if (temperature[row, col] < 24.0f) biome[row, col] = 9;
                    //Tropical Rainforest
                    else biome[row, col] = 10;
                }
        }

        //Old BiomeColorizer
        //private Color BiomeColorizer(int biome)
        //{
        //    switch (biome)
        //    {
        //        case 0: //Sea
        //            return Color.FromArgb(41, 50, 159);

        //        case 1: //Tundra
        //            return Color.FromArgb(218, 217, 225);

        //        case 2: //Desert
        //            return Color.FromArgb(223, 203, 104);

        //        case 3: //Steppe
        //            return Color.FromArgb(188, 205, 146);

        //        case 4: //Savanna
        //            return Color.FromArgb(164, 143, 50);

        //        case 5: //ConForest
        //            return Color.FromArgb(97, 154, 96);

        //        case 6: //LaurelForest
        //            return Color.FromArgb(101, 163, 56);

        //        case 7: //LaurelForest
        //            return Color.FromArgb(9, 100, 5);
        //        case 8: //RainyGreenForest
        //        case 9: //SubTropRainForest
        //        case 10: //TropRainForest
        //            return Color.FromArgb(43, 84, 41);
        //        default:
        //            return Color.Black;
        //    }
        //}

        private Color BiomeColorizer(Biome b)
        {
            switch (b)
            {
                //8 Tropical Zones
                case Biome.SuperArid_Tropical_Desert:
                    return Color.FromArgb(255,255,128);
                case Biome.PerArid_Tropical_DesertScrub:
                    return Color.FromArgb(224, 255, 128);
                case Biome.Arid_Tropical_ThornWoodland:
                    return Color.FromArgb(192, 255, 128);
                case Biome.SemiArid_Tropical_VeryDryForest:
                    return Color.FromArgb(160, 255, 128);
                case Biome.SubHumid_Tropical_DryForest:
                    return Color.FromArgb(128, 255, 128);
                case Biome.Humid_Tropical_MoistForest:
                    return Color.FromArgb(96, 255, 128);
                case Biome.PerHumid_Tropical_WetForest:
                    return Color.FromArgb(64, 255, 144);
                case Biome.SuperHumid_Tropical_RainForest:
                    return Color.FromArgb(32, 255, 160);

                //7 Subtropical Zones
                case Biome.PerArid_Subtropical_Desert:
                    return Color.FromArgb(224, 224, 128);
                case Biome.Arid_Subtropical_DesertScrub:
                    return Color.FromArgb(192, 224, 128);
                case Biome.SemiArid_Subtropical_ThornSteppeWoodland:
                    return Color.FromArgb(160, 224, 128);
                case Biome.SubHumid_Subtropical_DryForest:
                    return Color.FromArgb(128, 224, 128);
                case Biome.Humid_Subtropical_MoistForest:
                    return Color.FromArgb(96, 224, 128);
                case Biome.PerHumid_Subtropical_WetForest:
                    return Color.FromArgb(64, 224, 144);
                case Biome.SuperHumid_Subtropical_RainForest:
                    return Color.FromArgb(32, 224, 192);

                //6 Cool Temperate Zones
                case Biome.Arid_CoolTeperate_Desert:
                    return Color.FromArgb(224, 224, 128);
                case Biome.SemiArid_CooolTemperate_DesertScrub:
                    return Color.FromArgb(192, 224, 128);
                case Biome.SubHumid_CoolTempearate_Steppe:
                    return Color.FromArgb(160, 224, 128);
                case Biome.Humid_CoolTemperate_MoistForest:
                    return Color.FromArgb(128, 224, 128);
                case Biome.PerHumid_CoolTemperate_WetForest:
                    return Color.FromArgb(96, 224, 128);
                case Biome.SuperHumid_CoolTempearate_RainForest:
                    return Color.FromArgb(64, 224, 144);

                //5 Boreal Zones
                case Biome.SemiArid_Boreal_Desert:
                    return Color.FromArgb(224, 224, 128);
                case Biome.SubHumid_Boreal_DryScrub:
                    return Color.FromArgb(192, 224, 128);
                case Biome.Humid_Boreal_MoistForest:
                    return Color.FromArgb(160, 224, 128);
                case Biome.PerHumid_Boreal_WetForest:
                    return Color.FromArgb(128, 224, 128);
                case Biome.SuperHumid_Boreal_RainForest:
                    return Color.FromArgb(96, 224, 128);

                //4 Subpolar Zones
                case Biome.SubHumid_SubPolar_DryTundra:
                    return Color.FromArgb(224, 224, 128);
                case Biome.Humid_SubPolar_MoistTundra:
                    return Color.FromArgb(192, 224, 128);
                case Biome.PerHumid_SubPolar_WetTundra:
                    return Color.FromArgb(160, 224, 128);
                case Biome.SuperHumid_SubPolar_RainTundra:
                    return Color.FromArgb(128, 224, 128);

                //3 Polar Zones
                case Biome.Humid_Polar_Desert:
                    return Color.FromArgb(224, 224, 128);
                case Biome.PerHumid_Polar_Desert:
                    return Color.FromArgb(192, 224, 128);
                case Biome.SuperHumid_Polar_Desert:
                    return Color.FromArgb(160, 224, 128);

                case Biome.Sea:
                    return Color.FromArgb(41, 50, 159);

                case Biome.NullBiome:
                default:
                    return Color.Black;
            }
        }

        private Color BlueValueColorizer(int elevation)
        {
            if (elevation > 255) elevation = 255;
            return Color.FromArgb(0, 0, elevation);
        }

        private Color RedValueColorizer(int elevation)
        {
            if (elevation > 255) elevation = 255;
            return Color.FromArgb(elevation, 0, 0);
        }

        private Color GreenValueColorizer(int elevation)
        {
            if (elevation > 255) elevation = 255;
            return Color.FromArgb(0, elevation, 0);
        }

        private Bitmap FromMatrix(int[,] matrix, Func<int, Color> colorizer)
        {
            Bitmap bOut = new Bitmap(size_x, size_y);
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                {
                    bOut.SetPixel(row, col, colorizer(matrix[row, col]));
                }
            return bOut;
        }

        private Bitmap FromMatrix(int[,] matrix, Func<Biome, Color> colorizer)
        {
            Bitmap bOut = new Bitmap(size_x, size_y);
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                {
                    bOut.SetPixel(row, col, colorizer((Biome)matrix[row, col]));
                }
            return bOut;
        }

        public Biome BiomeAt(int x, int y) { return (Biome)biome[x, y]; }

        public int HeatAt(int x, int y) { return temperature[x, y]; }

        public int RainAt(int x, int y) { return rainfall[x, y]; }

        public int GetHeatRank(int temp)
        {
            int temprank = 0;
            if (temp <= 42) temprank = 6;
            else if (temp <= 85) temprank = 5;
            else if (temp <= 127) temprank = 4;
            else if (temp <= 170) temprank = 3;
            else if (temp <= 212) temprank = 2;
            else if (temp <= 255) temprank = 1;
            return temprank;
        }

        public int GetRainRank(int rainfall)
        {
            int rainrank = 0;
            if (rainfall <= 32) rainrank = 1; //Super-Arid
            else if (rainfall <= 64) rainrank = 2; //Per-Arid
            else if (rainfall <= 96) rainrank = 3; //Arid
            else if (rainfall <= 127) rainrank = 4; //Semi-Arid
            else if (rainfall <= 159) rainrank = 5; //Sub-Humid
            else if (rainfall <= 191) rainrank = 6; //Humid
            else if (rainfall <= 223) rainrank = 7; //Per-Humid
            else if (rainfall <= 255) rainrank = 8; //Super-Humid
            return rainrank;
        }

        public string GetHeatRankString(int temp)
        {
            int iRank = GetHeatRank(temp);
            return Enum.GetName(typeof(HeatRank), iRank);
        }

        public string GetRainRankString(int rainfall)
        {
            int iRank = GetRainRank(rainfall);
            return Enum.GetName(typeof(RainRank), iRank);
        }

        public Bitmap BiomeImage { get { return FromMatrix(biome, BiomeColorizer); } }

        public Bitmap ElevationImage { get { return FromMatrix(elevation, GreenValueColorizer); } }

        public Bitmap RainfallImage { get { return FromMatrix(rainfall, BlueValueColorizer); } }

        public Bitmap TemperatureImage { get { return FromMatrix(temperature, RedValueColorizer); } }

        #region Statistics
        private double MatrixAverage(int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                    sum += matrix[row, col];
            return sum / matrix.Length;
        }
        private int MatrixMinimum(int[,] matrix)
        {
            int min = int.MaxValue;
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                    if (matrix[row, col] < min) min = matrix[row, col];
            return min;
        }
        private int MatrixMaximum(int[,] matrix)
        {
            int max = 0;
            for (int row = 0; row < size_x; row++)
                for (int col = 0; col < size_y; col++)
                    if (matrix[row, col] > max) max = matrix[row, col];
            return max;
        }

        public double AverageTemperature { get { return MatrixAverage(temperature); } }
        public double AverageRainfall { get { return MatrixAverage(rainfall); } }
        public double AverageElevation { get { return MatrixAverage(elevation); } }

        public int MaximumTemperature { get { return MatrixMaximum(temperature); } }
        public int MaximumRainfall { get { return MatrixMaximum(rainfall); } }
        public int MaximumElevation { get { return MatrixMaximum(elevation); } }

        public int MinimumTemperature { get { return MatrixMinimum(temperature); } }
        public int MinimumRainfall { get { return MatrixMinimum(rainfall); } }
        public int MinimumElevation { get { return MatrixMinimum(elevation); } }
        #endregion
    }
}

enum HeatRank
{
    Tropical = 1,
    Subtropical = 2,
    CoolTemperate = 3,
    Boreal = 4,
    Subpolar = 5,
    Polar = 6
}

enum RainRank
{
    SuperArid = 1,
    PerArid = 2,
    Arid = 3,
    SemiArid = 4,
    SubHumid = 5,
    Humid = 6,
    PerHumid = 7,
    SuperHumid = 8
}

enum Biome
{
    Sea = 0,
    
    SuperArid_Tropical_Desert,
    PerArid_Tropical_DesertScrub,
    Arid_Tropical_ThornWoodland,
    SemiArid_Tropical_VeryDryForest,
    SubHumid_Tropical_DryForest,
    Humid_Tropical_MoistForest,
    PerHumid_Tropical_WetForest,
    SuperHumid_Tropical_RainForest,

    PerArid_Subtropical_Desert,
    Arid_Subtropical_DesertScrub,
    SemiArid_Subtropical_ThornSteppeWoodland,
    SubHumid_Subtropical_DryForest,
    Humid_Subtropical_MoistForest,
    PerHumid_Subtropical_WetForest,
    SuperHumid_Subtropical_RainForest,

    Arid_CoolTeperate_Desert,
    SemiArid_CooolTemperate_DesertScrub,
    SubHumid_CoolTempearate_Steppe,
    Humid_CoolTemperate_MoistForest,
    PerHumid_CoolTemperate_WetForest,
    SuperHumid_CoolTempearate_RainForest,

    SemiArid_Boreal_Desert,
    SubHumid_Boreal_DryScrub,
    Humid_Boreal_MoistForest,
    PerHumid_Boreal_WetForest,
    SuperHumid_Boreal_RainForest,

    SubHumid_SubPolar_DryTundra,
    Humid_SubPolar_MoistTundra,
    PerHumid_SubPolar_WetTundra,
    SuperHumid_SubPolar_RainTundra,

    Humid_Polar_Desert,
    PerHumid_Polar_Desert,
    SuperHumid_Polar_Desert,

    NullBiome = 255
}