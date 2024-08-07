using UnityEngine;

public class AlienCreateScriptTemp : MonoBehaviour
{
    [SerializeField] private GameObject alien;

    public void CreateAlien()
    {
        float x = Mathf.FloorToInt(Random.value * 8) * 6 - 21;
        float y = 13;
        Vector3 position = new Vector3(x, y, transform.position.x);
        Instantiate(alien, position, transform.rotation);
    }
}
