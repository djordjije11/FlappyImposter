using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets
{
    public static class MovingScript
    {
        public static float movingSpeed;

        public static void Move(GameObject gameObject, float speed, float deadZone = -40)
        {
            if (gameObject.transform.position.x < deadZone)
            {
                Object.Destroy(gameObject);
            }
            gameObject.transform.position = gameObject.transform.position + Vector3.left * speed * Time.deltaTime;    //Time.deltaTime nam sluzi da brzina igrice ne bi zavisila od Frame rate-a!!!
        }
    }
}
