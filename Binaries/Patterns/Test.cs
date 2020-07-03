using System;
using System.Collections.Generic;
using System.Drawing;
using LeagueBot.Patterns;
using LeagueBot.Game.Enums;
using LeagueBot.Game.Misc;


namespace LeagueBot
{
    public class Test : PatternScript
    {
        private Point CastTargetPoint
        {
            get;
            set;
        }

        public override void Execute()
        {
            bot.log("waiting for league of legends process...");

            //bot._outActualTime = 0
            while (bot.isProcessOpen(GAME_PROCESS_NAME)) // Game loop
            {

                bot.bringProcessToFront(GAME_PROCESS_NAME);
                bot.centerProcess(GAME_PROCESS_NAME);

                if (game.player.isThereAnEnemyCreep())
                {
                    game.player.playerHasRange("creep");
                }
                bot.wait(500);
            }
        }
    }
}
