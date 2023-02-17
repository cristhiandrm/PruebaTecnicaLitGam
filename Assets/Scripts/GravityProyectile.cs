using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityProyectile : MonoBehaviour
{
    [Header("Configuration")]
    public float pullRadio;
    public float gravityForce;
    public float minRadio;
    public float distanceMultiplier;
    public float maxLifetime;

    public LayerMask layerToPull;

    private void Update()
    {
        Destroy(gameObject, maxLifetime);
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadio, layerToPull);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb == null) continue;

            Vector3 direction = transform.position - collider.transform.position;

            if (direction.magnitude < minRadio) continue;

            float distance = direction.sqrMagnitude * distanceMultiplier + 1;


            rb.AddForce(direction.normalized * (gravityForce / distance) * rb.mass * Time.fixedDeltaTime*30);

        }
    }
}
