using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character
    /// words (lower case, no duplicates). Using sets, find an O(n)
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // Store words that we have already seen.
        var seen = new HashSet<string>();

        // Store the symmetric pairs that we find.
        var pairs = new List<string>();

        foreach (var word in words)
        {
            // Reverse the two-character word.
            var reversed = $"{word[1]}{word[0]}";

            // A word such as "aa" should not match itself.
            if (word != reversed && seen.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");
            }

            seen.Add(word);
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Degree is in the fourth column, which is index 3.
            // Trim removes the spaces around the value in the census file.
            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if word1 and word2 are anagrams.
    /// Spaces and letter case are ignored.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var letters = new Dictionary<char, int>();

        // Count each character in word1.
        foreach (var letter in word1)
        {
            if (letter == ' ')
                continue;

            var lowerLetter = char.ToLower(letter);

            if (letters.ContainsKey(lowerLetter))
            {
                letters[lowerLetter]++;
            }
            else
            {
                letters[lowerLetter] = 1;
            }
        }

        // Remove each character found in word2 from the counts.
        foreach (var letter in word2)
        {
            if (letter == ' ')
                continue;

            var lowerLetter = char.ToLower(letter);

            if (!letters.ContainsKey(lowerLetter))
            {
                return false;
            }

            letters[lowerLetter]--;

            if (letters[lowerLetter] < 0)
            {
                return false;
            }
        }

        // Every letter must have been used exactly the same number of times.
        foreach (var count in letters.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Read today's earthquake data from USGS and return the
    /// location and magnitude of each earthquake.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage =
            new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream =
            client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summary = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                summary.Add(
                    $"{feature.Properties.Place} - Mag {feature.Properties.Mag}"
                );
            }
        }

        return summary.ToArray();
    }
}