using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nest;
using Nest.Domain.Connection;

namespace ElasticSearch {
    class Program {
        static void Main(string[] args) {
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri).SetDefaultIndex("contacts");
            var client = new ElasticClient(settings);


            if (client.Health(HealthLevel.Cluster).ConnectionStatus.Success) {
                Console.WriteLine("Connection Successful");

                if (client.IndexExists("contacts").Exists) {
                    Console.WriteLine("Index Exists");
                    Program.UpsertArticle(client, new Article("A", "B"), "blog", "article", 1);
                    Program.UpsertContact(client, new Contacts("A", "B"), "contacts", "contacts", 2);
                    Console.WriteLine("Data Indexed Successfully");
                } else {
                    Console.WriteLine("Index Does Not Exist");
                }

            } else {
                Console.Write("Connection Failed");
            }

            Console.ReadKey();

        }

        public class Article {
            public string title { get; set; }
            public string artist { get; set; }
            public Article(string Title, string Artist) {
                title = Title; artist = Artist;
            }
        }

        public class Contacts {
            public string name { get; set; }
            public string country { get; set; }
            public Contacts(string Name, string Country) {
                name = Name; country = Country;
            }
        }

        public static void UpsertArticle(ElasticClient client, Article article, string index, string type, int id) {
            var RecordInserted = client.Index(article, index, type, id).Id;

            if (RecordInserted.ToString() != "") {
                Console.WriteLine("Transaction Successful !");
            } else {
                Console.WriteLine("Transaction Failed");
            }
        }

        public static void UpsertContact(ElasticClient client, Contacts contact, string index, string type, int id) {
            var RecordInserted = client.Index(contact, index, type, id).Id;

            if (RecordInserted.ToString() != "") {
                Console.WriteLine("Transaction Successful !");
            } else {
                Console.WriteLine("Transaction Failed");
            }
        }
    }
}