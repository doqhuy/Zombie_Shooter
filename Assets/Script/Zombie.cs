using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Player _player;
    private float _speed;           //Tốc độ thực của zombie

    public float BaseSpeed;         //Tốc độ căn cứ
    public GameObject BloodPrefab;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = BaseSpeed * (1 + Random.Range(-0.1f, 0.1f));   //Tạo các tốc độ khác nhau
        _player = FindObjectOfType<Player>();                   //Player
    }

    void Update()
    {
        if(_player != null )
        {
            transform.up = (_player.transform.position - transform.position).normalized;    //Tìm đường đến player: Vị trí player - vị trí đang đứng
            _rigidbody.velocity = (Vector2)(transform.up * _speed);
        }
    }
    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);  //Hiệu ứng khi die
        Destroy(gameObject);                                                //Xóa object
    }
}
