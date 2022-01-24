using SolarisRec.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarisRec.UI.Utility
{
    internal class DeckGenerator : IDeckGenerator
    {
        public string Generate(DeckList deckList)
        {
            StringBuilder stringBuilder = new();

            WriteMaindeck(stringBuilder, deckList.MainDeck);

            WriteMissionDeck(stringBuilder, deckList.MissionDeck);

            WriteTacticalDeck(stringBuilder, deckList.TacticalDeck);

            stringBuilder.Append("Built with SolaricRec by Major Martin");

            return stringBuilder.ToString();
        }

        private static void WriteMaindeck(StringBuilder stringBuilder, List<DeckItem> maindeck)
        {
            stringBuilder.AppendLine($"Main Deck: {maindeck.Select(d => d.Quantity).Sum()}");            

            for (int i = 0; i < maindeck.Count; i++)
            {
                stringBuilder.AppendLine(maindeck[i].Quantity.ToString() + " " + maindeck[i].Card.Name);
            }

            stringBuilder.Append(Environment.NewLine);
        }

        private static void WriteMissionDeck(StringBuilder stringBuilder, List<DeckItem> missionDeck)
        {
            stringBuilder.AppendLine($"Mission Deck: {missionDeck.Select(d => d.Quantity).Sum()}");

            for (int i = 0; i < missionDeck.Count; i++)
            {
                stringBuilder.AppendLine(missionDeck[i].Quantity.ToString() + " " + missionDeck[i].Card.Name);
            }

            stringBuilder.Append(Environment.NewLine);
        }

        private static void WriteTacticalDeck(StringBuilder stringBuilder, List<DeckItem> tacticalDeck)
        {
            stringBuilder.AppendLine($"Tactical Deck: {tacticalDeck.Select(d => d.Quantity).Sum()}");

            for (int i = 0; i < tacticalDeck.Count; i++)
            {
                stringBuilder.AppendLine(tacticalDeck[i].Quantity.ToString() + " " + tacticalDeck[i].Card.Name);
            }

            stringBuilder.Append(Environment.NewLine);
        }
    }    
}