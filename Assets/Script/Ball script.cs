using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource touchsound;
    public int currentscene;
    public int nextscene;


    public float keyinput;
    public float speedMultiplier =  0.0005f; // Add a speed multiplier

    void Start()
    {
        touchsound = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 6, ForceMode.VelocityChange);
        }
        keyinput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().velocity = new Vector3(keyinput * speedMultiplier, GetComponent<Rigidbody>().velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
            {
            if (collision.gameObject.CompareTag("candy"))
                touchsound.Play();

            if (collision.gameObject.CompareTag("Ground"))
                SceneManager.LoadScene(nextscene);

        }
        
    }
     
}
