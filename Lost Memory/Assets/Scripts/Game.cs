using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private StoryTracker _storyTracker;

    void Start()
    {
        _storyTracker = GetComponentInChildren<StoryTracker>();
    }

    void Update()
    {
        //Debug.Log(_storyTracker.IsDone());
    }
}
