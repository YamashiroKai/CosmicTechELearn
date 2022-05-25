using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Fighters
    {
        [Key]
        public int FighterID { set; get; }

        public string BenderName { set; get; }

        public string City { set; get; }

        public string Weapon { set; get; }

        public string[] FightingStyles { set; get; }
    }
}
