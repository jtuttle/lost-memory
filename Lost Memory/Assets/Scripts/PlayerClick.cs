using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public PlayerRaycast PlayerRaycast;
    
    private StoryPlayer _storyPlayer;

    void Start()
    {
        _storyPlayer = gameObject.GetComponent<StoryPlayer>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !_storyPlayer.IsPlaying())
        {
            StoryObject target = PlayerRaycast.GetTarget();
            
            if(target)
            {
                OnTargetClick(target);
            }
        }
    }

    private void OnTargetClick(StoryObject target)
    {
        setPlayerMovement(false);

        _storyPlayer.StoryCompleteEvent.AddListener(OnStoryComplete);
        
        _storyPlayer.PlayStory(target);
    }

    private void OnStoryComplete()
    {
        _storyPlayer.StoryCompleteEvent.RemoveListener(OnStoryComplete);

        setPlayerMovement(true);
    }

    private void setPlayerMovement(bool value)
    {
        gameObject.GetComponent<FirstPersonMovement>().enabled = value;
        gameObject.GetComponent<Jump>().enabled = value;
        gameObject.GetComponentInChildren<FirstPersonLook>().enabled = value;
    }
}
