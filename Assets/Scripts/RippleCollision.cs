using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleCollision : MonoBehaviour
{
    private int waveNum;
    public float distanceX, distanceZ;
    public float[] waveAmp;
    public float magnitudeDivider;
    public Vector2[] impactPos;
    public float[] distance;
    public float speedWaveSpread;

    Mesh mesh;
   

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < 8; i++)
        {
            waveAmp[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmplitude" + (i + 1));
            if (waveAmp[i] > 0)
            {
                distance[i] += speedWaveSpread;
                GetComponent<Renderer>().material.SetFloat("_Distance" + (i + 1), distance[i]);
                GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), waveAmp[i] * 0.98f);
            }
            if (waveAmp[i] < 0.01)
            {
                GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), 0);
                distance[i] = 0;
            }
        }
    }

    //void OnCollisionEnter(Collision col)
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Rigidbody>())
        {
            waveNum++;
            if (waveNum == 9)
            {
                waveNum = 1;
            }
            waveAmp[waveNum - 1] = 0;
            distance[waveNum - 1] = 0;

            distanceX = this.transform.position.x - col.gameObject.transform.position.x;
            distanceZ = this.transform.position.z - col.gameObject.transform.position.z;

            impactPos[waveNum - 1].x = col.transform.position.x;
            impactPos[waveNum - 1].y = col.transform.position.z;

            GetComponent<Renderer>().material.SetFloat("_xImpact" + waveNum, col.transform.position.x);
            GetComponent<Renderer>().material.SetFloat("_zImpact" + waveNum, col.transform.position.z);


            GetComponent<Renderer>().material.SetFloat("_OffsetX" + waveNum, distanceX / mesh.bounds.size.x * 2.5f);
            GetComponent<Renderer>().material.SetFloat("_OffsetZ" + waveNum, distanceZ / mesh.bounds.size.z * 2.5f);

            GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + waveNum, col.GetComponent<Rigidbody>().velocity.magnitude * magnitudeDivider);

            if (col.gameObject.tag == "Rain")
            {
                Destroy(col.GetComponent<Collider>().gameObject);
            }
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleCollision : MonoBehaviour
{
    private int waveNum;
    public float[] distanceX, distanceZ;
    public float[] waveAmp;
    public float magnitudeDivider;
    public Vector2[] impactPos;
    public float[] distance;
    public float speedWaveSpread;

    Mesh mesh;
    public List<float> waveAmpList = new List<float>(50);
    public float[] impactXPos;
    public float[] impactZPos;
    public float[] zeroArray;
    public float[] magnitudeArray;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {

        
        //GetComponent<Renderer>().material.GetFloatArray("_WaveAmplitude"[0], waveAmpList);
        GetComponent<Renderer>().material.GetFloatArray("_WaveAmplitude", waveAmpList);

        waveAmp = waveAmpList.ToArray();

        for (int i = 0; i < 50; i++)//GetComponent<Renderer>().material.GetInt("_ArraySize"); i++)
        {
            //GetComponent<Renderer>().material.GetFloatArray("_WaveAmplitude"[i], waveAmpList);
            //waveAmp[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmplitude" + (i + 1));
            waveAmp[i] = waveAmpList[i];
            zeroArray[i] = waveAmp[i];
            magnitudeArray[i] = waveAmp[i];
            if (waveAmp[i] > 0)
            {
                distance[i] += speedWaveSpread;
                
                GetComponent<Renderer>().material.SetFloatArray("_Distance", distance);
                
                waveAmp[i] *= 0.98f;
                GetComponent<Renderer>().material.SetFloatArray("_WaveAmplitude", waveAmp);
            }
            if (waveAmp[i] < 0.01)
            {
                zeroArray[i] = 0;
                GetComponent<Renderer>().material.SetFloatArray("_WaveAmplitude", zeroArray);
                distance[i] = 0;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            waveAmp[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmplitude" + (i + 1));
            if (waveAmp[i] > 0)
            {
                distance[i] += speedWaveSpread;
                GetComponent<Renderer>().material.SetFloat("_Distance" + (i + 1), distance[i]);
                GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), waveAmp[i] * 0.98f);
            }
            if (waveAmp[i] < 0.01)
            {
                GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), 0);
                distance[i] = 0;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.rigidbody)
        {
            waveNum++;
            if (waveNum == 50)
            {
                waveNum = 1;
            }
            waveAmp[waveNum - 1] = 0;
            distance[waveNum - 1] = 0;

            distanceX[waveNum - 1] = this.transform.position.x - col.gameObject.transform.position.x;
            distanceZ[waveNum - 1] = this.transform.position.z - col.gameObject.transform.position.z;
            
            impactXPos[waveNum - 1] = col.transform.position.x;
            impactZPos[waveNum - 1] = col.transform.position.z;

            
            GetComponent<Renderer>().material.SetFloatArray("_xImpact", impactXPos);
            
            GetComponent<Renderer>().material.SetFloatArray("_zImpact", impactZPos);



            distanceX[waveNum - 1] = distanceX[waveNum - 1] / mesh.bounds.size.x * 2.5f;
            GetComponent<Renderer>().material.SetFloatArray("_OffsetX", distanceX);

            distanceZ[waveNum - 1] = distanceZ[waveNum - 1] / mesh.bounds.size.z * 2.5f;
            GetComponent<Renderer>().material.SetFloatArray("_OffsetZ", distanceZ);


            magnitudeArray[waveNum - 1] = col.rigidbody.velocity.magnitude * magnitudeDivider;
            GetComponent<Renderer>().material.SetFloatArray("_WaveAmplitude", magnitudeArray);
            if (col.gameObject.tag == "Rain")
            {
                Destroy(col.collider.gameObject);
            }
        }
    }
}*/

