using Microsoft.AspNetCore.Components;

namespace BoardMaui.Extensions;

public class AutoNavigation(NavigationManager NavigationManager)
{
    public static PeriodicTimer? Timer { get; set; }
    public async Task AutoNavigateAsync(bool enabled, string currentPage, string nextPage, CancellationToken cancellationToken = default)
    {
        MauiProgram.CurrentPage = currentPage;
        if (!enabled)
        {
            NavigationManager.NavigateTo(nextPage);
            return;
        }

        Timer?.Dispose(); // Dispose of any existing timer
        Timer = new PeriodicTimer(TimeSpan.FromSeconds(1)); // Set the timer to tick every second
        while (Timer != null && await Timer.WaitForNextTickAsync(cancellationToken))
        {
            if (DateTime.UtcNow.Second % 20 == 0 && MauiProgram.CurrentPage == currentPage)
            {
                NavigationManager.NavigateTo(nextPage);
                break; // Exit after navigation
            }
        }
    }
}
