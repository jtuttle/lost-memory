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
                subtitle.GetComponent<Text>().text = "Oh, it's a " + target.name;

                target.Sound.Play();

                target.MarkDone();

                setPlayerMovement(false);

                setPlayerMovement(true);
            }
        }
    }


    private void setPlayerMovement(bool value)
    {
        gameObject.GetComponent<FirstPersonMovement>().enabled = value;
        gameObject.GetComponent<Jump>().enabled = value;
        gameObject.GetComponent<Crouch>().enabled = value;

        gameObject.GetComponentInChildren<FirstPersonLook>().enabled = value;
    }
}
