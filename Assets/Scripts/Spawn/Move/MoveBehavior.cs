using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    [SerializeField] private Vector2 despawner;
    [SerializeField] private float modifier;
    [SerializeField] private float smoothTime;
    [SerializeField] private Vector2 velocity;

    private void Start()
    {
        StartCoroutine(MoveTo());
    }

    private IEnumerator MoveTo()
    {
        while (transform.position.x > despawner.x && transform.position.y > despawner.y)
        {
            Vector2 newPosition = transform.position + transform.up * -1 * modifier;
           
            transform.position = Vector2.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
            
            yield return new WaitForFixedUpdate();
        }
        
        CallDespawn();
    }

    private void CallDespawn()
    {
        GetComponentInParent<Spawner>().Despawn(gameObject);
    }
}
