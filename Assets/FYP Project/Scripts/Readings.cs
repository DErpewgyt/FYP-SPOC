using TMPro;
using UnityEngine;

public class Readings : MonoBehaviour
{
    public TextMeshProUGUI LvlComplete;
    public TextMeshProUGUI LvlCompleteDesc;
    public int randomIndex;

    public GameObject object1;
    private float[] Answer1 = { 9.76f, 9.84f };

    public GameObject object2;
    private float[] Answer2 = { 7.43f, 7.73f };

    public GameObject object3;
    private float[] Answer3 = { 7.98f, 7.57f };

    public GameObject object4;
    private float[] Answer4 = { 10.91f, 8.80f };

    public GameObject object5;
    private float[] Answer5 = { 7.64f, 7.78f };

    public GameObject object6;
    private float[] Answer6 = { 7.78f, 7.97f };

    public GameObject object7;
    private float[] Answer7 = { 9.75f, 9.28f };

    public GameObject object8;
    private float[] Answer8 = { 9.91f, 7.92f };

    public GameObject object9;
    private float[] Answer9 = { 8.17f, 7.93f };

    public GameObject object10;
    private float[] Answer10 = { 10.34f, 8.56f };

    public bool IslevelComplete = false;
    public float V;
    public float H;

    public TMP_InputField inputFieldTop;
    public TMP_InputField inputFieldBottom;

    public GameObject textgrp;
    public GameObject inputgrp;

    public bool IsTopCorrect = false;
    public bool IsBottomCorrect = false;
    public bool IsBothCorrect = false;

    public bool isTopFieldActive;
    public bool isBottomFieldActive;

    public bool IsTextInField;

    private void Start()
    {
        // Set all game objects to inactive initially
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
        object4.SetActive(false);
        object5.SetActive(false);
        object6.SetActive(false);
        object7.SetActive(false);
        object8.SetActive(false);
        object9.SetActive(false);
        object10.SetActive(false);

        // Randomly activate one of the game objects
        randomIndex = Random.Range(1, 11);
        SelectGameObject(randomIndex);

    }


    private void Update()
    {
        if(inputFieldTop.text == "" || inputFieldBottom.text == "")
        {
            IsTextInField = false;
        } else
        {
            IsTextInField = true;
        }

        if (!IsBothCorrect)
        {
            LvlComplete.text = "Measurements are Incorrect";
            LvlCompleteDesc.text = "You can retry or go back to the main menu.\r\n";
        } else
        {
            LvlComplete.text = "Measurements are Correct";
            LvlCompleteDesc.text = "You can retry or go back to the main menu.\r\n";
        }
    }




    private void SelectGameObject(int RandomInt)
    {
        switch (RandomInt)
        {
            case 1:
                object1.SetActive(true);
                SetAnswers(object1, Answer1);
                break;

            case 2:
                object2.SetActive(true);
                SetAnswers(object2, Answer2);
                break;

            case 3:
                object3.SetActive(true);
                SetAnswers(object3, Answer3);
                break;

            case 4:
                object4.SetActive(true);
                SetAnswers(object4, Answer4);
                break;

            case 5:
                object5.SetActive(true);
                SetAnswers(object5, Answer5);
                break;

            case 6:
                object6.SetActive(true);
                SetAnswers(object6, Answer6);
                break;

            case 7:
                object7.SetActive(true);
                SetAnswers(object7, Answer7);
                break;

            case 8:
                object8.SetActive(true);
                SetAnswers(object8, Answer8);
                break;

            case 9:
                object9.SetActive(true);
                SetAnswers(object9, Answer9);
                break;

            case 10:
                object10.SetActive(true);
                SetAnswers(object10, Answer10);
                break;
        }
    }

    private void SetAnswers(GameObject Readings, float[] AnsArray)
    {
        V = AnsArray[0];
        H = AnsArray[1];
    }

    public void CheckAns()
    {
        if (IsTextInField)
        {

            inputgrp.SetActive(false);
            textgrp.SetActive(false);

            string topInput = inputFieldTop.text;
            string bottomInput = inputFieldBottom.text;

            // Convert the input strings to floats
            float topValue, bottomValue;

            float.TryParse(topInput, out topValue);
            float.TryParse(bottomInput, out bottomValue);

            print(topValue + 1.23);
            print(bottomValue + 18);

            if(topValue == V)
            {
                print("yay");
                IsTopCorrect = true;
            }

            if(bottomValue == H)
            {
                print("yay2");
                IsBottomCorrect = true;
            }

            if(topValue == V && bottomValue == H) {
                print("Yay3");
                IsBothCorrect = true;
            }
        }

    }

    public void TopIsActive()
    {
        isTopFieldActive = true;
    }

    public void TopIsNotActive()
    {
        isTopFieldActive = false;
    }

    public void BottomIsActive()
    {
        isBottomFieldActive = true;
    }

    public void BottomIsNotActive()
    {
        isBottomFieldActive = false;
    }



}
