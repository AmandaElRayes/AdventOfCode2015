
try
{
    using var sr = new StreamReader("input.txt");

    (List<int> volume, List<int> distanceAroundSides) = GetAmountOfWrappingPaper(sr);
    GetLenthOfRibbon(volume, distanceAroundSides);

}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}

static void GetLenthOfRibbon(List<int> volume, List<int> distanceAroundSides)
{
    int totalLengthOfRibbon = volume.Sum() + distanceAroundSides.Sum();
    Console.WriteLine("LengthOfRibbon: " + totalLengthOfRibbon);
}

static (List<int>, List<int>) GetAmountOfWrappingPaper(StreamReader sr)
{
    int wrappingPaperInSqFeet = 0;

    List<int> volume = new List<int>();
    List<int> distanceAroundSides = new List<int>();
    while (!sr.EndOfStream)
    {
        int w;
        int h;
        int l;
        int wSurfaceArea;
        int hSurfaceArea;
        int lSurfaceArea;
        int smallestSurfaceArea;
        List<int> surfaces = new List<int>();
        List<int> dist = new List<int>();
        string[] line = sr.ReadLine().Split('x');
        w = int.Parse(line[0]);
        h = int.Parse(line[1]);
        l = int.Parse(line[2]);
        wSurfaceArea = 2 * l * w;
        hSurfaceArea = 2 * w * h;
        lSurfaceArea = 2 * h * l;

        //areas of sides
        surfaces.Add(l * w);
        surfaces.Add(w * h);
        surfaces.Add(h * l);

        dist.Add(l);
        dist.Add(w);
        dist.Add(h);

        dist.Remove(dist.Max());

        volume.Add(w * l * h);
        distanceAroundSides.Add(dist[0] * 2 + dist[1] * 2);
        smallestSurfaceArea = surfaces.Min();
        wrappingPaperInSqFeet += wSurfaceArea + hSurfaceArea + lSurfaceArea + smallestSurfaceArea;

    }
    Console.WriteLine("Wrapping Paper: " + wrappingPaperInSqFeet);
    return (volume, distanceAroundSides);
}