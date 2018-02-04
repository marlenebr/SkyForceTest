using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    bool isLabelEnabled;
    public float timeForLabelVisibility = 2.0f; //in seconds
    public int ShieldPower = 20;

    public GameObject CompleteLabel;
    public GameObject StatusBar;
    float barStep;
    float statusscaleX100;





    float actualTimeLeftWithLabel = 0.0f;


	// Use this for initialization
	void Start () {
        statusscaleX100 = StatusBar.transform.localScale.x;
        barStep = statusscaleX100 / ShieldPower;
    }
	
	// Update is called once per frame
	void Update () {



        if(isLabelEnabled)
        {
            CompleteLabel.transform.position = new Vector3(transform.position.x +1f, transform.position.y, transform.position.z + 0.5f);


            actualTimeLeftWithLabel += Time.deltaTime;
            if(actualTimeLeftWithLabel > timeForLabelVisibility)
            {
                CompleteLabel.SetActive(false);
                isLabelEnabled = false;
                actualTimeLeftWithLabel = 0f;
            }

        }
		
	}


    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Collision Detected");

        if (col.gameObject.tag == "Bullet")
        {
            Bullet bullet = col.gameObject.GetComponent<Bullet>();

            if (bullet.isEnemyBullet)
            {
                Debug.Log("player got hit :(");

                ShieldPower = ShieldPower - bullet.hurtIntensity;

                Destroy(col.gameObject);

                //Label
                isLabelEnabled = true;
                CompleteLabel.SetActive(true);

                StatusBar.transform.localScale = new Vector3(StatusBar.transform.localScale.x - barStep, StatusBar.transform.localScale.y, StatusBar.transform.localScale.z);

                Debug.Log("Player Shield-Power: " + ShieldPower.ToString());

                if (ShieldPower <= 0)
                {
                    Destroy(gameObject);


                }
            }
        }

    }


}
