using UnityEngine;

public class kalptakip : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, offset.y, transform.position.z);
    }
}
