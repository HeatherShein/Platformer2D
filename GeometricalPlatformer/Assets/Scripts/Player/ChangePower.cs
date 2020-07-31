using UnityEngine;

public class ChangePower : MonoBehaviour
{

    public SelectPower selectPower;

    private void FixedUpdate()
    {
        // Player transforms
        if (Input.GetButtonDown("ChangePower"))
        {
            Debug.Log(selectPower.GetCurrentPower().powerName);
        }
    }
}
