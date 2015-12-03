using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDeTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet p = new Pet
            {
                ID = 0,
                Name = "test",
                Specie = new Specie
                {
                    ID = 0,
                    Name = "stest"
                },
                Measures = new List<Measure>()
            };

            p.Measures.Add(new Measure
            {
                ID = 0,
                Pet = p,
                MeasureType = MeasureTypes.Mass,
                Date = DateTime.UtcNow,
                Value = 1.985
            });

            p.Measures.Add(new Measure
            {
                ID = 1,
                Pet = p,
                MeasureType = MeasureTypes.Length,
                Date = DateTime.UtcNow,
                Value = 0.21 //meters

            });

            // test
            p.Measures.Add(new Measure
            {
                ID = 2,
                Pet = p,
                MeasureType = MeasureTypes.Power,
                Date = DateTime.UtcNow,
                Value = 90000
            });

            foreach (var m in p.Measures)
            {

                Console.WriteLine(new string('-', 40));
                Console.WriteLine(m.ToString());
                Console.WriteLine("raw val {0}", m.Value);

                switch (m.MeasureType)
                {
                    case MeasureTypes.Mass:
                        {
                            ShowMass(m);
                        } break;
                    case MeasureTypes.Length:
                        {
                            ShowLength(m);
                        } break;
                    case MeasureTypes.Power:
                        {
                            ShowPower(m);
                        } break;
                    default:
                        {
                            Console.WriteLine("non implementé");
                        } break;
                }
            }

            Console.WriteLine("fini");
            Console.ReadLine();
        }

        private static void ShowPower(Measure m)
        {
            Console.WriteLine("Power ");

            UnitsNet.Power pow = new UnitsNet.Power(Convert.ToDecimal(m.Value));
            Console.WriteLine("Watts : {0} m", pow.Watts);
            Console.WriteLine("ElectricalHorsepower : {0} ", pow.ElectricalHorsepower);
            Console.WriteLine("BoilerHorsepower : {0} ", pow.BoilerHorsepower);
            Console.WriteLine("HydraulicHorsepower : {0} ", pow.HydraulicHorsepower);
            Console.WriteLine("MechanicalHorsepower : {0} ", pow.MechanicalHorsepower);
        }

        private static void ShowLength(Measure m)
        {
            Console.WriteLine("Longueur ");

            UnitsNet.Length len = new UnitsNet.Length(m.Value);
            Console.WriteLine("length : {0} m", len.Meters);
            Console.WriteLine("length : {0} cm", len.Centimeters);
            Console.WriteLine("length : {0} mm", len.Millimeters);
            Console.WriteLine("length : {0} km", len.Kilometers);

            Console.WriteLine("length : {0} feet", len.Feet);
            Console.WriteLine("length : {0} inches", len.Inches);
            Console.WriteLine("length : {0} miles", len.Miles);
            Console.WriteLine("length : {0} yards", len.Yards);

            Console.WriteLine("length : {0} Microinches", len.Microinches);
            Console.WriteLine("length : {0} Mils", len.Mils);
            Console.WriteLine("length : {0} Nanometers", len.Nanometers);

            Console.WriteLine(len.ToString());
        }

        private static void ShowMass(Measure m)
        {
            Console.WriteLine("Masse ");

            UnitsNet.Mass mass = new UnitsNet.Mass(m.Value);
            Console.WriteLine("mass : {0} kg", mass.Kilograms);
            Console.WriteLine("mass : {0} g", mass.Grams);
            Console.WriteLine("mass : {0} mg", mass.Milligrams);
            Console.WriteLine("mass : {0} T", mass.Tonnes);

            Console.WriteLine("mass : {0} Pounds", mass.Pounds);
            Console.WriteLine("mass : {0} Ounces", mass.Ounces);
            Console.WriteLine("mass : {0} Stones", mass.Stone);
        }
    }
}
