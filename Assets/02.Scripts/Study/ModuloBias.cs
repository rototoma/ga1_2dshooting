using UnityEngine;

public class ModuloBias : MonoBehaviour
{
    private void Start()
    {
        int randomInt = 0;
        float dropPercentage = 0f;
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 100000000; i++)
            {
                randomInt = UnityEngine.Random.Range(0, 429496730);
                randomInt = randomInt % 80000000;
                if (randomInt < 1000000)
                {
                    dropPercentage++;
                }
            }

            dropPercentage /= 100000000;
            Debug.Log($"계산된 드랍률: {dropPercentage * 100}%");
        }
    }
}