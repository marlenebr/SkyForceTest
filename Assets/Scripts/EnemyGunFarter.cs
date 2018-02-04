using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkyForce
{

    public class EnemyGunFarter : Gun
    {


        public float RotatingSpeed = 0.01f;
        public float WaitBetweenBulletGroup = 1.0f;
        public int BulletsPerGroup = 6;

        int groupBulletCount = 0;
        float lastShootTimeeft = 0f;


        public override void updateBulletShooting()
        {
            lastShootTimeeft += Time.deltaTime;
            if (lastShootTimeeft >= ShootingInterval)
            {

                if (groupBulletCount < BulletsPerGroup)
                {
                    shootBullet();
                    lastShootTimeeft = 0f;
                    groupBulletCount++;


                }
                else
                {
                    lastShootTimeeft = -WaitBetweenBulletGroup;
                    groupBulletCount = 0;
                }
            }

            Transform playertrans = GameObject.FindWithTag("Player").transform;
            Vector3 targetDir = playertrans.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, RotatingSpeed, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDir);
        }


    }
}