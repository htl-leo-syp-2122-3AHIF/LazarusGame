using UnityEngine;

public class Bone : MonoBehaviour
{
    private BoneDodger _boneDodger;
    private float SPEED = 15;
    private Vector3 _moveTowards;
    private bool _isMoving;
    private BoxCollider2D _gridArea;

    // Start is called before the first frame update
    void Start()
    {
        _boneDodger = (BoneDodger)GameObject.Find("BoneDodger").GetComponent("BoneDodger");
        _gridArea = (BoxCollider2D)GameObject.Find("GridArea").GetComponent<BoxCollider2D>();
        _moveTowards = Vector3.zero;
        _isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_isMoving)
            this.Rotate();
        this.Move();
    }

    private void Rotate()
    {
        var dir = _boneDodger.transform.position - transform.position;
        var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move()
    {
        if (_moveTowards == Vector3.zero)
        {
            _moveTowards = this.gameObject.transform.position - _boneDodger.gameObject.transform.position;
            _moveTowards = _moveTowards.normalized;
        }
        _isMoving = true;
        this.gameObject.transform.position -= (_moveTowards) * SPEED * Time.deltaTime;
    }
    private void RandomizePosition()
    {
        Bounds bounds = this._gridArea.bounds;
        float x = this.gameObject.transform.position.x;
        float y = this.gameObject.transform.position.y;
        do
        {
            x = Random.Range(bounds.min.x, bounds.max.x);
            y = Random.Range(bounds.min.y, bounds.max.y);
        } while (Vector3.Distance(new(x, y), this.gameObject.transform.position) > 1);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "BoneDodger" && collision.tag != "Bone")
        {
            this.RandomizePosition();
            _isMoving = false;
            _moveTowards = Vector3.zero;
            _boneDodger.Points++;
        }
    }
}
