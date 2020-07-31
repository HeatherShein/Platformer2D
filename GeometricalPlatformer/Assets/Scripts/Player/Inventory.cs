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
    public SelectPower selectPower;
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
            // First select
            if (powers.Count == 0)
            {
                selectPower.gameObject.GetComponent<Image>().sprite = selectPower.powerToImage[power.powerName];
            }

            // Add power to the list
            powers.Add(power);
        }
    }
}
