using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public Transform FirePoint;
    public int Laserdamage = 50;
    public int LaserLessDamage = 5;
    public GameObject BulletPrefab;
    public GameObject Laser;
    public LineRenderer lineRender;
    public int GoldCoins = 100;
    public Text GoldCoinsText;
    private Enemy enemy;
    public GameObject BulletEffect;

    // Update is called once per frame
    private void Start()
    {
         enemy = gameObject.GetComponent<Enemy>();
        
        
     }
    void Update()
    {   
        if (Input.GetButtonDown("Fire1")){
            Shoot();
          
        }
        if (Input.GetMouseButtonDown(1)) {
            StartCoroutine(LaserShoot());
        }
    }
 
    void  Shoot() {
        if (GoldCoins >=2)
        {
           
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            GoldCoins = GoldCoins - 2;
            GoldCoinsText.text = "            " + GoldCoins;
        }

        
    }

    IEnumerator LaserShoot()
    {
        if (GoldCoins >= 5)
        {

            GoldCoins = GoldCoins - 5;
            GoldCoinsText.text = "            " + GoldCoins;
            RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);

            if (hitInfo)
            {
                enemy = hitInfo.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    if (enemy.gameObject.layer == 8)
                        enemy.TakeDamage(Laserdamage);
                        
                    if (enemy.gameObject.layer == 9)
                        enemy.TakeDamage(LaserLessDamage);
                        print("Please use Rifle!");
                }
                Instantiate(BulletEffect, hitInfo.point, Quaternion.identity);
                Instantiate(Laser, hitInfo.point, Quaternion.identity);
                Debug.Log(hitInfo.transform.name);

                lineRender.SetPosition(0, FirePoint.position);
                lineRender.SetPosition(1, hitInfo.point);
            }
            lineRender.enabled = true;

            yield return new WaitForSeconds(0.05f);
            lineRender.enabled = false;
        }
    }
}
