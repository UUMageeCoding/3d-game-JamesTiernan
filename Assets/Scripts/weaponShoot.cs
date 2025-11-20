using UnityEngine;

public class weaponShoot : MonoBehaviour
{
    [SerializeField] Sprite weaponIdle;
    [SerializeField] Sprite weaponAim;
    [SerializeField] Sprite weaponFire;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    [SerializeField] float drawSpeed;
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] Transform originPoint;
    float weaponTimer = 0f;
    float drawTimer = 0f;
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
            if (Input.GetMouseButtonDown(1))
            {
                weaponImage.transform.localScale = new Vector3(1,1,1);
                drawTimer = projectileSpeed;
                GetComponent<AudioSource>().Play();
            }
            if (Input.GetMouseButton(1))
            {
                drawTimer -= drawSpeed * Time.deltaTime;
                if (drawTimer < 0){drawTimer = 0;}
                weaponImage.sprite = weaponAim;
                weaponImage.transform.localScale = new Vector3( 1+ ((projectileSpeed - drawTimer) / projectileSpeed) * .3f,1,1);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                Instantiate(projectile,originPoint.transform.position,originPoint.transform.rotation).GetComponent<bullet>().speed = projectileSpeed - drawTimer;
                weaponImage.sprite = weaponFire;
                weaponTimer = cooldown;
            }
            else
            {
                weaponImage.sprite = weaponIdle;
                weaponImage.transform.localScale = new Vector3(1,1,1);
            }
        }
    }
}
