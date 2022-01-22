using SolarisRec.UI.UIModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarisRec.UI.Components.Dropdown
{
    internal class PagingValuesProvider : IPagingValuesProvider
    {
        public async Task<List<DropdownItem>> ProvideDropdownItems()
        {
            var result = new List<DropdownItem>
            {
                new DropdownItem
                {
                    Id = 4,
                    Name = "4"
                },
                new DropdownItem
                {
                    Id = 6,
                    Name = "6"
                },
                new DropdownItem
                {
                    Id = 8,
                    Name = "8"
                },
                new DropdownItem
                {
                    Id = 50,
                    Name = "50"
                },
            };

            return await Task.FromResult(result);
        }        
    }
}