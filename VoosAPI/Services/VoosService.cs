using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoosAPI.Models;

namespace VoosAPI.Services
{
    public class VoosService
    {
        private readonly IMongoCollection<Voo> _voos;

        public VoosService(IVoosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _voos = database.GetCollection<Voo>(settings.VoosCollectionName);
        }
        public List<Voo> Get() =>
         _voos.Find(voo => true).ToList();

        public Voo Get(string id) =>
            _voos.Find<Voo>(voo => voo.Id == id).FirstOrDefault();

        public Voo Create(Voo voo)
        {
            _voos.InsertOne(voo);
            return voo;
        }

        public void Update(string id, Voo vooIn) =>
            _voos.ReplaceOne(voo => voo.Id == id, vooIn);

        public void Remove(Voo vooIn) =>
            _voos.DeleteOne(voo => voo.Id == vooIn.Id);
        
        public void remove(string id) =>
            _voos.DeleteOne(voo => voo.Id == id);

        internal void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
