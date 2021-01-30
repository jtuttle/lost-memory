using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClick : MonoBehaviour
{
    public PlayerRaycast playerRaycast;
    public UnityEngine.UI.Text subtitle;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StoryObject target = playerRaycast.GetTarget();
            
            if(target)
            {
                OnTargetClick(target);
            }
        }
    }

    private void OnTargetClick(StoryObject target)
    {
        setPlayerMovement(false);

        subtitle.GetComponent<Text>().text = target.Text;

        AudioSource sound = target.GetComponent<AudioSource>();
        sound.Play();
        StartCoroutine(WaitForSound(sound));
    }

    private IEnumerator WaitForSound(AudioSource sound)
    {
        yield return new WaitUntil(() => sound.isPlaying == false);
        
        OnSoundComplete();
    }

    private void OnSoundComplete()
    {
        subtitle.GetComponent<Text>().text = "";
        setPlayerMovement(true);
    }

    private void setPlayerMovement(bool value)
    {
        gameObject.GetComponent<FirstPersonMovement>().enabled = value;
        gameObject.GetComponent<Jump>().enabled = value;
        gameObject.GetComponent<Crouch>().enabled = value;

        gameObject.GetComponentInChildren<FirstPersonLook>().enabled = value;
    }
}
