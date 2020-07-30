using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    #region Score
    public int score;
    public Text scoreText;
    #endregion

    #region Power
    public List<Power> powers = new List<Power>();
    #endregion

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory");
            return;
        }

        instance = this;
    }

    public void IncreaseScore(int count)
    {
        score += count;
        scoreText.text = score.ToString();
    }

    public void AddPower(Power power)
    {
        if (!powers.Contains(power))
        {
            // Add power to the list
            powers.Add(power);

            // Able power button
            string buttonName = power.powerName + "Button";
            Button button = GameObject.FindGameObjectWithTag(buttonName).GetComponent<Button>();

            if (button != null)
            {
                button.interactable = true;
                var child = button.transform.GetChild(0).gameObject;
                if (child != null)
                {
                    child.SetActive(false);
                }
            }
        }
    }
}
