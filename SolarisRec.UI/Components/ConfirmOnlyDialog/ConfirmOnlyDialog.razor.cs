using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;

namespace SolarisRec.UI.Components.ConfirmOnlyDialog
{
    public partial class ConfirmOnlyDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public List<string> Reasons { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));        
    }
}