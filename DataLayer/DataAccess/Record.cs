using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataAccess
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        public float Coin { get; set; }

        public Int32 MaxLevelIndex { get; set; }

        public DateTime SaveTime { get; set; }
        public bool EndGame { get; set; }
    }
}
