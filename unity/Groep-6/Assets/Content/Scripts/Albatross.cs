using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Albatross : MonoBehaviour
{
    private bool goingRight = true;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        StartCoroutine(SwitchGoingRight());
    }
    private void Update()
    {
        var pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x += (goingRight ? 2f : -2f) * Time.deltaTime, pos.y, pos.z); 
    }

    IEnumerator SwitchGoingRight()
    {
        yield return new WaitForSeconds(10f);
        goingRight = !goingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        StartCoroutine(SwitchGoingRight());
    }
}
