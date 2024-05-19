using UnityEngine;

public class kameratakip : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x,0, transform.position.z);
        }
    }
}
