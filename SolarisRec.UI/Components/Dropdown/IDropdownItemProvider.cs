﻿using SolarisRec.UI.UIModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarisRec.UI.Components.Dropdown
{
    public interface IDropdownItemProvider
    {
        Task<List<DropdownItem>> ProvideDropdownItems();
    }
}