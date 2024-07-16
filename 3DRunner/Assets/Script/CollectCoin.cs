using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject); //temas edince kayboluyor.gameobject değil other gameobject
            AddCoin();
        }
        else if (other.CompareTag("End"))
        {
           
            //Debug.Log("Congrats..!");
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self); //oyuncu animasyonu yüzünü dönerek yapıyor.yeni rotasyonla ayarlandı.
            playerController.speedRunnig = 0; //end e çarpınca durmasnı istediğim için hızı sıfırladım.
            EndPanel.SetActive(true);
            if (score >= maxScore)
            {
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                PlayerAnim.SetBool("lose", true); 
            }
        }
    }

    public void RestartGame() //restart butonu içins
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collision"))
        {
           // Debug.Log("touched..");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //engellere değince oyun yeniden başlasın diye 
        }
    }

    public void AddCoin()
    {
        score++;
        coinText.text = "Score : " + score.ToString();
    }
}
