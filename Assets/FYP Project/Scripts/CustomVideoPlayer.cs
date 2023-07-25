using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CustomVideoPlayer : MonoBehaviour
{
    private VideoPlayer player;
    public Button button;
    public Sprite startSprite;
    public Sprite stopSprite;
    public RawImage rawImage; // Reference to the specific RawImage for this video

    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    public void ChangeStartStop()
    {
        if (player.isPlaying == false)
        {
            player.Play();
            button.image.sprite = stopSprite;
        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;
        }
    }
}
