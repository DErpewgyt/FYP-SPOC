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
    public RawImage rawImage;
    public GameObject objectToDeactivate; // Reference to the GameObject to deactivate

    private static CustomVideoPlayer activeVideoPlayer; // Static reference to the currently active video player

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
                activeVideoPlayer.objectToDeactivate.SetActive(true); // Activate the object of the paused player
            }

            activeVideoPlayer = this;

            player.Play();
            button.image.sprite = stopSprite;

            // Deactivate the GameObject when the video is played
            DeactivateObjectToDeactivate();
        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;

            // Activate the GameObject when the video is paused
            objectToDeactivate.SetActive(true);
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

    private void DeactivateObjectToDeactivate()
    {
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
    }
}
