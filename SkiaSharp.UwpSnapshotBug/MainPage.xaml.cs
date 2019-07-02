using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharp.UwpSnapshotBug
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            canvas.Clear(SKColors.White);
            canvas.Flush();

            using (var snapshotImage = e.Surface.Snapshot())
            using (var bitmap = SKBitmap.FromImage(snapshotImage))
            {
                Debug.WriteLine($"Has non-zero color: {bitmap.Pixels.Any(pixel => pixel != new SKColor(0, 0, 0, 0))}");
            }
        }
    }
}
