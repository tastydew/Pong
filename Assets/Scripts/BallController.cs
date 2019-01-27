using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D ball;
    public float ballForce;
    public AudioSource gameOverAudio;
    private float directionToStart;
    [SerializeField]
    private float ballX;
    // Use this for initialization
    void Start ()
    {

        ball = GetComponent<Rigidbody2D>();
        LaunchBallInRandomDirection();
    }

    private void LaunchBallInRandomDirection()
    {
        directionToStart = Random.Range(0f, 1f);
        ball.velocity = Vector2.zero;
        if (directionToStart >= 0.5f)
        {
            ball.AddForce(new Vector2(ballForce, ballForce), ForceMode2D.Impulse);
        }
        if (directionToStart < 0.5f)
        {
            ball.AddForce(new Vector2(-ballForce, -ballForce), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update () {
        ballX = ball.transform.localPosition.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            ballForce += 0.75f;
            var paddlePositionHit = Mathf.Sign(collision.gameObject.transform.localPosition.y - ball.transform.localPosition.y);

            switch (Mathf.Sign(ballX).ToString()) {

                case "-1":
                    //ball hit top half of paddle
                    if (paddlePositionHit == 1)
                    {
                        ball.velocity = new Vector2(ballForce, -ballForce);
                    }
                    //ball hit bottom half of paddle
                    if (paddlePositionHit == -1)
                    {
                        ball.velocity = new Vector2(ballForce, ballForce);
                    }
                    break;
                case "1":
                    if (paddlePositionHit == 1)
                    {
                        ball.velocity = new Vector2(-ballForce, -ballForce);
                    }
                    if (paddlePositionHit == -1)
                    {
                        ball.velocity = new Vector2(-ballForce, ballForce);
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
            ball.velocity = Vector2.zero;
            ball.transform.localPosition = Vector2.zero;
            gameOverAudio.Play();
        }
    }

    private void ResetBallPosition()
    {
        ball.transform.localPosition = Vector2.zero;
        ballForce = 4;
        LaunchBallInRandomDirection();
    }
}
