using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float ballForce;
    public AudioSource gameOverAudio;
    private float directionToStart;
    [SerializeField]
    private float ballX;
    // Use this for initialization
    void Start ()
    {

        rb2d = GetComponent<Rigidbody2D>();
        LaunchBallInRandomDirection();
    }

    private void LaunchBallInRandomDirection()
    {
        directionToStart = Random.Range(0f, 1f);
        rb2d.velocity = Vector2.zero;
        Debug.Log(directionToStart);
        if (directionToStart >= 0.5f)
        {
            rb2d.AddForce(new Vector2(ballForce, ballForce), ForceMode2D.Impulse);
        }
        if (directionToStart < 0.5f)
        {
            rb2d.AddForce(new Vector2(-ballForce, -ballForce), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update () {

        ballX = rb2d.transform.localPosition.x;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            ballForce += 0.75f;
            var calculation = Mathf.Sign(collision.gameObject.transform.localPosition.y - rb2d.transform.localPosition.y);

            Debug.Log("Paddle Position: " + collision.gameObject.transform.localPosition.y);
            Debug.Log("Ball Position: " + rb2d.transform.localPosition.y);
            Debug.Log("Paddle/Ball calculation: " + calculation);
            Debug.Log(Mathf.Sign(ballX));


            switch (Mathf.Sign(ballX).ToString()) {


                case "-1":
                    //ball hit top half of paddle
                    if (calculation == 1)
                    {
                        rb2d.velocity = new Vector2(ballForce, -ballForce);
                    }
                    //ball hit bottom half of paddle
                    if (calculation == -1)
                    {
                        rb2d.velocity = new Vector2(ballForce, ballForce);
                    }
                    break;
                case "1":
                    if (calculation == 1)
                    {
                        rb2d.velocity = new Vector2(-ballForce, -ballForce);
                    }
                    if (calculation == -1)
                    {
                        rb2d.velocity = new Vector2(-ballForce, ballForce);
                    }
                    break;
            }
            
        }

        if (collision.collider.tag == "Player1Goal")
        {
            GameController.playerTwoScore += 1;
            ResetBallPosition();
        }
        if (collision.collider.tag == "Player2Goal")
        {
            GameController.playerOneScore += 1;
            ResetBallPosition();
        }

        CheckForGameOver();

    }

    private void CheckForGameOver()
    {
        if (GameController.playerOneScore == 10 || GameController.playerTwoScore == 10)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.transform.localPosition = Vector2.zero;
            gameOverAudio.Play();
        }
    }

    private void ResetBallPosition()
    {
        rb2d.transform.localPosition = Vector2.zero;
        ballForce = 2;
        LaunchBallInRandomDirection();

    }
}
