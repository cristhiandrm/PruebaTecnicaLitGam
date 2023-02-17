using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", order = 1)]
public class WeaponScritableObject : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Weapon Configuration")]
    public string weaponName;
    public float fireRate;

    [Header("Ammo Configuration")]
    public int totalMunitions;
    public int rechargableMunition;
    [SerializeField]
    public GameObject bulletPrefab;
    public float force;
    public float upwardForce;

    void Init()
    {

    }

    public void OnBeforeSerialize()
    {
        Init();
    }

    public void OnAfterDeserialize()
    {

    }
     
}
