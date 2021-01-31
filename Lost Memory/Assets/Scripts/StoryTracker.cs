using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTracker : MonoBehaviour
{
    private List<string> _progress;

    void Start()
    {
        _progress = new List<string>();
    }

    void Update()
    {
        Debug.Log(_progress.Count);
    }

    public void TrackStoryObject(StoryObject storyObject)
    {
        string name = storyObject.gameObject.name;

        if(!_progress.Contains(name)) {
            _progress.Add(name);
        }
    }

    public bool IsDone()
    {
        return _progress.Count == 9;
    }
}
