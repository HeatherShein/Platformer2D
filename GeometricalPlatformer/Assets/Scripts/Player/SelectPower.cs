using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectPower : MonoBehaviour
{

    #region Inventory
    public Inventory inventory;
    #endregion

    #region Power
    private Power currentPower = null;
    private int currentPowerIndex = 0;
    public Dictionary<string, Sprite> powerToImage = new Dictionary<string, Sprite>();
    private Power[] powers = new Power[5]; // Change array size if more powers
    #endregion

    #region PowerImages
    public Sprite powerCube;
    public Sprite powerTriangle;
    public Sprite powerSphere;
    public Sprite powerHexagon;
    public Sprite powerSchurHorn;
    #endregion

    public void Awake()
    {
        // Initialize dictionnary with all possible powers
        powerToImage.Add("Cube", powerCube);
        powerToImage.Add("Triangle", powerTriangle);
        powerToImage.Add("Sphere", powerSphere);
        powerToImage.Add("Hexagon", powerHexagon);
        powerToImage.Add("SchurHorn", powerSchurHorn);
    }

    private void FixedUpdate()
    {
        // Player switchs power focus
        if (Input.GetButtonDown("SwitchPowerUp"))
        {
            inventory.powers.CopyTo(powers);
            if(powers[0] != null) // Check posseded powers is not empty
            {
                if(currentPowerIndex < 4)
                {
                    if (powers[currentPowerIndex + 1] != null)
                    {
                        currentPowerIndex++;
                    }
                    else
                    {
                        currentPowerIndex = 0;
                    }
                }
                else
                {
                    currentPowerIndex = 0;
                }
                // Change current power
                currentPower = powers[currentPowerIndex];
                // Change image
                gameObject.GetComponent<Image>().sprite = powerToImage[currentPower.powerName];
            }
        }
        if (Input.GetButtonDown("SwitchPowerDown"))
        {
            inventory.powers.CopyTo(powers);
            if (powers[0] != null) // Check posseded powers is not empty
            {
                if (currentPowerIndex > 0)
                {
                    currentPowerIndex--;
                }
                else
                {
                    for (int i = 4; i >= 0; i--)
                    {
                        if (powers[i] != null)
                        {
                            currentPowerIndex = i;
                            break;
                        }
                    }
                }
                // Change current power
                currentPower = powers[currentPowerIndex];
                // Change image
                gameObject.GetComponent<Image>().sprite = powerToImage[currentPower.powerName];
            }
        }
    }

    public Power GetCurrentPower()
    {
        return currentPower;
    }
}
