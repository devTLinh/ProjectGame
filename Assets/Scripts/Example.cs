using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake was called");
    }
    void Start()
    {
        Debug.Log("Start was called");
    }

    // Update is called once per frame
    // cập nhập liên tục với thời gian thay đổi
    void Update()
    {
        Debug.Log("Update was called");
    }
    // 50 times per second
    // cập nhập liên tục với thời gian cố định
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate was called");
    }
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
