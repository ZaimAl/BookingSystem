using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataModel.Master.Menu
{
    public class IndexMenu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public int? Sequence { get; set; }
        public int? IsHeader { get; set; }
    }
}
