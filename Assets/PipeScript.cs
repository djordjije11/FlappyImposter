using Assets;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    //public float startSpeed = 20;
    private float deadZone = -40;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovingScript.Move(gameObject, MovingScript.movingSpeed, deadZone);
    }
}
