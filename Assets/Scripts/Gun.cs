using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkyForce
{
    public class Gun : MonoBehaviour
    {

        public GameObject bullet;
        public float ShootingInterval = 1.0f; //in seconds
        int bulletCountPerGroup = 0;

        float lastShootesBulletTime;

        public bool isEnemyGun = true;



        public void SetShootingIntervall(float interval)
        {

            ShootingInterval = interval;
        }



        // Use this for initialization
        void Start()
        {


            bullet.transform.position = transform.position;
            // bullet.GetComponent<Bullet>().isEnemyBullet = isEnemyGun;
            lastShootesBulletTime = 0;

        }

        // Update is called once per frame
        void FixedUpdate()
        {

            updateBulletShooting();


        }

        public virtual void updateBulletShooting()
        {
            lastShootesBulletTime += Time.deltaTime;
            if (lastShootesBulletTime >= ShootingInterval)
            {


                shootBullet();
                lastShootesBulletTime = 0f;

            }


        }

        public virtual void shootBullet()
        {

            //shoot normal in looking-dir
            bullet.transform.forward = this.transform.forward;
            bullet.transform.position = transform.position;
            Instantiate(bullet);


        }


    }
}