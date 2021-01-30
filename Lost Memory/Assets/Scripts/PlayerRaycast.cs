﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float distanceToSee;

    private StoryObject _target;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(
            this.transform.position,
            this.transform.forward * distanceToSee,
            Color.magenta
        );

        RaycastHit hitInfo;

        bool hit = Physics.Raycast(
            this.transform.position,
            this.transform.forward,
            out hitInfo,
            distanceToSee
        );

        // remove outline from previous target
        if(_target && (!hit || (_target != hitInfo.collider.gameObject)))
        {
            _target.SetOutline(false);
            _target = null;
        }

        if(hit)
        {
            _target = hitInfo.collider.gameObject.GetComponent<StoryObject>();
            _target.SetOutline(true);
        }
    }

    public StoryObject GetTarget() {
        return _target;
    }
}
