using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;


    public InventorySystem inventory;
    public Transform weaponTransform;
    public SpriteRenderer spriteRendererWeapon;
    
    public float rotationSpeed;

    public Weapon? targetWeapon = null;

    public GameObject firePoint;
    public GameObject bulletPref;

    public void SetWeapon(Weapon weapon)
    {
        targetWeapon = weapon;
        spriteRendererWeapon.sprite = weapon.itemSprite;
    }


    void Update()
    {
        Vector3 direction = joystick.Direction;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation.y = 0f;
            targetRotation.x = 0f;
            weaponTransform.rotation = targetRotation;
        }
    }

    public void Shoot ()
    {
        if (targetWeapon != null)
        {

            if (inventory.RemoveBullet())
            {
                var bul = Instantiate(bulletPref);
                bul.transform.position = firePoint.transform.position;
                bul.transform.rotation = firePoint.transform.rotation;
                FindAnyObjectByType(typeof(InventoryUI)).GetComponent<InventoryUI>().UpdateInventoryUI();
            }
            else
            {
                // No Bullets
            }
        }
        else
        {
            // No Weapon
        }
    }
}
