using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataAccess
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public float HeathPoint { get; set; }
        public float ManaPoint { get; set; }

        public float Coin { get; set; }

    }
}
