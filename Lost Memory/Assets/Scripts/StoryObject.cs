using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : MonoBehaviour
{
    public AudioSource Sound;
    public string Text;

    private cakeslice.Outline _outline;
    private bool _done;

    void Start()
    {
        // assumes first child is object model w/ Outline script
        _outline = gameObject.transform.GetChild(0).GetComponent<cakeslice.Outline>();
        _outline.enabled = false;

        _done = false;
    }

    void Update()
    {
        
    }

    public void SetOutline(bool value)
    {
        _outline.enabled = value;
    }

    public void MarkDone()
    {
        _done = true;
    }

    public bool IsDone()
    {
        return _done;
    }
}
