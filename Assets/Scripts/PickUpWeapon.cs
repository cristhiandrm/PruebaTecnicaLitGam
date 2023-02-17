using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [Header("Configuration")]
    public float pickUpRange;
    public Transform player;    
    public int tipeOfWeapon;

    [SerializeField]private ShotWeapon shotWeapon;

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) pickUp();
    }

    private void pickUp()
    {
        shotWeapon.weaponSelected = tipeOfWeapon;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
