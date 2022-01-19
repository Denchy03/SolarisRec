using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;

namespace SolarisRec.UI.Components.ValidationDialog
{
    public partial class ValidationDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public List<string> Reasons { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}