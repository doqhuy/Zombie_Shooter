using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float Speed;             // Tốc độ viên đạn

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);    //Xóa đối tượng khi xuất hiện quá 4f
    }

    void Update()
    {
        _rigidbody.velocity = (Vector2)(transform.up * Speed);  //Điều chỉnh tốc độ đạn bắn
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var zombie = other.collider.GetComponent<Zombie>();     //Xác nhận va chạm với zombie
        if (zombie != null)
        {
            zombie.Die();       //Zombie die
        }
        Destroy(gameObject);    //Xóa viên đạn
    }
}
