using UnityEngine;
using CreatorKitCode;

public class SpawnerSample : MonoBehaviour
{
    // Attach portion object on inspector.
    public GameObject ObjectToSpawn;

    void Start()
    {
        LootAngle myLootAngle = new LootAngle(45);
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());

        // Declare int type Array can contain 5 factors
        int[] angleArray = new int[5];
        
        // Substitute int values to the Array
        /*
        angleArray[0] = 0;
        angleArray[1] = 10;
        angleArray[2] = 50;
        angleArray[3] = 125;
        angleArray[4] = 220;

        // Use all factors of angleArray
        // {array}.Length returns the total number of the factors
        for (int i = 0; i < angleArray.Length; i++)
        {
            // Use i as index of angleArray
            SpawnPotion(angleArray[i]);
        }
        */
    }

    void SpawnPotion(int angle)
    {
        int radius = 5;

        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        Vector3 spawnPosition = transform.position + direction * radius;

        // Instantiate (Gameobject object, Vector3 position, Quatenion rotation)
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }
}

public class LootAngle
{
    int angle;
    int step;

    public LootAngle(int increment)
    {
        step = increment;
        angle = 0;
    }

    public int NextAngle()
    {
        int currentAngle = angle;
        angle = Helpers.WrapAngle(angle + step);

        return currentAngle;
    }
}

