﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueBot.Api
{
    public class Game
    {
        public double currentHealth { get; set; }
        public double maxHealth { get; set; }
        public double resourceValue { get; set; }
        public double resourceMax { get; set; }
        public double attackDamage { get; set; }
        public double attackRange { get; set; }
        public double attackSpeed { get; set; }

        [JsonProperty("currentGold")]
        public double currentGold { get; set; }
        [JsonProperty("level")]
        public int level { get; set; }
        [JsonProperty("summonerName")]
        public string summonerName { get; set; }
    }
}