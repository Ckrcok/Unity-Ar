using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public Piece[,] pieces = new Piece[8, 8];
    public GameObject whitePiece;
    public GameObject bluePiece;

    public Vector3 boardOffset = new Vector3(1.0f, 0, -1.0f);
    public Vector3 pieceOffset = new Vector3(0.5f, 0, 0.5f);

    private void setBoard()
    {
        for(int y = 0; y < 3; y++)
        {
            bool oddRow = (y % 2 == 0);
            for(int x = 0; x < 8; x += 2)
            {
                setPlayerPieces((oddRow) ? x: x+1 , y);
            }
        }
    }

    private void setPlayerPieces(int x, int y)
    {

        GameObject wPiece = Instantiate(whitePiece) as GameObject;
        wPiece.transform.SetParent(transform);
        Piece p = wPiece.GetComponent<Piece>();
        pieces[x, y] = p;
        MovePiece(p, x, y);
    }

    private void MovePiece(Piece p, int x, int y)
    {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y) + (boardOffset + pieceOffset);
    }




    // Start is called before the first frame update
    void Start()
    {
        setBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
