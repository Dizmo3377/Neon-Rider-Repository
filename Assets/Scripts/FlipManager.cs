using UnityEngine;

public class FlipManager : MonoBehaviour
{
    private static bool isWriting = false;
    private static int lastAngle = -1;
    private static int[] reachedAngles = new int[10];

    private void FixedUpdate()
    {
        if (isWriting)
        {
            //We conditionally divide the circle(360 degrees) into 10 parts,
            //so later it will be easier to get information about the flip
            int currentAngle = (int)(Mathf.Floor(Mathf.Abs(transform.rotation.z * 10)));
            if (currentAngle != lastAngle && currentAngle < 11 && currentAngle > 0)
            {
                reachedAngles[currentAngle - 1]++;
                lastAngle = currentAngle;
            }
        }
    }

    public static void WriteInfo()
    {
        isWriting = true;
    }
    public static bool IsWriting()
    {
        return isWriting;
    }

    public static int GetInfo()
    {
        int finalScore = reachedAngles[8];
        Stop();
        return (finalScore);
    }

    public static void Stop()
    {
        //End of the flip
        for (int i = 0; i < reachedAngles.Length; i++)
        {
            reachedAngles[i] = 0;
        }
        isWriting = false;
        lastAngle = -1;
    }
}