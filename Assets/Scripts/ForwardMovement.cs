using UnityEngine;


public class ForwardMovement : MonoBehaviour {

    //public Transform target;
    public float speed = 50f;
    
    
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float step = speed * Time.deltaTime;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + step);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);


        //Debug.Log(transform.position);

    }
}
