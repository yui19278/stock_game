using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stock_game_netpro.Models
{
    public class member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Memo { get; set; }
    }
}