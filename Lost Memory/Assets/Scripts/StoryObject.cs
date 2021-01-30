using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : MonoBehaviour
{
    public List<string> Subtitles;
    public List<float> SubtitleStartSeconds;
    
    private cakeslice.Outline _outline;

    void Start()
    {
        // assumes first child is object model w/ Outline script
        _outline = gameObject.transform.GetChild(0).GetComponent<cakeslice.Outline>();
        _outline.enabled = false;
    }

    void Update()
    {
        
    }

    public void SetOutline(bool value)
    {
        _outline.enabled = value;
    }
}
