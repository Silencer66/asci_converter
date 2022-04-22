namespace asci_converter;

public static class Extensions
{
    public static void ToGrayScale(this Bitmap bmp)
    {
        for (int y = 0; y < bmp.Height; y++)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                var pixel = bmp.GetPixel(x, y);
                int avg = (pixel.R + pixel.G + pixel.B) / 3;
                //pixel.A -альфа канал (прозрачность)
                bmp.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg));
            }
        }
    }
}

