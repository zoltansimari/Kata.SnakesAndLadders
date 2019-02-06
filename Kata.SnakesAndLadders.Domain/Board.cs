using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.SnakesAndLadders.Domain
{
    public class Board
    {
        public IEnumerable<Token> Tokens { get; private set; } = new Token[0];
        public int StartPosition { get; }
        public int EndPosition { get; }

        public Board(int startPosition, int endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }

        public void AddToken(Token token)
        {
            if (Tokens.Any(t => t.Colour == token.Colour))
            {
                throw new ArgumentException($"This token is already on the board: { token.Colour }");
            }

            token.Position = StartPosition;
            Tokens = Tokens.Union(new Token[] { token });
        }

        public void MoveToken(Token token, int move)
        {
            if (!Tokens.Contains(token))
            {
                throw new ArgumentException($"This token is not on the board: { token.Colour }");
            }

            if (move <= 0)
            {
                throw new ArgumentException($"Negative move not possible: { move }");
            }

            token.Position += move;
        }
    }
}
