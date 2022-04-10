using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Spin : MonoBehaviour
{

    public float speed = 3.0f;
    [SerializeField] Vector3 rotate;

    PostProcessVolume _postProcess;
    Bloom _bloom;

    // Start is called before the first frame update
    void Start()
    {
        _postProcess = GetComponent<PostProcessVolume>();
        _postProcess.profile.TryGetSettings(out _bloom);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * speed * Time.deltaTime);
    }
}
