using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Units;

namespace ConsoleDeTests
{
    public class Entity
    {
        public int ID { get; set; }
    }
    public class Specie : Entity
    {
        public string Name { get; set; }

        //itis ?
        public int TSNID { get; set; }

        public List<Book> ReferenceBooks { get; set; }
        public List<URL> ReferenceURLS { get; set; }

        public List<Picture> Pictures { get; set; }
    }

    public class Pet : Entity
    {
        public string Name { get; set; }
        public Specie Specie { get; set; }

        public List<Measure> Measures { get; set; }

        public List<Picture> Pictures { get; set; }

        public List<JournalEntry> Journal { get; set; }
    }

    public class Measure : Entity
    {
        public Pet Pet { get; set; }
        public MeasureTypes MeasureType { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1:g} : {2} {3}", Pet.Name, Date, Value, MeasureType);
        }
    }

    public enum MeasureTypes // parametrage : table avec enum/nom (dans les != langues) ?? )) ou resource comme pour 
    {
        Undefined = 0,
        Mass = 1,
        Length = 2,
        Acceleration = 10,
        AmplitudeRatio = 11,
        Angle = 12,
        Area = 13,
        Density = 14,
        Duration = 15,
        ElectricCurrent = 16,
        ElectricPotential = 17,
        ElectricResistance = 18,
        Energy = 19,
        Flow = 20,
        Force = 21,
        Frequency = 22,
        Information = 23,
        KinematicViscosity = 25,
        Level = 26,
        Power = 27,
        PowerRatio = 28,
        Pressure = 29,
        Ratio = 30,
        RotationalSpeed = 31,
        SpecificWeight = 32,
        Speed = 33,
        Temperature = 34,
        Torque = 35,
        Volume = 36
    }

    public class Picture : Entity
    {
        public string Name { get; set; }
        public string Caption { get; set; }
    }

    public class JournalEntry : Entity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }

    public class Book : Entity
    {
        public string Title { get; set; }

        public string Summary { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
    public class URL : Entity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public UrlTypes URLType { get; set; }

    }


    public enum UrlTypes
    {
        Default = 0,
        Amazon = 1 // si utilisé -> traitement spécial en fonction du pays de l'user, et du referid
    }

    public class Config
    {

        public string AmazonReferID { get; set; }
    }
}
