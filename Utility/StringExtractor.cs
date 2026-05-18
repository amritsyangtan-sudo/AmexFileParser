namespace AmexParser;

public static class StringExtractor
{
    public static string SafeExtract(string line, int startIndex, int length, string fieldName = "Field")
    {
        if (string.IsNullOrEmpty(line))
        {
            throw new ArgumentException($"{fieldName}: Line is null or empty");
        }

        int requiredLength = startIndex + length;

        if (line.Length < requiredLength)
        {
            throw new ArgumentException(
                $"{fieldName}: Line too short. Expected at least {requiredLength} characters, got {line.Length}. Line: '{line}'"
            );
        }

        return line.Substring(startIndex, length).Trim();
    }

    /// <summary>
    /// Safely extracts an integer value from a line with validation.
    /// </summary>
    public static bool TryExtractInt(string line, int startIndex, int length, string fieldName, out int result)
    {
        result = 0;
        try
        {
            string extracted = SafeExtract(line, startIndex, length, fieldName);
            return int.TryParse(extracted, out result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Safely extracts a double value from a line with validation.
    /// </summary>
    public static bool TryExtractDouble(string line, int startIndex, int length, string fieldName, out double result)
    {
        result = 0;
        try
        {
            string extracted = SafeExtract(line, startIndex, length, fieldName);
            return double.TryParse(extracted, out result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}
