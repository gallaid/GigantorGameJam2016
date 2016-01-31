using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponsSystem : MonoBehaviour {
    private int payLoad;
    public Bullet bullet;
    public float fireRate=0.5f;
    public float speedOfProjectile;
    public float rechargeSpeedFront;
    public float nextTime = 0.0f;
    private float rechargeSpeed;

    private float charge;
    
    

    public Slider DistanceSlider;

	// Use this for initialization
	void Start () {
        payLoad = 1;
        
	}
	// Update is called once per frame
	void Update () {
        rechargeSpeed =rechargeSpeedFront /100;
       
            ChargeShot();
        
        
        
        //DistanceSlider.value += rechargeSpeed;
        
	}
    void fire(float charge)
    {
        if (CanFire())
        {
            Bullet projectile = Instantiate(bullet, gameObject.transform.position+Vector3.up*3, Quaternion.identity) as Bullet;
            projectile.Discharged(payLoad, charge);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            rb.AddRelativeForce(Vector2.up *speedOfProjectile);
            
        }    
    }
    bool CanFire()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + fireRate;
            return true;
        }
        else return false;
    }
    void ChargeShot()
    {
        if (Input.GetButton("Fire1"))
        {
            charge += rechargeSpeed * 2;
            DistanceSlider.value = charge;
            charge = Mathf.Clamp(charge, 1, 5);
        }else if (Input.GetButtonUp("Fire1"))
        {
            fire(charge);
        }
        else
        {
            Recharge();
        }
    }
    void Recharge()
    {
        charge -= rechargeSpeed;
        DistanceSlider.value = charge;
    }

}
