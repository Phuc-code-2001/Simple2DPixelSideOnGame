using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Sources.Scripts.SaveAndLoadData
{
    public class Record
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public Int32 SceneIndex { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public DateTime SaveTime { get; set; }
    }
}
