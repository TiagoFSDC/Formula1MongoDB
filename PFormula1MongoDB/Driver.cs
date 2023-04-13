using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PFormula1MongoDB
{
    internal class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Notações de tipos de dados(Data notation)
        public string? Id { get; set; }

        [BsonElement("Driver")] // Serealização
        public string? Name { get; set; }

        [BsonElement("Abbreviation")]
        public string? Abbreviation { get; set; }

        [BsonElement("No")]
        [BsonRepresentation(BsonType.Int32)]
        public int Number { get; set; }

        [BsonElement("Team")]
        public string? Team { get; set; }

        [BsonElement("Country")]
        public string? Country { get; set; }

        [BsonElement("Date of Birth")]
        public string? BirthDate { get; set; }

        [BsonElement("Numero de vitorias")]
        public int Numvitorias { get; set; }

        public Driver(string? name, string? abbreviation, int number, string? team, string? country, string? birthDate,int numvitorias)
        {
            Name = name;
            Abbreviation = abbreviation;
            Number = number;
            Team = team;
            Country = country;
            BirthDate = birthDate;
            Numvitorias = numvitorias;
        }

        public override string ToString()
        {
            return $"Nome : {Name} \nAbreviação : {Abbreviation} \nNumero do carro: {Number}" +
                $"\nEquipe: {Team}\nPaís de Origem: {Country}\nData de nascimento : {BirthDate}\n";
        }
    }
}
