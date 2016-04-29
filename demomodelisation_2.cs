 public class foo
    {
        public void bar()
        {
            SpecieInfo specie = new SpecieInfo
            {
                Id = 1,
                Name = "Lapin Angora",
                Info = "Le lapin angora est un rongeur de fils",
                AverageLongevity = 3,
                MaxLongevity = 5,
                AverageAdultWeight = 2,
                MaxAdultWeight = 4,
                MinHabitatSize = 2,
                RecommendedHabitatSize = 20,
                InitialMaterialCost = 70,
                AnnualMaterialCost = 15,
                MonthlyElectricityCost = 0.5m,
                MonthlyFoodCost = 5,
                DailyAttentionSpanInMinutes = 10,

            };
        }
    }

    public class SpecieInfoConfig
    {
        public SpecieInfo SpecieConfig { get; set; }

        public Unit RecommendedHabitatSize { get; set; }
        public Unit AverageLongevity { get; set; }
        public Unit MaxLongevity { get; set; }
        public Unit AverageAdultWeight { get; set; }
        public Unit MaxAdultWeight { get; set; }
        public Unit MinHabitatSize { get; set; }
        public Unit RecommendedHabitatSize { get; set; }
        public Unit InitialMaterialCost { get; set; }
        public Unit AnnualMaterialCost { get; set; }
        public Unit MonthlyElectricityCost { get; set; }
        public Unit MonthlyFoodCost { get; set; }
        public Unit DailyAttentionSpanInMinutes { get; set; }
    }

    public class SpecieInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public decimal AverageLongevity { get; set; }
        public decimal MaxLongevity { get; set; }
        public decimal AverageAdultSize { get; set; }
        public decimal MaxAdultSize { get; set; }
        public decimal AverageAdultWeight { get; set; }
        public decimal MaxAdultWeight { get; set; }
        public decimal MinHabitatSize { get; set; }
        public decimal RecommendedHabitatSize { get; set; }
        public decimal InitialMaterialCost { get; set; }
        public decimal AnnualMaterialCost { get; set; }
        public decimal MonthlyElectricityCost { get; set; }
        public decimal MonthlyFoodCost { get; set; }
        public decimal DailyAttentionSpanInMinutes { get; set; }


    }

    public class Unit
    {
        public string Name { get; set; }
    }
