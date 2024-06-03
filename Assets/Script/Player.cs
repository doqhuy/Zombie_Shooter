using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _input;

    public float Speed;             //Tốc độ di chuyển
    public GameObject BulletPrefab; //Đạn
    public Transform GunPoint;      //Điểm đạn được bắn
    public GameObject BloodPrefab;  //Hiệu ứng

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));               //Nhận đầu vào các nút di chuyển
        _rigidbody.velocity = _input.normalized * Speed;                                            //Tùy chỉnh tốc độ di chuyển
        transform.up = (MouseUtils.GetMousePosition2d() - (Vector2)transform.position).normalized;  //Chỉnh Vector2 quay theo chuột

        if (Input.GetButtonDown("Fire1"))                                   //Nhận đầu vào là chuột trái để bắn
            Shoot();
    }
    private void Shoot()
    {
        Instantiate(BulletPrefab, GunPoint.position, transform.rotation);   //Điểm đạn xuất hiện
    }
    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);  //Hiệu ứng khi die
        FindObjectOfType<TMP_Text>().enabled = true;                        //Xuất hiện dòng chữ reset
        Destroy(gameObject);                                                //Xóa object
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        var zombie = other.collider.GetComponent<Zombie>();                 //Xác nhận va chạm với zombie
        if(zombie != null)
            Die();
    }
}
