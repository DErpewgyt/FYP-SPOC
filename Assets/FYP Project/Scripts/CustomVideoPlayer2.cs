using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CustomVideoPlayer2 : MonoBehaviour
{
    private VideoPlayer player;
    public Button button;
    public Sprite startSprite;
    public Sprite stopSprite;
    public RawImage rawImage;
  

    private static CustomVideoPlayer2 activeVideoPlayer; // Static reference to the currently active video player

    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    public void ChangeStartStop()
    {
        if (player.isPlaying == false)
        {
            if (activeVideoPlayer != null && activeVideoPlayer != this)
            {
                activeVideoPlayer.PauseVideo(); // Pause the video playback
    
            }

            activeVideoPlayer = this;

            player.Play();
            button.image.sprite = stopSprite;


        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;


        }
    }

    private void OnDisable()
    {
        // Set the sprite to startSprite when the GameObject is disabled
        button.image.sprite = startSprite;

        if (activeVideoPlayer == this)
        {
            activeVideoPlayer = null;
        }
    }

    private void PauseVideo()
    {
        if (player != null)
        {
            player.Pause();
        }
    }

  
}
