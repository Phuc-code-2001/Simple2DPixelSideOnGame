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

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public Int32 SceneIndex { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public DateTime SaveTime { get; set; }

        public bool EndGame { get; set; }
    }
}
