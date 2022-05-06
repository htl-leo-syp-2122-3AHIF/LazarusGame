using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D _gridArea;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private int SPEED = 10;

    private void Start()
    {
        RandomizePosition();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = (Vector3.Normalize(_rigidbody.velocity) * SPEED);
    }

    private void RandomizePosition()
    {
        Bounds bounds = this._gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with: " + collision.tag);
        if (collision.tag != "Untagged")
            RandomizePosition();
    }
}
