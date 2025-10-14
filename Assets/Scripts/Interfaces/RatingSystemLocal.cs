using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
#if !UNITY_EDITOR
using UnityEngine.Networking;
using System.Threading.Tasks;
#endif

#if UNITY_EDITOR
public static class RatingGenerator
{
    [MenuItem("Tools/Create Rating File")]
    public static void CreateStaticRatingFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "my_rating.json");

        List<Rating> ratings = new();
        for (int i = 0; i < 900; i++)
        {
            ratings.Add(new Rating
            {
                BiggestCity = UnityEngine.Random.Range(230, 12001)
            });
        }

        ratings.Sort((a, b) => b.BiggestCity.CompareTo(a.BiggestCity));

        for (int i = 0; i < ratings.Count; i++)
        {
            ratings[i].Rank = i + 1;
        }

        string jsonData = JsonConvert.SerializeObject(ratings, Formatting.Indented);

        File.WriteAllText(filePath, jsonData);

        AssetDatabase.Refresh();
        Debug.Log($"Succefull rating file created: {filePath}");
    }
}
#endif

public class RatingSystemLocal : IRatingSystem
{
    private const string RATING_FILE_URL = "streamingAssets/my_rating.json";
    private const string PLAYER_PREF_BEST_SCORE = "BestScore";

    public Rating GetRating()
    {
        Rating[] ratingTable;
#if UNITY_EDITOR
        ratingTable = GetRatingTableDirect();
#else
        ratingTable = GetRatingTableAsync().Result;
#endif

        if (ratingTable == null)
        {
            return null;
        }

        int currentScore = GetCurrentPlayerScore();
        int rank = FindPlayerRank(currentScore, ratingTable);

        Rating playerRating = new()
        {
            BiggestCity = currentScore,
            Rank = rank
        };

        return playerRating;
    }

    public void SubmitRecord(int score)
    {
        int bestScore = PlayerPrefs.GetInt(PLAYER_PREF_BEST_SCORE, 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(PLAYER_PREF_BEST_SCORE, score);
            PlayerPrefs.Save();
        }
    }

    private int FindPlayerRank(int playerScore, Rating[] ratingTable)
    {
        for (int i = 0; i < ratingTable.Length; i++)
        {
            if (playerScore >= ratingTable[i].BiggestCity)
            {
                return i + 1;
            }
        }
        return ratingTable.Length + 1;
    }

    private int GetCurrentPlayerScore()
    {
        return PlayerPrefs.GetInt(PLAYER_PREF_BEST_SCORE, 0);
    }

#if UNITY_EDITOR
    public Rating[] GetRatingTableDirect()
    {
        string filePath = Path.Combine(Application.dataPath, "../StreamingAssets/", RATING_FILE_URL);
        if (!File.Exists(filePath)) {
            return null;
        }
        string jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<Rating[]>(jsonData);
    }
#else
    public async Task<Rating[]> GetRatingTableAsync()
    {
        string fullUrl = $"{Application.streamingAssetsPath}/{RATING_FILE_URL}";

        UnityWebRequest request = UnityWebRequest.Get(fullUrl);
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonData = request.downloadHandler.text;
            return JsonConvert.DeserializeObject<Rating[]>(jsonData);
        }
        else
        {
            Debug.LogWarning($"Ошибка при загрузке файла рейтинга: {request.error}");
            return null;
        }
    }
#endif
}