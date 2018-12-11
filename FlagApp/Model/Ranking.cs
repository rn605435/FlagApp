using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagApp.Model
{
    public class Ranking
    {
        [PrimaryKey,AutoIncrement,Unique,NotNull]
        public int Id { get; set; }
        public int Score { get; set; }

    }
}
