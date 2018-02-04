using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoundGun : Gun {

    // Use this for initialization
    public int NumberOfCircleBullets = 4;

    public override void shootBullet()
    { 
    int angleBetweenBullets = (int)(360 / NumberOfCircleBullets);

        for (int i = 0; i < NumberOfCircleBullets; i++)
        {

            bullet.transform.forward = this.transform.forward;
            bullet.transform.Rotate(new Vector3(0,angleBetweenBullets * i,0));
            bullet.transform.position = transform.position;
            Instantiate(bullet);
        }
    }

}
