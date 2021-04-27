using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreActions : MonoBehaviour
{
    [SerializeField] private Text textL;
    [SerializeField] private Text textR;


    public void AddLeftScore() { textL.text = (int.Parse(textL.text)+1).ToString(); }
    public void AddRightScore() { textR.text = (int.Parse(textR.text) + 1).ToString(); }
}


