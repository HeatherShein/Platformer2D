using UnityEngine;

public class PickupObject : MonoBehaviour
{
    #region Default
    public enum Type { Score, Power };
    public Type type;
    #endregion
    
    #region Score
    public int scoreValue = 10;
    private Score score;
    #endregion

    #region Power
    public string powerName = "Cube";
    private Power power;
    #endregion

    public void Start()
    {
        switch (type)
        {
            case Type.Score:
                score = new Score(scoreValue);
                break;
            case Type.Power:
                power = new Power(powerName);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When player hits the pickup object
        if (collision.transform.CompareTag("Player"))
        {
            switch (type)
            {
                case Type.Score:
                    // Increase score
                    Inventory.instance.IncreaseScore(score.scoreValue);
                    break;
                case Type.Power:
                    // Add power to inventory
                    Inventory.instance.AddPower(power);
                    break;
            }
            Destroy(gameObject);
        }
    }

}
