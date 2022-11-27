using UnityEngine;

public class Motorcycle : MonoBehaviour
{
    [SerializeField] private float driveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AnimationCurve driveVelocity;
    [SerializeField] private Transform driveDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform[] weals;

    private bool isHighJump = false;
    private float startDrivingTime = 0;
    private bool inAir = false;
    private bool isDriving = false;
    private float[] worldBorder = {-10f, 5f};

    private bool GroundCheck()
    {
        RaycastHit2D raycast = Physics2D.Raycast(this.transform.localPosition, -transform.up, 0.35f, 3);
        if (raycast.collider != null) { return true; }
        else { return false; }
    }

    private void Update()
    {
        //Inputs
        if (Data.gameStarted)
        {
            if (Input.GetMouseButtonDown(0) )
            {
                startDrivingTime = Time.time;
            }
            if (Input.GetMouseButtonUp(0))
            {
                startDrivingTime = 0;
                isDriving = false;
            }
            if (Input.GetMouseButton(0))
            {
                isDriving = true;
            }
        }
        //Flips and basic movement logic
        if (GroundCheck())
        {
            if (FlipManager.IsWriting())
            {
                int flipCount = FlipManager.GetInfo();
                if (flipCount > 0)
                {
                    Data.ChangeScore(flipCount, true);
                    for (int i = 0; i < weals.Length; i++)
                    {
                        GameObject particle = ParticleManager.Create("Flip", this.transform.position);
                        particle.transform.position = weals[i].position;
                        particle.transform.SetParent(weals[i]);
                    }
                }
            }
            if (inAir)
            {
                if (isHighJump)
                {
                    CameraShaker.Shake(0.4f, 1.3f, 30);
                }
                inAir = false;
                isHighJump = false;
            }
        }
        else if(!(GroundCheck()))
        {
            if (!inAir)
            {
                inAir = true;
            }
            else
            {
                if (transform.position.y >= worldBorder[1])
                {
                    isHighJump = true;
                }
            }
            if (transform.position.y <= worldBorder[0])
            {
                Die();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDriving)
        {
            if (GroundCheck())
            {
                float velocity = driveVelocity.Evaluate(Time.time - startDrivingTime);
                rb.velocity = Vector3.Normalize(driveDirection.position - transform.position) * driveSpeed * velocity;
            }
            else
            {
                FlipManager.WriteInfo();
                rb.angularVelocity = rotationSpeed * 100;
            }
        }
    }
    public void Die()
    {
        ParticleManager.Create("Smoke", this.transform.position);
        CameraShaker.Shake(1f,3,30);
        Transition.Start(2f,0);
        Data.NewScore();
        FlipManager.Stop();
        Destroy(this.gameObject);
    }
}
