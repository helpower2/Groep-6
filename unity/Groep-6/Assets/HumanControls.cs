using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControls : MonoBehaviour
{
    public GameObject human;
    public void SetTarget(GameObject Target)
    {
        if (human != null)
        {
            human.GetComponent<HumanMover>().SetTarget(Target);
            human = null;
        }
    }
    public void SetHuman(GameObject _human)
    {
        human = _human;
    }
}
