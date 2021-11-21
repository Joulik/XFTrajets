using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsTrajets
{
    public class Trajet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Direction { get; set; }
        public string Transport { get; set; }
        public int Duree { get; set; }
    }
}
