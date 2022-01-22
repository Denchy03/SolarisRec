using System;
using System.Collections.Generic;

namespace SolarisRec.Core.Card
{
    public class CardFilter
    {
        public string Name { get; set; } = string.Empty;

        public List<int> CardTypes { get; set; } = new List<int>();

        public List<int> Talents { get; set; } = new List<int>();

        public List<int> Factions { get; set; } = new List<int>();

        public List<string> Keywords { get; set; } = new List<string>();

        public List<int> ConvertedResourceCost { get; set; } = new List<int>();

        public int PageSize { get; set; } = 8;

        public int Page { get; set; } = 1;

        public string PageSizeFromTo => GetPageSizeFromToString();

        public int MatchingCardCount { get; set; }

        public string Ability { get; set; } = string.Empty;

        public string OrderBy { get; set; } = string.Empty;

        public int SortingDirection { get; set; } = 0;

        private string GetPageSizeFromToString()
        {
            var start = (Page - 1) * PageSize + 1;
            var end = Page * PageSize;

            return $"{start}-{end}";

        }
    }
}