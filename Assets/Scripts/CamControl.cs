using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if (target!=null)
        {
            transform.position = target.position + offset;
        }
    }
}
