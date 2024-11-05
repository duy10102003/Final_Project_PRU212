using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimatedSpriteRenderer start;
    public AnimatedSpriteRenderer middle;
    public AnimatedSpriteRenderer end;

    public void SetActiveRenderer(AnimatedSpriteRenderer renderer)
    {
        start.enabled = renderer == start;
        middle.enabled = renderer == middle;
        end.enabled = renderer == end;
    }

    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void DestroyAfter(float seconds)
    {
        Destroy(gameObject, seconds);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("s");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MovementController>().Removehealth();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("s");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MovementController>().Removehealth();
        }
    }
}
