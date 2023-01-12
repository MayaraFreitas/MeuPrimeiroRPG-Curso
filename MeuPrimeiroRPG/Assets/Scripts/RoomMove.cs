using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMoviment cam;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"START");
        cam = Camera.main.GetComponent<CameraMoviment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($">>>> TRIGGER!");
        if (other.CompareTag("Player"))
        {
            Debug.Log($">>>> ENTREI");
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
