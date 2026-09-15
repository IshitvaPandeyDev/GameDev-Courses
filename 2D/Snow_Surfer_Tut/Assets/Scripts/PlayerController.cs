using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float TorqueAmount = 1f;
    [SerializeField] float BaseSpeed = 25f;
    [SerializeField] float BoostSpeed = 35f;
    [SerializeField] float DownwardForce = 0.5f;
    [SerializeField] ParticleSystem BoostParticles;
    SurfaceEffector2D SurfaceEffector;
    InputAction MoveAction;
    Rigidbody2D MyRigidBody2D;
    Vector2 MoveVector;
    bool CanControlPlayer=true;
    float PreviousRotation;
    float TotalRotation;
    ScoreManager ScoreManage;
    float ActivePowerUp;
    void Start()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        MyRigidBody2D = GetComponent<Rigidbody2D>();
        SurfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
        ScoreManage = FindFirstObjectByType<ScoreManager>();
    }
 
    void Update()
    {
        CalculateFlips();
        if (CanControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
        }
        else if (CanControlPlayer == false)
        {
            SurfaceEffector.speed = 0f;
        }
        

    }
    void RotatePlayer()
    {

        MoveVector = MoveAction.ReadValue<Vector2>();
        if (MoveVector.x < 0)
        {
            MyRigidBody2D.AddTorque(TorqueAmount);
        }
        else if (MoveVector.x > 0)
        {
            MyRigidBody2D.AddTorque(-TorqueAmount);
        }
    }
    void BoostPlayer()
    {
        MoveVector = MoveAction.ReadValue<Vector2>();
        if (MoveVector.y > 0)
        {
            SurfaceEffector.speed = BoostSpeed;
        }
        else if (MoveVector.y < 0)
        {
            MyRigidBody2D.AddForce(Vector2.down * DownwardForce);
        }
        else
        {
            SurfaceEffector.speed = BaseSpeed;
        }
    }
    void CalculateFlips()
    {
        float CurrentRotation = transform.rotation.eulerAngles.z;
        TotalRotation += Mathf.DeltaAngle(PreviousRotation, CurrentRotation);
        if(TotalRotation>300 || TotalRotation < -300)
        {
            TotalRotation = 0;
            ScoreManage.AddScore(100);
        }
        PreviousRotation = CurrentRotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layerno = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerno)
        {
            TotalRotation = 0;
        }
    }
    public void DisableControl()
    {
        CanControlPlayer = false;
    }
    public void ActivatePowerUp (PowerUpSL PowerUp)
    {
        BoostParticles.Play();
        ActivePowerUp++;
        if (PowerUp.GetPowerUpType()  == "Speed")
        {
            BaseSpeed += PowerUp.GetValueChange();
            BoostSpeed += PowerUp.GetValueChange();
        }
        else if (PowerUp.GetPowerUpType() == "Torque")
        {
            TorqueAmount += PowerUp.GetValueChange();
            Debug.Log("Player controller working");
        }
    }
    public void DeactivatePowerUP (PowerUpSL PowerUp)
    {
        ActivePowerUp--;
        if (PowerUp.GetPowerUpType() == "Speed")
        {
            BaseSpeed -= PowerUp.GetValueChange();
            BoostSpeed -= PowerUp.GetValueChange();
        }
        else if (PowerUp.GetPowerUpType() == "Torque")
        {
            TorqueAmount -= PowerUp.GetValueChange();
        }
        if(ActivePowerUp == 0)
        {
            BoostParticles.Stop();
        }
    }
}
