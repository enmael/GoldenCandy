using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
 public GameManager gameManager;
    [SerializeField] int number = 0;
    public float speed = 1f; 
    
    void Update()
    {
        if (transform.position.y < 3)
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if(gameManager.ArrayScize  == number)
        {
            gameManager.puzzleClear = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (number < gameManager.PuzzleArray.Length)
        {
            if (collision.CompareTag("Puzzle") || collision.CompareTag("Candy"))
            {
                gameManager.puzzleArray[number] = collision.gameObject;
                gameManager.puzzleArrayTransform[number]= collision.gameObject.transform.position;
                number++;

            }
        }
    }
}
