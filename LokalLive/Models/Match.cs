using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LokalLive.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public DateTime MatchStart { get; set; }
        public DateTime MatchEnd { get; set; }
        public DateTime IntermissionStart { get; set; }
        public DateTime IntermissionEnd { get; set; }
    }
}