﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : MonoBehaviour
{
    public List<string> Subtitles;
    public List<float> SubtitleStartSeconds;
    
    private cakeslice.Outline[] _outlines;

    void Start()
    {
        _outlines = GetComponentsInChildren<cakeslice.Outline>();
        SetOutline(false);
    }

    public void SetOutline(bool value)
    {
        foreach(cakeslice.Outline outline in _outlines) {
            outline.enabled = value;
        }
    }
}
