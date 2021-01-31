using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject GameOver;

    private StoryTracker _storyTracker;

    void Start()
    {
        _storyTracker = GetComponentInChildren<StoryTracker>();
    }

    void Update()
    {
        if(_storyTracker.IsDone()) {
            GameOver.SetActive(true);
            gameObject.GetComponentInChildren<PlayerClick>().enabled = false;
        }
    }
}
