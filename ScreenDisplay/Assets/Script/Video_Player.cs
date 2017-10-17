using System.Collections;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class Video_Player : MonoBehaviour
{
    // Movies Base Folder is Assets/StreamingAssets
    //Video Name To Play [Assign from the Editor with short path]
    // As example: Movies/Intro/Intro.mp4
    public string movie;
    [Range(0f, 1f)]
    // Sound Track volume
    public float soundVolume = 0.5f;
    // Play Video if true
    public bool play = false;
    private VideoPlayer vPlayer;
    private AudioSource vAudio;
    // Sound Track Number for Play from
    // MultiLang Video
    public ushort audioTrackNum = 0;
    public ushort audioTrackCount = 1;
    private RawImage image;
    private MovieTexture movieTexture;
    private string videoUrl = "";
    private AudioSource audioPlayer;
    public void OnPlay(string url)
    {
        
        videoUrl = "file://" + url;
        play = true;
    }

    void OnEnable()
    {
        //// Select Video & Audio Players
        //vPlayer = this.gameObject.AddComponent<VideoPlayer>();
        //vAudio = this.gameObject.AddComponent<AudioSource>();

        //// Set VideoPlayer Output Mode & Movie Source
        //vPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //vPlayer.source = VideoSource.Url;

        //// Disable Video & Audio Players play onAwake
        //vPlayer.playOnAwake = false;
        //vAudio.playOnAwake = false;

        //// Set full Movie Path
        ////vPlayer.url = "file://" + Application.streamingAssetsPath + "/" + movie;
        //vPlayer.url = videoUrl;
        //vPlayer.controlledAudioTrackCount = audioTrackCount;
        image = gameObject.GetComponent<RawImage>();
        audioPlayer = gameObject.GetComponent<AudioSource>();
        StartCoroutine(DownloadMovie());  
    }

    void OnDisable()
    {
        Pause();
    }

    public void Play()
    {
        audioPlayer.Play();
        movieTexture.Play();
    }

    public void Pause()
    {
        audioPlayer.Pause();
        movieTexture.Pause();
    }  

    IEnumerator DownloadMovie()
    {
        
        //WWW www = new WWW("file://D://ScreenDisplay//123.ogv");
        Debug.LogError(videoUrl);
        WWW www = new WWW(videoUrl);
        movieTexture = WWWAudioExtensions.GetMovieTexture(www);

        while (!movieTexture.isReadyToPlay)
            yield return www;

        image.texture = movieTexture;//视频纹理 
        audioPlayer.clip = movieTexture.audioClip;//音频  

        yield return new WaitForSeconds(1);
        Play();
    }  

    // Update is called once per frame
    void Update()
    {
       // // Audio Track Enable
       // for (int i = 0; i <= audioTrackCount - 1; i++)
       // {
       //     vPlayer.EnableAudioTrack((ushort)i, false);
       // }
       // vPlayer.EnableAudioTrack(audioTrackNum, true);
       // vPlayer.SetTargetAudioSource(audioTrackNum, vAudio);

       // // Set Vdeo Output to Camera Front Plane
       // vAudio.volume = soundVolume;
       // //if (vPlayer.gameObject.GetComponent<Camera>() != null)
       ////     vPlayer.renderMode = VideoRenderMode.CameraFrontPlane;

       // // Set Vdeo Output to RawImage
       // vSurface = vPlayer.gameObject.GetComponent<RawImage>();
       // if (vSurface != null)
       //     vSurface.texture = vPlayer.texture;

       // // Prepare Video & Play
       // if (play)
       // {
       //     vPlayer.Prepare();
       //     vPlayer.Play();
       // }
       // else vPlayer.Stop();
    }
}