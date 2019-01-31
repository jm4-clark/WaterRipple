using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRain : MonoBehaviour {
    public GameObject objectToSpawn;
    public float delay;
    public float MaxScale, MinScale;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnObjects());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnObjects()
    {
        while(true)
        {
            GameObject ObjectMade = Instantiate(objectToSpawn,new Vector3(Random.Range(-50.0f,50.0f),Random.Range(40.0f,60.0f),Random.Range(-50.0f, 50.0f)),Quaternion.identity);
            float randScale = Random.Range(MinScale, MaxScale);
            ObjectMade.transform.localScale = Vector3.one * randScale;
            ObjectMade.GetComponent<Rigidbody>().mass *= randScale;
            yield return new WaitForSeconds(delay);
        }
    }
}
