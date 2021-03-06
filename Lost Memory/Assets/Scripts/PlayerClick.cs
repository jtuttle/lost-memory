﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public PlayerRaycast PlayerRaycast;
    
    private StoryPlayer _storyPlayer;
    private StoryTracker _storyTracker;

    void Start()
    {
        _storyPlayer = gameObject.GetComponent<StoryPlayer>();
        _storyTracker = gameObject.GetComponent<StoryTracker>();
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

    private void OnStoryComplete(StoryObject target)
    {
        _storyPlayer.StoryCompleteEvent.RemoveListener(OnStoryComplete);

        _storyTracker.TrackStoryObject(target);

        setPlayerMovement(true);
    }

    private void setPlayerMovement(bool value)
    {
        gameObject.GetComponent<FirstPersonMovement>().enabled = value;
        gameObject.GetComponent<Jump>().enabled = value;
        gameObject.GetComponentInChildren<FirstPersonLook>().enabled = value;
    }
}
