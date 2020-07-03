﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using LeagueBot.Patterns;
using LeagueBot.ApiHelpers;

namespace LeagueBot
{
    public class StartCoop : PatternScript
    {
        private const string MODE = "intro";
        
        private Random RandomTextSender;
        
        private const string SELECTED_CHAMPION = "ashe";

        public override void Execute()
        {
            bot.log("Waiting for league client process... Ensure League client window size is 1600x900");
            bot.waitProcessOpen(CLIENT_PROCESS_NAME);
            
            bot.bringProcessToFront(CLIENT_PROCESS_NAME);
            bot.waitUntilProcessBounds(CLIENT_PROCESS_NAME, 1600, 900);
            bot.centerProcess(CLIENT_PROCESS_NAME);

            bot.wait(5000);

            bot.bringProcessToFront(CLIENT_PROCESS_NAME);
            bot.waitUntilProcessBounds(CLIENT_PROCESS_NAME, 1600, 900);
            bot.centerProcess(CLIENT_PROCESS_NAME);

            //REDO

            bot.log("Client ready.");
            bot.wait(2000);
            client.clickPlayButton();
            bot.wait(2000);
            client.clickCoopvsIAText();
            bot.wait(2000);

            if (MODE == "intermediate")
            {
                client.clickIntermediateText();
            }
            else if (MODE == "intro")
            {
                client.clickIntroText();
            }


            bot.wait(2000);
            client.clickConfirmButton();

            bot.wait(5000);

            client.clickFindMatchButton();

            bot.log("Finding match...");

            while (client.mustSelectChamp() == false)
            {
				client.clickFindMatchButton();
                client.acceptMatch();
                bot.wait(3000);
            }

            bot.log("Match found");

            string[] champs = io.getChamps();

            if(champs.Length > 0)
            {
                foreach (string champ in champs)
                {
                    pickChamp(champ);
                    client.clearChampSearch();
                    bot.wait(150);
                    client.clearChampSearch();
                }
            } else
            {
                pickChamp(SELECTED_CHAMPION);
            }


           /* RandomTextSender = new Random();
            switch (RandomTextSender.Next(5))
            {
                case 1:
                    game.chat.talkInChampSelect("hi guys");
                    game.chat.talkInChampSelect("supporting bot");
                    break;
                case 2:
                    game.chat.talkInChampSelect("gl boys dont flame");
                    break;
                case 3:
                    game.chat.talkInChampSelect("sup");
                    break;
                case 4:
                    game.chat.talkInChampSelect("bot");
                    break;
                case 5:
                    game.chat.talkInChampSelect("support");
                    break;
                default:
                    game.chat.talkInChampSelect("Hi guys");
                    game.chat.talkInChampSelect("Going botlane");
                    break;
            }
            //champion not selected?
*/
            bot.executePattern("Coop");
        }

        void pickChamp(string champ)
        {
            client.clickChampSearch();
            bot.wait(500);
            bot.inputWords(champ);
            bot.wait(300);
            client.selectFirstChampion();
            bot.wait(500);
            client.lockChampion();
            bot.wait(1000);
        }
    }
}
