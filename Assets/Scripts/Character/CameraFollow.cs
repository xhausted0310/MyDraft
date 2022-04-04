using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        Vector3 _temp = transform.position;
        _temp.x = player.transform.position.x;
        _temp.y = player.transform.position.y;
        transform.position = _temp;


    }

}
