using ttf2png;

class Program
{
	public static void Main(string[] args)
	{
		// Get the source path
		string path = args[0];

		// Get the target path
		string targetPath = args[1];

		// Get the font size
		int fontSize = int.Parse(args[2]);

		ttfConverter converter = new ttfConverter();
		converter.ConvertTtf2Image(path, targetPath, fontSize);
	}
}