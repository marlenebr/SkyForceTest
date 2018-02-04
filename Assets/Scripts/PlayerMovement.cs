using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Reference to the rigid body component
    public Rigidbody rb;
    public float forwardForce = 30000f;
    public float sidewaysForce = 30000f;
    public float banking = 25f;
    public float lerpTime = 1f;
   
    Quaternion startRotation;
    Vector3 targetRotation;

    float b;
    float sf;
    float ff;

    // Use this for initialization
    void Start () {
        startRotation = transform.rotation;     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //-----> Get Key-Input
        if (Input.GetKey(KeyCode.D))
        {  
            b = banking;
            sf = sidewaysForce;
            ff = 0;       
        }
        else if (Input.GetKey(KeyCode.A))
        {
            b = -banking;
            sf = -sidewaysForce;
            ff = 0;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            b = 0;
            sf = 0;
            ff = forwardForce;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            b = 0;
            sf = 0;
            ff = -forwardForce;
        }
        else
        {
            b = 0;
            sf = 0;
            ff = 0;
        }

      
        //-----> Add forward/backward force
        rb.AddForce(0, 0, ff * Time.deltaTime/*, ForceMode.VelocityChange*/);
        //-----> Add sideward force
        rb.AddForce(sf * Time.deltaTime, 0, 0/*, ForceMode.VelocityChange*/);
        //-----> Add banking
        targetRotation = new Vector3(startRotation.eulerAngles.x, startRotation.eulerAngles.y, startRotation.eulerAngles.z + -b);
        transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(targetRotation), lerpTime);


        //dont leave screen
        // z distance of player from camera
        float zDist = Vector3.Distance(Camera.main.transform.position, transform.position);
        Vector3 pUpperRight = Camera.main.ViewportToWorldPoint(new Vector3(1,1, zDist));
        Vector3 pLowLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDist));

        if (transform.position.x > pUpperRight.x-1)
        {
            transform.position = new Vector3(pUpperRight.x-1, transform.position.y, transform.position.z);

        }

        if (transform.position.z > pUpperRight.z-1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pUpperRight.z-1);

        }

        if (transform.position.x < pLowLeft.x+1)
        {
            transform.position = new Vector3(pLowLeft.x+1, transform.position.y, transform.position.z);

        }

        if (transform.position.z < pLowLeft.z+1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pLowLeft.z+1);

        }


    }
}
