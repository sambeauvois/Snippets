 public class foo
    {
        public void bar()
        {
            SpecieInfo specie = new SpecieInfo
            {
                Id = 1,
                Name = "Lapin Angora",
                Info = "Le lapin angora est un rongeur de fils",
                AverageLongevity = new ValueAndUnit { Value = 3, Unit = new Unit { Name = "Year" } },
                MaxLongevity = new ValueAndUnit { Value = 5, Unit = new Unit { Name = "Year" } },
                AverageAdultWeight = new ValueAndUnit { Value = 2, Unit = new Unit { Name = "kg" } },
                MaxAdultWeight = new ValueAndUnit { Value = 4, Unit = new Unit { Name = "gg" } },
                MinHabitatSize = new ValueAndUnit { Value = 2, Unit = new Unit { Name = "m²" } },
                RecommendedHabitatSize = new ValueAndUnit { Value = 20, Unit = new Unit { Name = "m²" } },
                InitialMaterialCost = new ValueAndUnit { Value = 70, Unit = new Unit { Name = "€" } },
                AnnualMaterialCost = new ValueAndUnit { Value = 15, Unit = new Unit { Name = "€" } },
                MonthlyElectricityCost = new ValueAndUnit { Value = 0.5m , Unit = new Unit { Name = "€" } },
                MonthlyFoodCost = new ValueAndUnit { Value = 5, Unit = new Unit { Name = "€" } },
                DailyAttentionSpanInMinutes = new ValueAndUnit { Value = 10, Unit = new Unit { Name = "Min" } },

            };
        }
    }

    public class SpecieInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public ValueAndUnit AverageLongevity { get; set; }
        public ValueAndUnit MaxLongevity { get; set; }
        public ValueAndUnit AverageAdultSize { get; set; }
        public ValueAndUnit MaxAdultSize { get; set; }
        public ValueAndUnit AverageAdultWeight { get; set; }
        public ValueAndUnit MaxAdultWeight { get; set; }
        public ValueAndUnit MinHabitatSize { get; set; }
        public ValueAndUnit RecommendedHabitatSize { get; set; }
        public ValueAndUnit InitialMaterialCost { get; set; }
        public ValueAndUnit AnnualMaterialCost { get; set; }
        public ValueAndUnit MonthlyElectricityCost { get; set; }

        public ValueAndUnit MonthlyFoodCost { get; set; }

        public ValueAndUnit DailyAttentionSpanInMinutes { get; set; }


    }

    public class ValueAndUnit
    {
        public decimal Value { get; set; }
        public Unit Unit { get; set; }
    }

    public class Unit
    {
        public string Name { get; set; }
    }
