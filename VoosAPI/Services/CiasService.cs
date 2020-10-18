using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoosAPI.Models;

namespace VoosAPI.Services
{
    public class CiasService
    {
        private readonly IMongoCollection<Cia> _cias;

        public CiasService(ICiasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cias = database.GetCollection<Cia>(settings.CiasCollectionName);
        }
        public List<Cia> Get() =>
         _cias.Find(cia => true).ToList();

        public Cia Get(string id) =>
            _cias.Find<Cia>(cia => cia.Id == id).FirstOrDefault();

        public Cia Create(Cia cia)
        {
            _cias.InsertOne(cia);
            return cia;
        }

        public void Update(string id, Cia ciaIn) =>
            _cias.ReplaceOne(cia => cia.Id == id, ciaIn);
       
        public void Remove(Cia ciaIn) =>
            _cias.DeleteOne(cia => cia.Id == ciaIn.Id);
        
        public void remove(string id) =>
            _cias.DeleteOne(cia => cia.Id == id);

        internal void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}