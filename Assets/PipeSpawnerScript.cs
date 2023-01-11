using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 9;
    private float lowestHeight;
    private float highestHeight;
    // Start is called before the first frame update
    void Start()
    {
        lowestHeight = transform.position.y - heightOffset;
        highestHeight = transform.position.y + heightOffset;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestHeight, highestHeight), 0), transform.rotation);
    }
}
