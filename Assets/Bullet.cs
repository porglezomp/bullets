using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    Vector3 pos;
    Vector3 vel;
    float mass;

	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(pos, vel, out hit, vel.magnitude * Time.deltaTime)) {
            pos = hit.point;
            vel = Vector3.Reflect(vel, hit.normal);
            // Handle hit
        } else {
            pos += vel * Time.deltaTime;
            vel += Physics.gravity * Time.deltaTime;
        }
        
        // Display
        transform.position = pos;
        // Debug.DrawRay(pos, -vel * Time.deltaTime * 3);
	}
}
