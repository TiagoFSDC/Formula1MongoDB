using System.Net.WebSockets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using PFormula1MongoDB;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        var basedados = mongo.GetDatabase("Formula1");

        var collection = basedados.GetCollection<BsonDocument>("Pilotos");

        //Console.WriteLine("Informe o nome do piloto: ");
        //string n = Console.ReadLine();

        //var filtro = Builders<BsonDocument>.Filter.Regex("Driver", n);

        //var p = collection.Find(filtro).FirstOrDefault();

        //var piloto = BsonSerializer.Deserialize<Driver>(p); // Converte o arquivo Bson para Driver

        //Console.WriteLine("\n" + piloto.ToString());

        //Console.WriteLine("Nome: ");
        //string n = Console.ReadLine();

        //Console.WriteLine("Abreviação: ");
        //string a = Console.ReadLine();

        //Console.WriteLine("Numero: ");
        //int num = int.Parse(Console.ReadLine());

        //Console.WriteLine("Equipe: ");
        //string e = Console.ReadLine();

        //Console.WriteLine("Pais: ");
        //string p = Console.ReadLine();

        //Console.WriteLine("Data de nascimento: ");
        //string d = Console.ReadLine();

        //Console.WriteLine("Numero de Vitorias: ");
        //int vitorias = int.Parse(Console.ReadLine());

        //Driver driver = new(n, a, num, e, p, d, vitorias);

        //Console.WriteLine(driver.ToString());

        //var dr = new BsonDocument
        //{
        //    {"Driver", driver.Name},
        //    {"Abbreviation", driver.Abbreviation},
        //    {"No", driver.Number},
        //    {"Team", driver.Team},
        //    {"Country", driver.Country},
        //    {"Date of Birth", driver.BirthDate},
        //    {"Numero de vitorias", driver.Numvitorias}
        //};

        //Console.WriteLine(dr);
        //collection.InsertOne(dr);

        Console.WriteLine("Informe o nome do piloto que sera modificado: ");
        string n = Console.ReadLine();

        var p = collection.Find(Builders<BsonDocument>.Filter.Regex("Driver", n)).First();

        var driver = BsonSerializer.Deserialize<Driver>(p);

        Console.WriteLine("Informe o novo numero: ");
        int m = int.Parse(Console.ReadLine());

        var filtro = Builders<BsonDocument>.Filter.Regex("Driver", n);
        var update = Builders<BsonDocument>.Update.Set("No", m);

        collection.UpdateOne(Builders<BsonDocument>.Filter.Regex("Driver", n),
            Builders<BsonDocument>.Update.Set("No", m));

        collection.DeleteOne(filtro);
    }
}