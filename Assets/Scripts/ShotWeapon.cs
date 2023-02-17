using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotWeapon : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform spawnAmmo;
    [SerializeField] protected WeaponScritableObject[] weaponScritableObject;

    [Header("Weapon Selection")]
    public int weaponSelected;

    [Header("Shooting")]
    public KeyCode shotKey = KeyCode.Mouse0;
    public KeyCode rechargeKey = KeyCode.R;
    bool readyToShoot;

    [Header("Text On Screen")]
    public TextMeshProUGUI munnition;
    public TextMeshProUGUI weaponName;

    private void Start()
    {
        readyToShoot = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(shotKey) && readyToShoot && weaponScritableObject[weaponSelected].totalMunitions > 0)
        {
            Shoot();
        }
        if (Input.GetKeyDown(rechargeKey) && weaponScritableObject[weaponSelected].totalMunitions < weaponScritableObject[weaponSelected].rechargableMunition)
        {
            Recharge();
        }

        if (munnition != null)
        {
            munnition.SetText(weaponScritableObject[weaponSelected].totalMunitions + "/" + weaponScritableObject[weaponSelected].rechargableMunition);
        }
        if (weaponName != null)
        {
            weaponName.SetText(weaponScritableObject[weaponSelected].weaponName);
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //instantiate bullet
        GameObject bullet = Instantiate(weaponScritableObject[weaponSelected].bulletPrefab, spawnAmmo.position, cam.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        //add force
        Vector3 bulletForce = cam.transform.forward * weaponScritableObject[weaponSelected].force + transform.up * weaponScritableObject[weaponSelected].upwardForce;

        bulletRb.AddForce(bulletForce, ForceMode.Impulse);

        weaponScritableObject[weaponSelected].totalMunitions--;

        //Cooldown Between Shoots
        Invoke(nameof(ResetShot), weaponScritableObject[weaponSelected].fireRate);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Recharge()
    {
        weaponScritableObject[weaponSelected].totalMunitions = weaponScritableObject[weaponSelected].rechargableMunition;
    }

}
