using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("太空人")]
    public Transform Astronaut;
    [Header("機器人")]
    public Transform Robots;
    [Header("虛擬搖桿")]
    public FixedJoystick Joystick;
    [Header("旋轉速度"),Range(0.5f,20f)]
    public float turn = 1.5f;
    [Header("縮放"),Range(0f,5f)]
    public float size = 5f;
    [Header("太空人動畫元件")]
    public Animator aniAstronaut;
    [Header("機器人動畫元件")]
    public Animator aniRobots;
    private void Start()
    {
        
    }

    private void Update()
    {
        print(Joystick.Vertical);

        Astronaut.Rotate(0, Joystick.Horizontal*turn, 0);
        Robots.Rotate(0, Joystick.Horizontal*turn, 0);

        Astronaut.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;
        Astronaut.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(Astronaut.localScale.x, 0.5f, 10f);
        Robots.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;
        Robots.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(Robots.localScale.x, 0.1f, 1.5f);
    }

    public void PlayAnimation(string aniName)
    {
        print(aniName);
        aniAstronaut.SetTrigger(aniName);
        aniRobots.SetTrigger(aniName);
    }
    }

