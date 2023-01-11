using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject Cloud;
    public float spawnRate = 3;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cloud);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(Cloud);
            if(Random.Range(0,1) == 1)
                Instantiate(Cloud);
            timer = 0;
            spawnRate = Random.Range(1, 2);
        }
    }
}
