using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStones : MonoBehaviour
{
    float moveSpeed = 3f; // Tốc độ di chuyển của đối tượng
    public Vector2 targetPosition; // Vị trí đích của đối tượng
    Timer timer;
        public float minSize =1f; // kích thước nhỏ nhất
    public float maxSize = 3f; // kích thước lớn nhất

    void Start()
    {  
        targetPosition = new Vector2(Random.Range(-70, 70), -60);
        float randomSize = Random.Range(minSize, maxSize); // tạo kích thước ngẫu nhiên trong khoảng từ minSize đến maxSize
        transform.localScale = new Vector3(randomSize, randomSize, 1f); // thiết lập kích thước cho đối tượng
    }
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = new Vector2(Random.Range(-70, 70), -60);
        }
        if (transform.position.y <=-23)
        {   
            Destroy(gameObject);
        }
    }
}
