﻿using SolarisRec.UI.UIModels;
using System.Collections.Generic;

namespace SolarisRec.UI.Utility
{
    public interface IDeckGenerator
    {
        string Generate(DeckList deckList);
    }
}