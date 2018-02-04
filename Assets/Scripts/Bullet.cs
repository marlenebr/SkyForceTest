using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkyForce
{
    public class Bullet : MonoBehaviour
    {


        // public GameObject bulletObj;
        public int hurtIntensity = 1;
        public float bulletScale = 0.3f;
        public float livingTime = 2.0f; //in seconds
        public float speed = 0.2f;

        float actualLivingTime;

        public bool isEnemyBullet;

        // Use this for initialization
        void Start()
        {

            transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
            actualLivingTime = 0f;
        }



        // Update is called once per frame
        void Update()
        {

            transform.position = new Vector3(transform.position.x + speed * gameObject.transform.forward.x, transform.position.y + speed * gameObject.transform.forward.y, transform.position.z + speed * gameObject.transform.forward.z);
            actualLivingTime += Time.deltaTime;
            if (actualLivingTime >= livingTime)
            {
                //Destroy Bullet after allowed living Time
                Destroy(gameObject);

            }


        }
    }
}