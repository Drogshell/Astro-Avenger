using UnityEngine;

public class BackgroundMeasure : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Draw a line from the top to the bottom of the sprite to measure height
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y / 2, transform.position.z),
            new Vector3(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2, transform.position.z));
    }
}
