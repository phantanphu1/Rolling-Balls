using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject block;
    void Update()
    {
        if (transform.position.y < -6f && block != null)
        {
            block.SetActive(false);
        }
    }
}
