using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;
    public int PlayerScore { get; set; }
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPosition;

    [SerializeField] private GameObject cueBall;

    [SerializeField] private GameObject ballLine;

    [SerializeField] private float xInput;

    [SerializeField] private float force;
    [SerializeField] private GameObject camera;

    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        camera = Camera.main.gameObject;
        CameraBehindBall();
        
        UpdeteScoreText();
        
        //set ball on the table
        //Setballs(BallColors.White, 0);
        Setballs(BallColors.Red, 1);
        Setballs(BallColors.Pink, 2);
        Setballs(BallColors.Blue, 3);
        Setballs(BallColors.Green, 4);
        Setballs(BallColors.Yellow, 5);
        Setballs(BallColors.Brown, 6);
        Setballs(BallColors.Black, 7);
    }

   public void UpdeteScoreText()
   {
       scoreText.text = $"Player Score:{PlayerScore}";
    }

    void Setballs(BallColors colors, int pos)
    {
        GameObject ball = Instantiate(ballPrefab, ballPosition[pos].transform.position, Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPoint(colors);
    }

    // Update is called once per frame
    void Update()
    {
RotateBall();
if (Input.GetKeyDown(KeyCode.Space))
{
    ShootBall();
}

if (Input.GetKeyDown(KeyCode.G))
{
    StopBall();
}

    
}
    

    void RotateBall()

    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput/10,0f));
    }

    void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward *force,ForceMode.Impulse);
        ballLine.SetActive(false);
    }

    void CameraBehindBall()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0f, 20f, -15);
    }
void StopBall()
{
    Rigidbody rd = cueBall.GetComponent<Rigidbody>();
    rd.velocity = Vector3.zero;
    rd.angularVelocity = Vector3.zero;
    cueBall.transform.eulerAngles = Vector3.zero;
    CameraBehindBall();
    camera.transform.eulerAngles = new Vector3(40f, 0f, 0f);
    ballLine.SetActive(true);
}
}
