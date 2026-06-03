using UnityEngine;

public class ClickSoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void ReproducirClick()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}