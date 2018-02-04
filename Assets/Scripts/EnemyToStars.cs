using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkyForce
{
    public class EnemyToStars: MonoBehaviour
    {

        public int BigStarCount = 1;
        public int SmallStarCount = 4;

        public float minDist = 0.1f;
        public float maxDist = 1.0f;

        public GameObject BigStar;
        public GameObject SmallStar;

        float ExplodePowerStars;

        //GameObject Enemy;

        //// Use this for initialization
        public void Start()
        {
           // instantiateAllStars();

        }
        //public EnemyToStars(GameObject enemy, int bigStarCount,int smallStarCount, GameObject bigStar, GameObject smallStar, float explodePowerStars)
        //{
        //    BigStar = bigStar;
        //    SmallStar = smallStar;
        //    BigStarCount = bigStarCount;
        //    SmallStarCount = smallStarCount;
        //    Enemy = enemy;
        //    ExplodePowerStars = explodePowerStars;
        //    instantiateAllStars();
        //}


        public void instantiateAllStars(Vector3 pos)
        {

            float flyingDist = Random.Range(minDist, maxDist);

            for (int i = 0; i <= BigStarCount; i++)
            {
                GameObject star = Object.Instantiate(BigStar);

                Vector3 euler = star.transform.eulerAngles;
                euler.y = Random.Range(0.0f, 360.0f);
                star.transform.position = pos;
                star.transform.eulerAngles = euler;

                //BigStar.transform.position = Enemy.transform.position;

                Rigidbody rb = star.GetComponent<Rigidbody>();
                rb.AddForce(star.transform.forward * flyingDist, ForceMode.Impulse);
            }

            for (int i = 0; i <= SmallStarCount; i++)
            {
                GameObject star = Object.Instantiate(SmallStar);

                Vector3 euler = star.transform.eulerAngles;
                euler.y = Random.Range(0.0f, 360.0f);
                star.transform.position = pos;

                star.transform.eulerAngles = euler;


                Rigidbody rb = star.GetComponent<Rigidbody>();
                rb.AddForce(star.transform.forward * flyingDist, ForceMode.Impulse);

            }

        }
    }
}