using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    Vector3 resetPosition = Vector3.zero;
    void Start()
    {
        transform.position = resetPosition;
        print(transform.gameObject + " position reset to " + resetPosition);
    }
}
