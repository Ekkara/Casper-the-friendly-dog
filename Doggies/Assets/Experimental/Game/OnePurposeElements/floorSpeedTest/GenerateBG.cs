using UnityEngine;

public class GenerateBG : MonoBehaviour
{
    [SerializeField] bool generate;
    [SerializeField] int amountOfSquaresX, amountOfSquaresY;
    [SerializeField] Color color1, color2;
    [SerializeField] GameObject tile;

    private void OnValidate() {
        if (generate) {
            Generate();
            generate = false;
        }
    }

    private void Generate() {
        for (int x = 0; x < amountOfSquaresX; x++) {
            for (int y = 0; y < amountOfSquaresY; y++) {
                GameObject go = Instantiate(tile, transform.position + new Vector3(x, y, 0), Quaternion.identity, transform);
                go.GetComponent<SpriteRenderer>().color = ((x+y) % 2 == 0) ? color1 : color2;
            }
        }
    }
}
