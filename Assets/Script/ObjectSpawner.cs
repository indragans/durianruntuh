using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float timer = 1;
    public GameObject[] go;
    public float[] objRate;
    public float jeda;
    void Start()
    {
        
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            int chance = Random.Range(1, 101);
            float pos_x = Random.Range(-2.0f, 2.0f);

            if (chance <= objRate[1])
            {
                Instantiate(go[1], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }
            else if (chance <= objRate[0])
            {
                Instantiate(go[0], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }
            else if (chance <= objRate[3])
            {
                Instantiate(go[0], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }

            timer = jeda;
        }
    }
}
