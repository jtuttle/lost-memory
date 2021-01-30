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
                target.MarkDone();

                setPlayerMovement(false);

                subtitle.GetComponent<Text>().text = target.Text;

                target.Sound.Play();

                StartCoroutine(WaitForSound(target.Sound));
            }
        }
    }

    public IEnumerator WaitForSound(AudioSource sound)
    {
        yield return new WaitUntil(() => sound.isPlaying == false);
        
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
