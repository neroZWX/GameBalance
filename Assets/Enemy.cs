using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image HpBar;
    public float MaxHp = 100;
    private float NowHp;

    void Start()
    {
        NowHp = MaxHp;
        
    }

    // Update is called once per frame
    void Update()
    {    
        if (NowHp <= 0) {

            Destroy(this.gameObject);
            
        }
        HpBar.fillAmount = NowHp / MaxHp;

    }
   public  void TakeDamage(int damage) {
        this.NowHp -= damage;
        
    }
}
