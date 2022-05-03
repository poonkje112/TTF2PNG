using System.Drawing;
using System.Drawing.Imaging;

namespace ttf2png;

public class ttfConverter
{
	const string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,:;'\"(!?)+-8/= ";
	public bool ConvertTtf2Image(string ttfPath, string outputPath, int fontSize)
	{
		// Load the TTF and convert it to a bitmap
		Font font = new Font(ttfPath, fontSize);
		Bitmap bitmap = new Bitmap(1, 1);
		Graphics graphics = Graphics.FromImage(bitmap);
		SizeF size = graphics.MeasureString(charset, font);

		int width = 0;
		foreach (char c in charset)
		{
			if(graphics.MeasureString(c.ToString(), font).Width > width)
			{
				width = (int)graphics.MeasureString(c.ToString(), font).Width;
			}
		}
		
		
		bitmap = new Bitmap(width * charset.Length, (int)size.Height);
		graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.FromArgb(0, 0, 0, 0));

		for (int i = 0; i < charset.Length; i++)
		{
			graphics.DrawString(charset[i].ToString(), font, Brushes.White, width * i, 0);
		}
		
		graphics.Flush();
		graphics.Dispose();
		
		// Save the bitmap to a PNG file
		bitmap.Save(outputPath, ImageFormat.Png);
		bitmap.Dispose();

		return true;
	}
}