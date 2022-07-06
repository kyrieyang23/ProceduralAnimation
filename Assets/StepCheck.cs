using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCheck : MonoBehaviour
{
    public float dis = 0.1f;
    public float shift = 0.03f;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + (Vector3.up * shift), Vector3.down * dis, Color.green);
        Ray ray = new Ray(transform.position + (Vector3.up * shift), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, dis))
        {
            transform.position = info.point;
        }
    }
}
