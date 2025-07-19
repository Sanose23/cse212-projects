using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

public static class SetsAndMaps
{
    // Problem 1 - Finding Pairs
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();
        var used = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (word != reversed && set.Contains(reversed) && !used.Contains(word) && !used.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                used.Add(word);
                used.Add(reversed);
            }
        }

        return result.ToArray();
    }

    // Problem 2 - Degree Summary
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
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
        }

        return degrees;
    }

    // Problem 3 - Anagrams
    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = new string(word1.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        string clean2 = new string(word2.Where(char.IsLetterOrDigit).ToArray()).ToLower();

        if (clean1.Length != clean2.Length) return false;

        var dict = new Dictionary<char, int>();

        foreach (var c in clean1)
        {
            if (dict.ContainsKey(c)) dict[c]++;
            else dict[c] = 1;
        }

        foreach (var c in clean2)
        {
            if (!dict.ContainsKey(c)) return false;
            dict[c]--;
            if (dict[c] == 0) dict.Remove(c);
        }

        return dict.Count == 0;
    }

    // Problem 4 - Maze Navigation
    public static (int, int) NavigateMaze(string[] moves)
    {
        var directions = new Dictionary<string, (int dx, int dy)>
        {
            { "up", (0, 1) },
            { "down", (0, -1) },
            { "left", (-1, 0) },
            { "right", (1, 0) }
        };

        int x = 0, y = 0;

        foreach (var move in moves)
        {
            if (directions.ContainsKey(move.ToLower()))
            {
                var (dx, dy) = directions[move.ToLower()];
                x += dx;
                y += dy;
            }
        }

        return (x, y);
    }

    // Problem 5 - Earthquake JSON Data
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var response = client.GetAsync(uri).Result;
        var json = response.Content.ReadAsStringAsync().Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag;
            summaries.Add($"{place} - Magnitude: {mag}");
        }

        return summaries.ToArray();
    }
}