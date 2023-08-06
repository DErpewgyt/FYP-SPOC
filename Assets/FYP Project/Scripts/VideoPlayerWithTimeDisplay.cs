using System;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class VideoPlayerWithTimeDisplay : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI durationDisplay;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        UpdateDurationDisplay();
    }

    private void Update()
    {
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        TimeSpan currentTime = TimeSpan.FromSeconds(videoPlayer.time);
        string formattedTime = $"{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";
        timeDisplay.text = formattedTime;
    }

    private void UpdateDurationDisplay()
    {
        TimeSpan duration = TimeSpan.FromSeconds(videoPlayer.clip.length);
        string formattedDuration = $"{duration.Minutes:D2}:{duration.Seconds:D2}";
        durationDisplay.text = formattedDuration;
    }

    private void OnVideoEnd(VideoPlayer player)
    {
        player.time = 0;
        player.Play();
    }
}
