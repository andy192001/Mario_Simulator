using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Max(cameraPos.x, player.position.x); // For only right move camera. We calculate max about player pos.
        transform.position = cameraPos;
    }
}
