using UnityEngine;

public class AirshipWobble : MonoBehaviour
{
    private float startY;

    private void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, startY + Mathf.Sin(Time.time) * 10f, transform.position.z);
    }
}
