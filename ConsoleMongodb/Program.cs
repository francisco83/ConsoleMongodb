using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ConsoleMongodb
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

                //Database List  
                var dbList = dbClient.ListDatabases().ToList();                

                Console.WriteLine("Las base de datos son:");
                foreach (var item in dbList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n\n");

                //Get Database and Collection  
                IMongoDatabase db = dbClient.GetDatabase("test");
                var collList = db.ListCollections().ToList();
                Console.WriteLine("las listas de colecciones son :");
                Console.WriteLine("\n\n");
                foreach (var item in collList)
                {
                    Console.WriteLine(item);
                   
                }

                /**/

                var things = db.GetCollection<BsonDocument>("coleccion_prueba");
                /*
                GridFSBucketOptions o = new GridFSBucketOptions();
                o.BucketName = "data";
                GridFSBucket fsbucket = new GridFSBucket(dataLocal, o);
                */
                /**/

                // Creo una coleccion y cargo 10000 registros
                //var things = db.GetCollection<BsonDocument>("coleccion_prueba");

                /*
                for (int i = 0; i < 10000; i++)
                {
                    BsonElement personFirstNameElement = new BsonElement("Nombre", "Francisco "+i);

                    BsonDocument personDoc = new BsonDocument();
                    personDoc.Add(personFirstNameElement);
                    //personDoc.Add(new BsonElement("PersonAge", 23));

                    things.InsertOne(personDoc);
                }
                */


                /*
                db.DropCollection("things");
                var things = db.GetCollection<BsonDocument>("things");

                //CREATE  
                BsonElement personFirstNameElement = new BsonElement("PersonFirstName", "Sankhojjal");

                BsonDocument personDoc = new BsonDocument();
                personDoc.Add(personFirstNameElement);
                personDoc.Add(new BsonElement("PersonAge", 23));

                things.InsertOne(personDoc);

                //UPDATE  
                BsonElement updatePersonFirstNameElement = new BsonElement("PersonFirstName", "Souvik");

                BsonDocument updatePersonDoc = new BsonDocument();
                updatePersonDoc.Add(updatePersonFirstNameElement);
                updatePersonDoc.Add(new BsonElement("PersonAge", 24));

                BsonDocument findPersonDoc = new BsonDocument(new BsonElement("PersonFirstName", "Sankhojjal"));

                var updateDoc = things.FindOneAndReplace(findPersonDoc, updatePersonDoc);

                Console.WriteLine(updateDoc);

                //DELETE  
                BsonDocument findAnotherPersonDoc = new BsonDocument(new BsonElement("PersonFirstName", "Sourav"));

                things.FindOneAndDelete(findAnotherPersonDoc);
                */
                //READ  
                var resultDoc = things.Find(new BsonDocument()).ToList();
                foreach (var item in resultDoc)
                {
                    Console.WriteLine(item.ToString());
                }
                
            }  
                catch (Exception ex)  
                {  
                    Console.WriteLine(ex.Message);  
                }

        Console.ReadKey();
        }
    }
}
