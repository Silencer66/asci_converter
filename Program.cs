// See https://aka.ms/new-console-template for more information
using asci_converter;
class Program
{
    private const double WIDTH_OFFSET = 1.5;
    private const int MAX_WIDTH = 350;
    [STAThread]
    static void Main()
    {
        //Console.WriteLine("Hello, World!");
        var openFileDialog = new OpenFileDialog()
        {
            Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
        };
       // openFileDialog.ShowDialog();

        while (true)
        {
            Console.ReadKey();

            if(openFileDialog.ShowDialog() != DialogResult.OK) 
                continue; 
            
            Console.Clear();
            
            var bmp = new Bitmap(openFileDialog.FileName);
            bmp = ResizeBitmap(bmp);
            bmp.ToGrayScale();

            var converter = new BitmapToASCIIConverter(bmp);
            Console.WriteLine("ljikasdasdsadsadas");
            var rows = converter.Convert();
            foreach (var row in rows)
                Console.WriteLine(row);

            File.WriteAllLines("image.txt",rows.Select(r=>new string(r)));

            //что бы мы видели всю строчку 
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }
    }

    //подгоняем по ширине картинку
    private static Bitmap ResizeBitmap(Bitmap bitmap)
    {
        var newHeight = bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width;
        if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
            bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));
        return bitmap;
    }
}