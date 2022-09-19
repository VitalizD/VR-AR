using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform spawnPoint;

    public void Generate()
    {
        var text = GetComponent<TMP_InputField>().text;
        if (text == "")
            return;

        var count = int.Parse(text);
        for (var i = 0; i < count; ++i)
            Instantiate(cube, spawnPoint.position, Quaternion.identity);
    }
}
