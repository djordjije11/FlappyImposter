using Assets;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float minHeight = -16;
    private float maxHeight = 16;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x + Random.Range(0, 20), Random.Range(minHeight, maxHeight), 0);
        var randomScaleSize = 1 + Random.Range(0, 150) / 100;
        transform.localScale = new Vector3(randomScaleSize, randomScaleSize, randomScaleSize);
        spriteRenderer.flipX = Random.Range(1, 2) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        MovingScript.Move(gameObject, MovingScript.movingSpeed);
    }
}
