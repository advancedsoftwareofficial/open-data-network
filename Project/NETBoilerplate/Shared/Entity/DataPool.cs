using System.Collections.Generic;
using AdvancedSoftware.DataAccess.Entity;

namespace NETBoilerplate.Shared.Entity
{
    public class DataPool : EntityBase
    {
        public string PoolName { get; set; }
        public User User { get; set; }
        public IList<DataPoolStorage> DataPoolStorages { get; set; }
    }
}