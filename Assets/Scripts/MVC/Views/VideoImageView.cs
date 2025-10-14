using UnityEngine;
using UnityEngine.Video;

public class VideoImageView : View
{
    [SerializeField] private VideoPlayer player;
    [SerializeField] private MonoBehaviourStateNotifier notifier;
    [Space(10)]
    [SerializeField] private string clipName;

    private void Awake()
    {
        notifier.OnStateChanged += HandleActivationChange;
    }

    private void OnDestroy()
    {
        notifier.OnStateChanged -= HandleActivationChange;
    }

    private void HandleActivationChange(bool isActive)
    {
        if (isActive)
        {
            LoadAndPlayVideo(clipName);
        }
        else
        {
            StopVideo();
        }
    }

    private void LoadAndPlayVideo(string clipName)
    {
        string fullPath = Application.streamingAssetsPath + "/" + clipName;
        PlayVideo(fullPath);
    }

    private void PlayVideo(string uri)
    {
        player.source = VideoSource.Url;
        player.url = uri;
        player.Prepare();
        player.Play();
    }

    private void StopVideo()
    {
        player.Stop();
        player.clip = null;
    }
}