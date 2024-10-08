using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    public void Increse(int health)
    {
        if (health < 0)
        { 
            Debug.LogError("try add under zero health");
            return;
        }

        _health += health;
    }
}
