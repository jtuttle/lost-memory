using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float distanceToSee;

    private GameObject target;

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
        if(target && (!hit || (target != hitInfo.collider.gameObject)))
        {
            setOutline(target, false);
            target = null;
        }

        if(hit)
        {
            target = hitInfo.collider.gameObject;
            setOutline(target, true);
        }
    }

    private void setOutline(GameObject go, bool value) {
        cakeslice.Outline outline = go.GetComponent<cakeslice.Outline>();

        if(outline) {
            outline.eraseRenderer = !value;
        }
    }
}
