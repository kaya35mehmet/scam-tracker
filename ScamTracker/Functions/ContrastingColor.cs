using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Functions
{
    public class ContrastingColor
    {
        public static Color GenerateRandomColor()
        {
            Random random = new Random();
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            return System.Drawing.Color.FromArgb(r, g, b);
        }

        public static Color GetContrastingColor(Color color)
        {
            // Luminance hesaplama
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            // Eğer parlaklık eşikten küçükse (koyu renk), beyaz döndür
            return luminance < 0.5 ? System.Drawing.Color.White : System.Drawing.Color.Black;
        }
    }
}
