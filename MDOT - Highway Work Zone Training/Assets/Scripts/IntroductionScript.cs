using UnityEngine;

public class IntroductionScript : MonoBehaviour
{
    private int count = 0;
    private GameObject VideoPlayer;
    public AudioSource PracticeSuccess;

    private void Start() {
        VideoPlayer = GameObject.Find("Video Player");
    }

    private void Update() {
        if (!PracticeSuccess.isPlaying && count == 0) { 
            VideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
            count++;
        }
    }
}
