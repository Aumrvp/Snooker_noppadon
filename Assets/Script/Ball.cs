using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BallColors
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}

public class Ball : MonoBehaviour
{
    
    [SerializeField] private BallColors ballColors;
    [SerializeField] private MeshRenderer rd;
    [SerializeField] private int point;
    public int Point { get { return point; } }

    private void Awake()
    {
        rd = GetComponent<MeshRenderer>();
    }

    public void SetColorAndPoint(BallColors colors)
    {
        switch (colors)
        {
            case BallColors.White: point = 0;
                rd.material.color = Color.white;
                break;
            case BallColors.Red: point = 1;
                rd.material.color = Color.red;
                break;
            case BallColors.Yellow: point = 2;
                rd.material.color = Color.yellow;
                break;
            case BallColors.Green: point = 3;
                rd.material.color = Color.green;
                break;
            case BallColors.Brown: point = 4;
                rd.material.color = new Color32(139,69,19,255);
                break;
            case BallColors.Blue: point = 5;
                rd.material.color = Color.blue;
                break;
            case BallColors.Pink: point = 6;
                rd.material.color = new Color32(255,192,203,1);
                break;
            case BallColors.Black: point = 7;
                rd.material.color = Color.black;
                break;
        }
    }
}