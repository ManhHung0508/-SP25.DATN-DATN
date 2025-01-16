using UnityEngine;

public class PlayerConlision : MonoBehaviour
{
    private Gamemanager gamemanager;

    private void Awake(){
        gamemanager = FindAnyObjectByType<Gamemanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Coin")){
            Destroy(collision.gameObject);
            gamemanager.AddScore(1);
        
        }
    }
}
