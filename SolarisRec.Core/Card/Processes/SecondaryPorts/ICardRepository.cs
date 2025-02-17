﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarisRec.Core.Card.Processes.SecondaryPorts
{
    public interface ICardRepository
    {
        Task<Card> Get(int id);

        Task<List<Card>> GetCardsFiltered(CardFilter filter);

        Task<List<Card>> List();

        Task<List<Card>> GetFactionCards(int factionId);
    }
}