using UnityEngine;

public class weaponShoot : MonoBehaviour
{
    [SerializeField] Sprite weaponIdle;
    [SerializeField] Sprite weaponAim;
    [SerializeField] Sprite weaponFire;
    [SerializeField] GameObject projectile;
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject originPoint;
    float weaponTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponTimer -= Time.deltaTime;
        if (weaponTimer <= 0)
        {
            UnityEngine.UI.Image weaponImage = GetComponent<UnityEngine.UI.Image>();
            if (Input.GetMouseButton(0))
            {
                weaponImage.sprite = weaponAim;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Instantiate(projectile,originPoint.transform.position,originPoint.transform.rotation);
                weaponImage.sprite = weaponFire;
                weaponTimer = cooldown;
            }
            else
            {
                weaponImage.sprite = weaponIdle;
            }
        }
    }
}
