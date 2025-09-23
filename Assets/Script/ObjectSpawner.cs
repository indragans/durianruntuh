using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float timer = 1f;
    public GameObject[] go;    // [0]=Durian Normal, [1]=Jebakan, [2]=Durian Emas
    public float[] objRate;    // [0]=Bobot Normal, [1]=Bobot Jebakan, [2]=Bobot Emas
    public float jeda = 1.5f;

    void Update()
    {
        if (timer > 0f) { timer -= Time.deltaTime; return; }

        if (go == null || go.Length < 3 || objRate == null || objRate.Length < 3)
        {
            Debug.LogWarning("ObjectSpawner: isi array 'go' & 'objRate' minimal 3 elemen.");
            timer = jeda;
            return;
        }

        float pos_x = Random.Range(-2.0f, 2.0f);

        float w0 = Mathf.Max(0f, objRate[0]);
        float w1 = Mathf.Max(0f, objRate[1]);
        float w2 = Mathf.Max(0f, objRate[2]);
        float total = w0 + w1 + w2;
        if (total <= 0f) total = 1f;

        float r = Random.Range(0f, total);
        int index = (r < w0) ? 0 : (r < w0 + w1 ? 1 : 2);

        Instantiate(go[index], new Vector3(pos_x, 6.0f, 0.1f), Quaternion.identity);
        timer = jeda;
    }
}
