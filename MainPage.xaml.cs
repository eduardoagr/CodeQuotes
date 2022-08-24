using CodeQuotes.Services;

namespace CodeQuotes;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void btnRandomQuote_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();

        var startColor =
               System.Drawing.Color.FromArgb(
                    random.Next(0, 256),
                    random.Next(0, 256),
                    random.Next(0, 256));

        var endColor =
             System.Drawing.Color.FromArgb(
                  random.Next(0, 256),
                  random.Next(0, 256),
                  random.Next(0, 256));


        var colors =
          ColorUtility
          .ColorControls
          .GetColorGradient(startColor, endColor, 6);

        var stopOffset = .0f;
        var stops = new GradientStopCollection();
        foreach (var c in colors)
        {
            stops.Add(new GradientStop(Color.FromArgb(c.Name),
                 stopOffset));
            stopOffset += .2f;
        }

        var gradient =
             new LinearGradientBrush(stops,
                  new Point(0, 0),
                  new Point(1, 1));

        Background.Background = gradient;

        var quote = await RandomQuotes.GetRandomQuote();

        lblQuote.Text = $"{quote.en} - {quote.author}";

    }
}

