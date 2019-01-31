using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFloat : MonoBehaviour {
    
    public GameObject[] floatObjects;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        floatObjects = GameObject.FindGameObjectsWithTag("Floater");
	}
	
	void FixedUpdate () {
       
        foreach (GameObject obj in floatObjects)
        {
            Vector3 pos = obj.transform.position;
            if (pos.y - this.transform.position.y < 
                rend.material.GetFloat("_Scale") * Mathf.Sin((Time.time * rend.material.GetFloat("_Speed") + ((pos.x * pos.x) + (pos.z * pos.z)) * rend.material.GetFloat("_Frequency"))))
            {
               
                obj.GetComponent<Rigidbody>().AddForce((Vector3.up * (obj.GetComponent<Rigidbody>().mass * 0.75f)* Mathf.Abs(pos.y - this.transform.position.y)));// * obj.GetComponent<Rigidbody>().mass);
                //Debug.Log("Floating up with force " + (Vector3.up * 100 * (pos.y - this.transform.position.y)));// * (obj.GetComponent<Rigidbody>().mass)).ToString());
            }
            else
            {
                obj.GetComponent<Rigidbody>().AddForce(Vector3.down * Physics.gravity.y * Mathf.Abs(pos.y - this.transform.position.y) );// * (obj.GetComponent<Rigidbody>().mass * 0.98f));
                //Debug.Log("Floating down with force " + (Vector3.down * Physics.gravity.y * Mathf.Abs(pos.y - this.transform.position.y)).ToString());// * (obj.GetComponent<Rigidbody>().mass) * 0.98f).ToString());
            }
        }
	}
}
