using UnityEngine;

public class weaponShoot : MonoBehaviour
{
    [SerializeField] Sprite weaponIdle;
    [SerializeField] Sprite weaponAim;
    [SerializeField] Sprite weaponFire;
    [SerializeField] GameObject projectile;
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
                drawTimer = 50f;
                GetComponent<AudioSource>().Play();
            }
            if (Input.GetMouseButton(1))
            {
                drawTimer -= 15 * Time.deltaTime;
                if (drawTimer < 1){drawTimer = 1;}
                weaponImage.sprite = weaponAim;
                weaponImage.transform.localScale = new Vector3( 1+ ((50 - drawTimer) / 50) * .6f,1,1);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                Instantiate(projectile,originPoint.transform.position,originPoint.transform.rotation).GetComponent<bullet>().speed = 50 - drawTimer;
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
