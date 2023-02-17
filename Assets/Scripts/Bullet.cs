using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configuration")]
    float timeBeforeDestroy = 5f;
    public LayerMask whatIsEnemies;

    [Header("Explotion Options")]
    public GameObject explosion;
    public float explosionRange;
    public float explosionForce;

    private Rigidbody rb;
    private bool target;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        timeBeforeDestroy -= Time.deltaTime;
        if (timeBeforeDestroy <= 0|| Input.GetKeyDown(KeyCode.Q)) Explode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (target)
            return;
        else
            target = true;

        
        rb.isKinematic = true;
        transform.SetParent(collision.transform);
    }

    private void Explode()
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        Destroy(gameObject, 0.1f);
    }
}
