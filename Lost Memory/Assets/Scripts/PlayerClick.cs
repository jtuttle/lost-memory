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
            GameObject target = playerRaycast.GetTarget();
            
            if(target)
            {
                subtitle.GetComponent<Text>().text = "Oh, it's a " + target.name;
            }
        }
    } 
}
