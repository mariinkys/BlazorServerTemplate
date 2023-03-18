using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Presentation.Blazor.Server.BasePages
{
    public class BasePage : ComponentBase
    {
        public void ShowInfo(ISnackbar snackbar)
        {
            snackbar.Add("Atención", Severity.Info);
        }

        public void ShowInfo(ISnackbar snackbar, string message)
        {
            snackbar.Add(message, Severity.Info);
        }

        public void ShowSuccess(ISnackbar snackbar)
        {
            snackbar.Add("Correcto", Severity.Success);
        }

        public void ShowSuccess(ISnackbar snackbar, string message)
        {
            snackbar.Add(message, Severity.Success);
        }

        public void ShowWarning(ISnackbar snackbar)
        {
            snackbar.Add("Atención", Severity.Warning);
        }

        public void ShowWarning(ISnackbar snackbar, string message)
        {
            snackbar.Add(message, Severity.Warning);
        }

        public void ShowError(ISnackbar snackbar)
        {
            snackbar.Add("Error", Severity.Error);
        }

        public void ShowError(ISnackbar snackbar, string message)
        {
            snackbar.Add(message, Severity.Error);
        }
    }
}
