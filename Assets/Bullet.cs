using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 initVel;
    Vector3 pos;    // m/s
    Vector3 vel;    // m/s
    float mass;     // kg
    float density;  // g/cm³
    float length;   // m

	// Use this for initialization
	void Start () {
        vel = initVel;
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(pos, vel, out hit, vel.magnitude * Time.deltaTime)) {
            pos = hit.point;
            Vector3 normal = Vector3.Dot(vel, hit.normal) * hit.normal;
            Vector3 tangent = vel - normal;
            if (hit.collider.material.name == "Default (Instance)") {
                vel = Vector3.Reflect(vel, hit.normal);
            } else {
                vel = tangent * (1-hit.collider.material.dynamicFriction) -
                      normal  * hit.collider.material.bounciness;
            }
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
