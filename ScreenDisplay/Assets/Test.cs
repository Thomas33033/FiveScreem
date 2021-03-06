using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class Test : MonoBehaviour {

    public RawImage image;
    public MovieTexture movieTexture;
    public AudioSource audioPlayer;
    private float movietime;

    void Start()  
    {  
      StartCoroutine(DownloadMovie());   
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
       Debug.Log("Pause");  
   
    }  
   
   public void Stop()  
    {
       audioPlayer.Stop();  
       movieTexture.Stop();   
    }  
   

   IEnumerator DownloadMovie()  
   {
       WWW www = new WWW("file://D://ScreenDisplay//123.ogv");  
       movieTexture = WWWAudioExtensions.GetMovieTexture(www);
   
       while(!movieTexture.isReadyToPlay)  
            yield return www;

       image.texture = movieTexture;//视频纹理 
       audioPlayer.clip = movieTexture.audioClip;//音频  

       yield return new WaitForSeconds(1);
       Play();  
    }  


}
