using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject player;
    private Animator playerAnimator;
    void Start()
    {
        player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 1.5f, -10);

        playerAnimator = player.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("jump");
        }

        Vector3 position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (position.x > -2)
            {
                playerAnimator.SetTrigger("left");
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {   
            if (position.x != 2)
            {
                playerAnimator.SetTrigger("right");
            }
        }
    }


}
