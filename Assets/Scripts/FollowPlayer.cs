using UnityEngine;

namespace SkyForce
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform playercontainer;
        public Vector3 offset;



        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position = new Vector3(0, 0, playercontainer.position.z) + offset;
        }
    }
}