using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace All_Beated.Database_Class_Types
{
    class GameWriteType
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Reviw { get; set; }
        public int PlayTime { get; set; }
        public string Positives { get; set; }
        public string Negatives { get; set; }
        public string PicPath { get; set; }
    }
}
