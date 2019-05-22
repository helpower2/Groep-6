using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMover : MonoBehaviour
{
    private Transform target;
    public void SetTarget(GameObject _target)
    {
        target = _target.transform;
        this.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, this.transform.position.z);
        
    }
}
