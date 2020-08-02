using UnityEngine;

public class ChangePower : MonoBehaviour
{

    public SelectPower selectPower;

    public GameObject powerDefault, powerCube, powerTriangle, powerSphere, powerHexagon, powerSchurHorn;

    private GameObject[] powers = new GameObject[6];

    int avatarID = 0;

    private void Start()
    {
        powerDefault.gameObject.SetActive(true);
        powerCube.gameObject.SetActive(false);
        powerTriangle.gameObject.SetActive(false);
        powerSphere.gameObject.SetActive(false);
        powerHexagon.gameObject.SetActive(false);
        powerSchurHorn.gameObject.SetActive(false);

        powers[0] = powerDefault;
        powers[1] = powerCube;
        powers[2] = powerTriangle;
        powers[3] = powerSphere;
        powers[4] = powerHexagon;
        powers[5] = powerSchurHorn;
    }

    private void FixedUpdate()
    {
        // Player transforms
        if (Input.GetButtonDown("ChangePower"))
        {
            switch (selectPower.GetCurrentPower().powerName)
            {
                case "Default":
                    SwapPower(0);
                    break;
                case "Cube":
                    SwapPower(1);
                    break;
                case "Triangle":
                    SwapPower(2);
                    break;
                case "Sphere":
                    SwapPower(3);
                    break;
                case "Hexagon":
                    SwapPower(4);
                    break;
                case "SchurHorn":
                    SwapPower(5);
                    break;
                default:
                    Debug.Log("None of the right powers");
                    break;
            }
        }
    }

    public void SwapPower(int avatarId)
    {
        for (int i = 0; i <= 5; i++)
        {
            if (i != avatarId)
            {
                powers[i].gameObject.SetActive(false);
            }
            else
            {
                powers[i].gameObject.SetActive(true);
            }
        }
    }
}
