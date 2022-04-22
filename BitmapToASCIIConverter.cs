
namespace asci_converter;

public class BitmapToASCIIConverter
{
    //private readonly char[] _asciiTable = { '@', '#', 'S', '%', '?', '*', '+', ':', ',', '.' };
    private readonly char[] _asciiTable = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };
    private readonly Bitmap bitmap;
    public BitmapToASCIIConverter(Bitmap bmp)
    {
        bitmap = bmp;
    }
    public char[][] Convert()
    {
        var result = new char[bitmap.Height][];

        for (int y = 0; y < bitmap.Height; y++)
        {
            result[y] = new char[bitmap.Width];
            for (int x = 0; x < bitmap.Width; x++)
            {
                //Исходный пиксель преобразуем к нашему табличному
                int mapIndex = (int)Map(bitmap.GetPixel(x, y).R, 0, 255, 0, _asciiTable.Length - 1);
                result[y][x] = _asciiTable[mapIndex];
            }
        }

        return result;
    }
    private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
    {
        return ((valueToMap - start1) / (stop1 - start2)) * (stop2 - start2) + start2;
    }
}

