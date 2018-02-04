using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkyForce;

namespace SkyForce
{

    public class Enemy : MonoBehaviour
    {

        public int ShieldPower = 5;
        public GameObject StatusBar;
        public GameObject CompleteLabel;

        public GameObject StarCluster;

        // public EnemyAsStars est;

        public int BigStarCount = 1;
        public int SmallStarCount = 4;

        public float ExplodePowerStars = 0.2f;


        float statusscaleX100;
        float progressStep;
        float barStep;

        //public GameObject BigStar;
        //public GameObject SmallStar;
        //public GameObject StarCluster;


        // Use this for initialization
        void Start()
        {

            statusscaleX100 = StatusBar.transform.localScale.x;
            // progressStep = 100 / ShieldPower;
            barStep = statusscaleX100 / ShieldPower;


        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider col)
        {
            //Debug.Log("Collision Detected");

            if (col.gameObject.tag == "Bullet")
            {
                Bullet bullet = col.gameObject.GetComponent<Bullet>();

                if (!bullet.isEnemyBullet)
                {
                    Debug.Log("its a player bullet");

                    ShieldPower = ShieldPower - bullet.hurtIntensity;

                    Destroy(col.gameObject);

                    //Label
                    CompleteLabel.SetActive(true);

                    StatusBar.transform.localScale = new Vector3(StatusBar.transform.localScale.x - barStep, StatusBar.transform.localScale.y, StatusBar.transform.localScale.z);

                    Debug.Log("Enemy Hitted, Shield-Power: " + ShieldPower.ToString());

                    if (ShieldPower <= 0)
                    {
                        Destroy(gameObject);
                        explodeStars();

                    }
                }
            }

        }

        public void explodeStars()
        {
            //StarCluster.transform.position = transform.position;
            //GameObject starcluster = Resources.Load("StarCluster") as GameObject;
            StarCluster.GetComponent<EnemyToStars>().instantiateAllStars(transform.position);
            //starcluster.transform.position = transform.position;
            //EnemyToStars ets = new EnemyToStars();
            // EnemyToStars t = new EnemyToStars(this.gameObject, BigStarCount, SmallStarCount,BigStar,SmallStar, ExplodePowerStars);
        }
    }
}
