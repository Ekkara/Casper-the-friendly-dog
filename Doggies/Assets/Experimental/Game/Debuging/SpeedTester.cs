using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTester : MonoBehaviour
{
    [SerializeField] Transform head, tail, tileHolder;
    [SerializeField] float speed;
    [SerializeField] GameObject tile;
    [SerializeField] Color color1, color2;
    List<GameObject> tiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateRow();
       
    }
    int colorInt = 0;
    void GenerateRow() {
        for (int i = 0; i < 8; i++) {
            GameObject go = GameObject.Instantiate(tile, head.position + Vector3.up * i, Quaternion.identity, tileHolder);
            go.GetComponent<SpriteRenderer>().color = (colorInt % 2 == 0) ? color1 : color2;
            tiles.Add(go);
            colorInt++;
        }
        colorInt++;
        colorInt = (colorInt % 2 == 0) ? 0 : 1;
        Invoke("GenerateRow", 1/speed);
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = tiles.Count - 1; i > 0; i--) {
            if (tiles[i].transform.position.x < tail.transform.position.x) {
                Destroy(tiles[i]);
                tiles.RemoveAt(i);
                continue;
            }
            tiles[i].GetComponent<Rigidbody2D>().MovePosition(tiles[i].transform.position + Vector3.left * Time.deltaTime * speed);
        }
    }

}
