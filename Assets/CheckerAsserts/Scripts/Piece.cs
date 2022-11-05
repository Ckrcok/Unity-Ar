using UnityEngine;

public class Piece : MonoBehaviour
{
	public bool isWhite;
	public bool isKing;

	public bool IsForceToMove(Piece[,] board, int x, int y)
	{
		if (isWhite || isKing)
		{
			// Top Left
			if (x >= 2 && y <= 5)
			{
				Piece p = board[x - 1, y + 1];
				// If there is a piece and it is not the same color as our then KILL it
				if (p != null && p.isWhite != isWhite)
				{
					// Check if it is possible to land after the jump
					if (board[x - 2, y + 2] == null)
						return true;
				}
			}

			// Top Right
			if (x <= 5 && y <= 5)
			{
				Piece p = board[x + 1, y + 1];
				// If there is a piece and it is not the same color as our then KILL it
				if (p != null && p.isWhite != isWhite)
				{
					// Check if it is possible to land after the jump
					if (board[x + 2, y + 2] == null)
						return true;
				}
			}
		}

		if (!isWhite || isKing)
		{
			// Bottom Left
			if (x >= 2 && y >= 2)
			{
				Piece p = board[x - 1, y - 1];
				// If there is a piece and it is not the same color as our then KILL it
				if (p != null && p.isWhite != isWhite)
				{
					// Check if it is possible to land after the jump
					if (board[x - 2, y - 2] == null)
						return true;
				}
			}

			// Bottom Right
			if (x <= 5 && y >= 2)
			{
				Piece p = board[x + 1, y - 1];
				// If there is a piece and it is not the same color as our then KILL it
				if (p != null && p.isWhite != isWhite)
				{
					// Check if it is possible to land after the jump
					if (board[x + 2, y - 2] == null)
						return true;
				}
			}
		}

		return false;
	}

	public bool ValidMove(Piece[,] board, int startX, int startY, int endX, int endY)
	{
		// If you are moving on top of another piece
		if (board[endX, endY] != null)
			return false;

		int deltaMoveX = Mathf.Abs(startX - endX);
		int deltaMoveY = endY - startY;

		if (isWhite || isKing)
		{
			if (deltaMoveX == 1) // normal jump
			{
				if (deltaMoveY == 1)
					return true;
			}
			else if (deltaMoveX == 2) // killer jump
			{
				if (deltaMoveY == 2)
				{
					Piece p = board[(startX + endX) / 2, (startY + endY) / 2];
					if (p != null && p.isWhite != isWhite)
						return true;
				}
			}
		}

		if (!isWhite || isKing)
		{
			if (deltaMoveX == 1) // normal jump
			{
				if (deltaMoveY == -1)
					return true;
			}
			else if (deltaMoveX == 2) // killer jump
			{
				if (deltaMoveY == -2)
				{
					Piece p = board[(startX + endX) / 2, (startY + endY) / 2];
					if (p != null && p.isWhite != isWhite)
						return true;
				}
			}
		}

		return false;
	}
}