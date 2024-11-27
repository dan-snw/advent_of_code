using System.Text;

namespace AOC.Tests.Common;

public static class MethodsForTesting
{
    public static StreamReader StringToStreamReader(string input)
    {
        var byteArray = Encoding.UTF8.GetBytes(input);
        MemoryStream stream = new(byteArray);
        StreamReader reader = new(stream);
        return reader;
    }
}
