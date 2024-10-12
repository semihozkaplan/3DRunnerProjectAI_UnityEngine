using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject RestartPanel;
    Vector3 PlayerStartPos;
    public GameObject speedBoostIcon;

    private InGameRanking ig;

    private void Start()
    {

        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoostIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();

    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("finish"))
        {

            if (ig.namesTxt[6].text == "Player")
            {
                PlayerFinish();
                Debug.Log("You Win!!");
            }

            else
            {
                PlayerFinish();
                Debug.Log("You Lose!!");
            }

        }

        if (other.CompareTag("speedboost"))
        {
            playerController.runningSpeed += 3f;
            speedBoostIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            transform.position = PlayerStartPos;
        }
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {

        yield return new WaitForSeconds(2f);
        playerController.runningSpeed -= 3f;
        speedBoostIcon.SetActive(false);

    }

    void PlayerFinish()
    {

        playerController.runningSpeed = 0f;
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        RestartPanel.SetActive(true);
        GameManager.instance.isGameOver = true;

    }

}
