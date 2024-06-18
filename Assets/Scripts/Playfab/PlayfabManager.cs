using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowParent;
    private void Start()
    {
        GetLeaderboard();
    }
    public static void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
            new StatisticUpdate{
                StatisticName= "PlatformScore",
                Value= score
            }
        }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboarUpdate, OnError);
    }

    private static void OnError(PlayFabError error)
    {
        Debug.LogError("Failed to log in with PlayFab: " + error.Error);

    }

    private static void OnLeaderboarUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Update Successfully");

    }

    public void GetLeaderboard()
    {
        string currentPlayerId = Login.playerId;
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        // PlayFabClientAPI.GetLeaderboard(request, OnLeaderboard, OnError);
        PlayFabClientAPI.GetLeaderboard(request, (result) => OnLeaderboard(result, currentPlayerId), OnError);
    }

    private void OnLeaderboard(GetLeaderboardResult result, string currentPlayerId)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = item.Position.ToString();
            if (item != null)
            {
                texts[1].text = item.PlayFabId ?? item.DisplayName;
            }
            // texts[1].text = item.PlayFabId;
            if (item.PlayFabId == currentPlayerId)
            {
                texts[0].color = Color.red;
                texts[1].color = Color.red;
                texts[2].color = Color.red;
            }
            else
            {
                texts[0].color = Color.black;
                texts[1].color = Color.black;
                texts[2].color = Color.black;
            }
            texts[2].text = item.StatValue.ToString();
        }
    }
}
