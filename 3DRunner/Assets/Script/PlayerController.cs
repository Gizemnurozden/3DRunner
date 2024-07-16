using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedRunnig;
    float touchXDelta;
    float newX;
    public float xSpeed;
    public float limitX; //sağa ve sola gidişte limite ihtiyacım var.



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) //ekranda dokunma sayısını kontrol eder sağa ve sola hareketi kontrol eder.phase ile
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width; //dokunulan yöne göre oyuncuma yeni pozisyon atar.

        }
        else if (Input.GetMouseButton(0)) //telefonu bağlamazsak fare ile kontrol etme.
        {
            touchXDelta = Input.GetAxis("Mouse X"); //mouse ile yaptığım yöne doğru ayarlar
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime; //x'imin posizyonunu günceller yeni x, hızı ve dokunudpum pozisyonun eklenmesi
        newX = Mathf.Clamp(newX, -limitX, limitX); //Clamp kullarak sınır belirledik hareket edeceği sağa sola. 

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + speedRunnig * Time.deltaTime);
        transform.position = newPosition;
    }
}
