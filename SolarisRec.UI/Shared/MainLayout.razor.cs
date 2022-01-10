﻿using MudBlazor;

namespace SolarisRec.UI.Shared
{
    public partial class MainLayout
    {
        private MudTheme _currentTheme = new MudTheme();
        private bool _sidebarOpen = false;
        private void ToggleTheme(MudTheme changedTheme) => _currentTheme = changedTheme;

        private void ToggleSidebar() => _sidebarOpen = !_sidebarOpen;
    }
}