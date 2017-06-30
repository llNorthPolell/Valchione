public class JsonStringUtil {
    private static string removeSquareBrackets(string input)
    {
        string output = input;
        if (output.IndexOf('[') != -1)
            output = output.Remove(output.IndexOf('['), 1);

        if (output.IndexOf(']') != -1)
            output = output.Remove(output.IndexOf(']'), 1);

        return output;
    }


    public static string[] jsonListStringToStringArray(string input)
    {
        return removeSquareBrackets(input).Trim().Split(',');
    }
}
