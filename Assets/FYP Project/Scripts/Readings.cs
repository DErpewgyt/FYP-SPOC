using TMPro;
using UnityEngine;

public class Readings : MonoBehaviour
{
    public int randomIndex;

    public GameObject object1;
    private float[] TopAnswer1 = { 34.57f, 9.761f };
    private float[] BottomAnswer1 = { 34.32f, 9.840f };

    public GameObject object2;
    private float[] TopAnswer2 = { 45.41f, 7.431f };
    private float[] BottomAnswer2 = { 34.57f, 7.731f };

    public GameObject object3;
    private float[] TopAnswer3;
    private float[] BottomAnswer3;

    public GameObject object4;
    private float[] TopAnswer4;
    private float[] BottomAnswer4;

    public GameObject object5;
    private float[] TopAnswer5;
    private float[] BottomAnswer5;

    public GameObject object6;
    private float[] TopAnswer6;
    private float[] BottomAnswer6;

    public GameObject object7;
    private float[] TopAnswer7;
    private float[] BottomAnswer7;

    public GameObject object8;
    private float[] TopAnswer8;
    private float[] BottomAnswer8;

    public GameObject object9;
    private float[] TopAnswer9;
    private float[] BottomAnswer9;

    public GameObject object10;
    private float[] TopAnswer10;
    private float[] BottomAnswer10;

    public bool IslevelComplete = false;
    public float Ans1;
    public float Ans2;
    public float Ans3;
    public float Ans4;

    public TMP_InputField inputFieldTop;
    public TMP_InputField inputFieldBottom;


    public bool IsTopCorrect;
    public bool IsBottomCorrect;

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
        randomIndex = Random.Range(1, 3);
        SelectGameObject(randomIndex, IslevelComplete);

    }


    private void Update()
    {

    }

    private void SelectGameObject(int RandomInt, bool LevelState)
    {
        switch (RandomInt)
        {
            case 1:
                object1.SetActive(true);
                if (LevelState)
                {

                } else
                {
                    SetAnswers(object1, TopAnswer1, BottomAnswer1);
                }

                break;
            case 2:
                object2.SetActive(true);
                if (LevelState)
                {

                }
                else
                {
                    SetAnswers(object2, TopAnswer2, BottomAnswer2);
                }

                break;
            case 3:
                object3.SetActive(true);
                break;
            case 4:
                object4.SetActive(true);
                break;
            case 5:
                object5.SetActive(true);
                break;
            case 6:
                object6.SetActive(true);
                break;
            case 7:
                object7.SetActive(true);
                break;
            case 8:
                object8.SetActive(true);
                break;
            case 9:
                object9.SetActive(true);
                break;
            case 10:
                object10.SetActive(true);
                break;
        }
    }

    private void SetAnswers(GameObject Readings, float[] TopAnsArray, float[] BottomAnsArray)
    {
        Ans1 = TopAnsArray[0];
        Ans2 = TopAnsArray[1];
        Ans3 = BottomAnsArray[0];
        Ans4 = BottomAnsArray[1];
    }

    public void CheckAns()
    {
        string topInput = inputFieldTop.text;
        string bottomInput = inputFieldBottom.text;

        // Convert the input strings to floats
        float topValue, bottomValue;
        bool isTopValid = float.TryParse(topInput, out topValue);
        bool isBottomValid = float.TryParse(bottomInput, out bottomValue);
        print(topValue + 1.23);
        print(bottomValue + 18);
        if(topValue == Ans1)
        {
            print("yay");
        }

        if(bottomValue == Ans3)
        {
            print("yay2");
        }
    }



}


/*using UnityEngine;
using TMPro;

public class Readings : MonoBehaviour
{
    public TextMeshProUGUI vtopreadings1;
    public TextMeshProUGUI vtopreadings2;
    public TextMeshProUGUI vbottomreadings1;
    public TextMeshProUGUI vbottomreadings2;
    public TextMeshProUGUI vbottomreadings3;

    public TextMeshProUGUI htopreadings1;
    public TextMeshProUGUI htopreadings2;
    public TextMeshProUGUI htopreadings3;
    public TextMeshProUGUI hbottomreadings1;
    public TextMeshProUGUI hbottomreadings2;

    void Start()
    {
        float vtopreadings = Random.Range(60f, 28f);
        float vtopreadingstwo = vtopreadings - 1f;

        float vbottomreadings = Random.Range(12f, 5.5f);
        float vbottomreadingstwo = vbottomreadings + 0.1f;
        float vbottomreadingsthree = vbottomreadings + 0.2f;

        float htopreadings = Random.Range(12f, 5.5f);
        float htopreadingsDecimal = htopreadings - Mathf.Floor(htopreadings); // Extract the decimal only
        float htopreadingstwo = htopreadings + 0.1f;
        float htopreadingsthree = htopreadings + 0.2f;

        float hbottomreadings = Random.Range(60f, 28f);
        float hbottomreadingstwo = hbottomreadings - 1f;


        vtopreadings1.text = vtopreadings.ToString("F0"); //no dp
        vtopreadings2.text = vtopreadingstwo.ToString("F0");

        vbottomreadings1.text = vbottomreadings.ToString("F1");
        vbottomreadings2.text = vbottomreadingstwo.ToString("F1");
        vbottomreadings3.text = vbottomreadingsthree.ToString("F0");


        htopreadings1.text = htopreadingsDecimal.ToString(".0");
        htopreadings2.text = htopreadingstwo.ToString("F1");
        htopreadings3.text = htopreadingsthree.ToString("F1");

        hbottomreadings1.text = hbottomreadings.ToString("F0");
        hbottomreadings2.text = hbottomreadingstwo.ToString("F0");
    }
}
*/
