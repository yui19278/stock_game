using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace stock_game_netpro.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
    }

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    public class Currency
    {
        [key, ForeignKey("User")]
        public int Id { get; set; }
        public double CurrencyA { get; set; } = 10000.0;
        public double CurrencyB { get; set; } = 10000.0;
        public virtual User User { get; set; } //オーバーライド
    }
}