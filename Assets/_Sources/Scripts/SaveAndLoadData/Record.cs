using System;

namespace Assets._Sources.Scripts.SaveAndLoadData
{
    [System.Serializable]
    public class Record
    {
        public int Id { get; set; }

        public float Coin { get; set; }

        public Int32 MaxLevelIndex { get; set; }

        public DateTime SaveTime { get; set; }
        public bool EndGame { get; set; }

        public static Record GetDefault()
        {
            return new Record()
            {
                Id = 0,
                MaxLevelIndex = 1,
                SaveTime = DateTime.Now,
                EndGame = false
            };
        }

    }
}
