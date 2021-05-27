using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbench.Models
{
    public class Operation
    {
        [BsonId]
        public Guid MyProperty { get; set; }
        public DateTime Date { get; set; }
        public string Active { get; set; }
        public int OpWin { get; set; }
        public int OpLoss { get; set; }
        public int Contract { get; set; }
        public double WinRate { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public double Profit { get; set; }
    }
}
