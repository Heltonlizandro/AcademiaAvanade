using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoosAPI.Models 
{
    public class CiasDatabaseSettings : ICiasDatabaseSettings
    { 
        public string CiasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICiasDatabaseSettings
    {
        public string CiasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
