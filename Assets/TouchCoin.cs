using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCoin : MonoBehaviour
{
    public AudioSource coin;
    public AudioSource obst;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Вы умерли");
        }
        else if(collision.gameObject.tag == "Bonus") 
        {
            Debug.Log("+ монетка");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            PlayCollisionSound();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().useGravity = true;
            Restart();
        }
        else if (other.gameObject.tag == "Bonus")
        {
            PlayCoinSound();
            Destroy(other.gameObject);
        }
    }

    void PlayCoinSound()
    {
        coin.Play();
    }

    void PlayCollisionSound()
    {
        obst.Play();
    }

    void Restart()
    {
        StartCoroutine("Fade");

    }

    IEnumerator Fade()
    {
         yield return new WaitForSeconds(1f);
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
