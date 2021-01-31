using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float DistanceToSee;

    private StoryObject _target;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(
            this.transform.position,
            this.transform.forward * DistanceToSee,
            Color.magenta
        );

        RaycastHit hitInfo;
        StoryObject target = null;

        bool hit = Physics.Raycast(
            this.transform.position,
            this.transform.forward,
            out hitInfo,
            DistanceToSee
        );

        if(hit)
        {
            target = hitInfo.collider.gameObject.GetComponent<StoryObject>();
        }

        // remove outline from previous target
        if(_target && (!hit || (_target != target)))
        {
            _target.SetOutline(false);
            _target = null;
        }
        
        if(hit)
        {
            if(target && target != _target)
            {
                _target = target;
                _target.SetOutline(true);
            }
        }
    }

    public StoryObject GetTarget() {
        return _target;
    }
}
