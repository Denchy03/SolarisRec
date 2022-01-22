using SolarisRec.UI.UIModels;
using System;
using CoreEnums = SolarisRec.Core.Card.Enums;

namespace SolarisRec.UI.Provdiders
{
    internal static class TalentIconImageLinkProvider
    {
        public static string Provide(Talent talent)
        {
            return talent.TalentType switch
            {
                CoreEnums.Talent.Data => @"../Assets/Data.jpg",
                CoreEnums.Talent.Diplomacy => @"../Assets/Diplomacy.jpg",
                CoreEnums.Talent.Espionage => @"../Assets/Espionage.jpg",
                CoreEnums.Talent.Military => @"../Assets/Military.jpg",
                CoreEnums.Talent.Mining => @"../Assets/Mining.jpg",
                CoreEnums.Talent.Research => @"../Assets/Research.jpg",
                CoreEnums.Talent.Any => @"../Assets/Any.jpg",
                _ => throw new InvalidOperationException($"The talent type {Enum.GetName(talent.TalentType)} is not supported.")
            };
        }
    }
}