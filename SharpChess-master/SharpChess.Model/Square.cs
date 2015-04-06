// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Square.cs" company="SharpChess.com">
//   SharpChess.com
// </copyright>
// <summary>
//   The square.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region License

// SharpChess
// Copyright (C) 2012 SharpChess.com
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
#endregion

namespace SharpChess.Model
{
    #region Using

    using System;

    #endregion

    /// <summary>
    /// The square.
    /// </summary>
    public class Square
    {
        #region Constants and Fields

        /// <summary>
        /// Simple square values.
        /// </summary>
        private static readonly int[] SquareValues =
        { 
            1,  1,  1,  1,  1,  1,  1, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1, 10, 10, 10, 10, 10, 10, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1, 10, 25, 25, 25, 25, 10, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1, 10, 25, 50, 50, 25, 10, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1, 10, 25, 50, 50, 25, 10, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1, 10, 25, 25, 25, 25, 10, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1, 10, 10, 10, 10, 10, 10, 1,    0, 0, 0, 0, 0, 0, 0, 0, 
            1,  1,  1,  1,  1,  1,  1, 1,    0, 0, 0, 0, 0, 0, 0, 0
        };

        /// <summary>
        /// The king attackers.
        /// </summary>
        private static char[] kingAttackers = 
        { 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', 'K', 
            'K', 'K', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', 'K',  
            '.', 
            'K', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', 'K', 'K', 
            'K', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.', 
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.',
            '.', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', '.'
        };

        /// <summary>
        /// The minor attackers.
        /// </summary>
        private static char[] minorAttackers = 
        { 
            '.', '.', '.', '.', '.', '.', '.', '.',   'B', 'B', '.', '.', '.', '.', '.', '.', 
            'R', '.', '.', '.', '.', '.', '.', 'B',   '.', '.', 'B', '.', '.', '.', '.', '.', 
            'R', '.', '.', '.', '.', '.', 'B', '.',   '.', '.', '.', 'B', '.', '.', '.', '.', 
            'R', '.', '.', '.', '.', 'B', '.', '.',   '.', '.', '.', '.', 'B', '.', '.', '.', 
            'R', '.', '.', '.', 'B', '.', '.', '.',   '.', '.', '.', '.', '.', 'B', '.', '.', 
            'R', '.', '.', 'B', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', 'B', 'N', 
            'R', 'N', 'B', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', 'N', 'B', 
            'R', 'B', 'N', '.', '.', '.', '.', '.',   '.', 'R', 'R', 'R', 'R', 'R', 'R', 'R',  
            '.', 
            'R', 'R', 'R', 'R', 'R', 'R', 'R', '.',   '.', '.', '.', '.', '.', 'N', 'B', 'R', 
            'B', 'N', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', 'B', 'N', 'R', 
            'N', 'B', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', 'B', '.', '.', 'R', 
            '.', '.', 'B', '.', '.', '.', '.', '.',   '.', '.', '.', 'B', '.', '.', '.', 'R', 
            '.', '.', '.', 'B', '.', '.', '.', '.',   '.', '.', 'B', '.', '.', '.', '.', 'R', 
            '.', '.', '.', '.', 'B', '.', '.', '.',   '.', 'B', '.', '.', '.', '.', '.', 'R', 
            '.', '.', '.', '.', '.', 'B', '.', '.',   'B', '.', '.', '.', '.', '.', '.', 'R', 
            '.', '.', '.', '.', '.', '.', 'B', 'B',   '.', '.', '.', '.', '.', '.', '.', '.'
        };

        /// <summary>
        /// The queen attackers.
        /// </summary>
        private static char[] queenAttackers =
        { 
            '.', '.', '.', '.', '.', '.', '.', '.', 'Q', 'Q', '.', '.', '.', '.', '.', '.', 
            'Q', '.', '.', '.', '.', '.', '.', 'Q',   '.', '.', 'Q', '.', '.', '.', '.', '.', 
            'Q', '.', '.', '.', '.', '.', 'Q', '.',   '.', '.', '.', 'Q', '.', '.', '.', '.', 
            'Q', '.', '.', '.', '.', 'Q', '.', '.',   '.', '.', '.', '.', 'Q', '.', '.', '.', 
            'Q', '.', '.', '.', 'Q', '.', '.', '.',   '.', '.', '.', '.', '.', 'Q', '.', '.', 
            'Q', '.', '.', 'Q', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', 'Q', '.', 
            'Q', '.', 'Q', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', '.', '.', 'Q', 
            'Q', 'Q', '.', '.', '.', '.', '.', '.',   '.', 'Q', 'Q', 'Q', 'Q', 'Q', 'Q', 'Q',  
            '.', 
            'Q', 'Q', 'Q', 'Q', 'Q', 'Q', 'Q', '.',   '.', '.', '.', '.', '.', '.', 'Q', 'Q', 
            'Q', '.', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', '.', 'Q', '.', 'Q', 
            '.', 'Q', '.', '.', '.', '.', '.', '.',   '.', '.', '.', '.', 'Q', '.', '.', 'Q', 
            '.', '.', 'Q', '.', '.', '.', '.', '.',   '.', '.', '.', 'Q', '.', '.', '.', 'Q', 
            '.', '.', '.', 'Q', '.', '.', '.', '.',   '.', '.', 'Q', '.', '.', '.', '.', 'Q', 
            '.', '.', '.', '.', 'Q', '.', '.', '.',   '.', 'Q', '.', '.', '.', '.', '.', 'Q', 
            '.', '.', '.', '.', '.', 'Q', '.', '.',   'Q', '.', '.', '.', '.', '.', '.', 'Q',
            '.', '.', '.', '.', '.', '.', 'Q', 'Q',   '.', '.', '.', '.', '.', '.', '.', '.'
        };

        /// <summary>
        /// The vectors.
        /// </summary>
        private static int[] vectors = 
        { 
              0,   0,   0,   0,   0,   0,   0,  0,   -15, -17,   0,   0,   0,   0,   0,   0, 
            -16,   0,   0,   0,   0,   0,   0, -15,    0,   0, -17,   0,   0,   0,   0,   0, 
            -16,   0,   0,   0,   0,   0, -15,  0,     0,   0,   0, -17,   0,   0,   0,   0, 
            -16,   0,   0,   0,   0, -15,   0,  0,     0,   0,   0,   0, -17,   0,   0,   0, 
            -16,   0,   0,   0, -15,   0,   0,  0,     0,   0,   0,   0,   0, -17,   0,   0, 
            -16,   0,   0, -15,   0,   0,   0,  0,     0,   0,   0,   0,   0,   0, -17, 100, 
            -16, 100, -15,   0,   0,   0,   0,  0,     0,   0,   0,   0,   0,   0, 100, -17, 
            -16, -15, 100,   0,   0,   0,   0,  0,     0,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  
              0, 
              1,  1,    1,   1,   1,   1,   1,  0,     0,   0,   0,   0,   0, 100,  15,  16, 
             17, 100,   0,   0,   0,   0,   0,  0,     0,   0,   0,   0,   0,  15, 100,  16, 
            100,  17,   0,   0,   0,   0,   0,  0,     0,   0,   0,   0,  15,   0,   0,  16, 
              0,   0,  17,   0,   0,   0,   0,  0,     0,   0,   0,  15,   0,   0,   0,  16, 
              0,   0,   0,  17,   0,   0,   0,  0,     0,   0,  15,   0,   0,   0,   0,  16, 
              0,   0,   0,   0,  17,   0,   0,  0,     0,  15,   0,   0,   0,   0,   0,  16, 
              0,   0,   0,   0,   0,  17,   0,  0,    15,   0,   0,   0,   0,   0,   0,  16, 
              0,   0,   0,   0,   0,   0,  17, 15,     0,   0,   0,   0,   0,   0,   0,   0
        };
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="ordinal">
        /// The ordinal index of this square.
        /// </param>
        public Square(int ordinal)
        {
            this.Ordinal = ordinal;
            this.File = ordinal % Board.MatrixWidth;
            this.Rank = ordinal / Board.MatrixWidth;

            if (this.File == 0 || this.File == 2 || this.File == 4 || this.File == 6)
            {
                if (this.Rank == 0 || this.Rank == 2 || this.Rank == 4 || this.Rank == 6)
                {
                    this.Colour = ColourNames.Black;
                }
                else
                {
                    this.Colour = ColourNames.White;
                }
            }
            else
            {
                if (this.Rank == 0 || this.Rank == 2 || this.Rank == 4 || this.Rank == 6)
                {
                    this.Colour = ColourNames.White;
                }
                else
                {
                    this.Colour = ColourNames.Black;
                }
            }
        }

        #endregion

        #region Enums

        /// <summary>
        /// Possible sqaure colours: black or white.
        /// </summary>
        public enum ColourNames
        {
            /// <summary>
            ///   The white.
            /// </summary>
            White, 

            /// <summary>
            ///   The black.
            /// </summary>
            Black
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the colour of this square: black or white!
        /// </summary>
        public ColourNames Colour { get; private set; }

        /// <summary>
        ///   Gets file number for this square.
        /// </summary>
        public int File { get; private set; }

        /// <summary>
        ///   Gets the file letter for this square.
        /// </summary>
        public string FileName
        {
            get
            {
                string[] fileNames = { "a", "b", "c", "d", "e", "f", "g", "h" };
                return fileNames[this.File];
            }
        }

        /// <summary>
        ///   Gets HashCodeA.
        /// </summary>
        public ulong HashCodeA
        {
            get
            {
                return this.Piece == null ? 0UL : this.Piece.HashCodeAForSquareOrdinal(this.Ordinal);
            }
        }

        /// <summary>
        ///   Gets HashCodeB.
        /// </summary>
        public ulong HashCodeB
        {
            get
            {
                return this.Piece == null ? 0UL : this.Piece.HashCodeBForSquareOrdinal(this.Ordinal);
            }
        }

        /// <summary>
        ///   Gets the display name fo this square.
        /// </summary>
        public string Name
        {
            get
            {
                return this.FileName + this.RankName;
            }
        }

        /// <summary>
        ///   Gets the ordinal index of this square.
        /// </summary>
        public int Ordinal { get; private set; }

        /// <summary>
        ///   Gets or sets Piece.
        /// </summary>
        public Piece Piece { get; set; }

        /// <summary>
        ///   Gets Rank.
        /// </summary>
        public int Rank { get; private set; }

        /// <summary>
        ///   Gets RankName.
        /// </summary>
        public string RankName
        {
            get
            {
                return (this.Rank + 1).ToString();
            }
        }

        /// <summary>
        ///   Gets a simple positonal value for this square.
        /// </summary>
        public int Value
        {
            get
            {
                return SquareValues[this.Ordinal];
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Appends a list of moves of all the pieces that are attacking this square.
        /// </summary>
        /// <param name="moves">
        /// Moves of pieces that are attacking this square.
        /// </param>
        /// <param name="player">
        /// Player whose turn it is
        /// </param>
        public void AttackersMoveList(Moves moves, Player player)
        {
            /*************************************************REFACTOR*******************************************/
            Piece piece;

            // Pawn
            piece = Board.GetPiece(this.Ordinal - player.PawnAttackLeftOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                moves.Add(
                    0, 
                    0, 
                    Move.MoveNames.Standard, 
                    Board.GetPiece(this.Ordinal - player.PawnAttackLeftOffset), 
                    Board.GetSquare(this.Ordinal - player.PawnAttackLeftOffset), 
                    this, 
                    this.Piece, 
                    0, 
                    0);
            }

            piece = Board.GetPiece(this.Ordinal - player.PawnAttackRightOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                moves.Add(
                    0, 
                    0, 
                    Move.MoveNames.Standard, 
                    Board.GetPiece(this.Ordinal - player.PawnAttackRightOffset), 
                    Board.GetSquare(this.Ordinal - player.PawnAttackRightOffset), 
                    this, 
                    this.Piece, 
                    0, 
                    0);
            }

            // Knight
            piece = Board.GetPiece(this.Ordinal + 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal + 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal + 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal + 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            // Bishop & Queen
            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 15)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 17)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -15)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -17)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            // Rook & Queen
            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 1)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -1)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 16)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -16)) != null)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            // King!
            piece = Board.GetPiece(this.Ordinal + 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal + 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal + 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal - 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }

            piece = Board.GetPiece(this.Ordinal + 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                moves.Add(0, 0, Move.MoveNames.Standard, piece, piece.Square, this, this.Piece, 0, 0);
            }
        }

        /// <summary>
        /// Returns a list of player's pieces attacking this square.
        /// </summary>
        /// <param name="player">
        /// Player who owns the attacking pieces that you want to find.
        /// </param>
        /// <returns>
        /// List of pieces.
        /// </returns>
        public Pieces PlayersPiecesAttackingThisSquare(Player player)
        {
            /*************************************************REFACTOR*******************************************/
            Piece piece;
            Pieces pieces = new Pieces();

            // Pawn
            piece = Board.GetPiece(this.Ordinal - player.PawnAttackLeftOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - player.PawnAttackRightOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            // Knight
            piece = Board.GetPiece(this.Ordinal + 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal + 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal + 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal + 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            // Bishop & Queen
            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 15)) != null)
            {
                pieces.Add(piece);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 17)) != null)
            {
                pieces.Add(piece);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -15)) != null)
            {
                pieces.Add(piece);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -17)) != null)
            {
                pieces.Add(piece);
            }

            // Rook & Queen
            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 1)) != null)
            {
                pieces.Add(piece);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -1)) != null)
            {
                pieces.Add(piece);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 16)) != null)
            {
                pieces.Add(piece);
            }

            if ((piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -16)) != null)
            {
                pieces.Add(piece);
            }

            // King!
            piece = Board.GetPiece(this.Ordinal + 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal + 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal + 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal - 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            piece = Board.GetPiece(this.Ordinal + 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                pieces.Add(piece);
            }

            return pieces;
        }

        /// <summary>
        /// Determines whether the specified player can attack this square.
        /// </summary>
        /// <param name="player">
        /// The player being tested.
        /// </param>
        /// <returns>
        /// True if player can move a piece to this square.
        /// </returns>
        public bool PlayerCanAttackSquare(Player player)
        {
            bool can_attack = false;

            // Pawn
            can_attack = checkForPawnAttacker(player);
            if (can_attack)
            {
                return true;
            }

            // Knight
            can_attack = checkForKnightAttacker(player);
            if (can_attack)
            {
                return true;
            }

            // Bishop & Queen
            //Look for an attacker along horizontal/vertical lines.
            can_attack = checkForBishopLineAttacker(player);
            //If found, this piece is under attack by a Bishop/Queen.
            if (can_attack)
            {
                return true;
            }
            

            // Rook & Queen
            //Look for an attacker along horizontal/vertical lines.
            can_attack = checkForRookLineAttacker(player);
            //If found, this piece is under attack by a Rook.
            if (can_attack)
            {
                return true;
            }

            // Concealed
            //Look for a Concealed piece that can attack this square.
            can_attack = checkForConcealedAttacker(player);

            //If found, this piece is under attack by a Concealed piece.
            if (can_attack)
            {
                return true;
            }

            // King!
            //Look for a King that can attack this square.
            can_attack = checkForKingAttacker(player);

            //If found, this piece is under attack by a King piece.
            if (can_attack)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether a sliding piece could slide to this square from the specified start square, 
        /// in the specified direction-offset. Checks that no pieces are blocking the route.
        /// </summary>
        /// <param name="squareStart">
        /// The starting square.
        /// </param>
        /// <param name="directionOffset">
        /// The direciton offset.
        /// </param>
        /// <returns>
        /// True if the piece can be slid.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// An exception indicting that the alogrithm has hit the edge of the board.
        /// </exception>
        public bool CanSlideToHereFrom(Square squareStart, int directionOffset)
        {
            int intOrdinal = squareStart.Ordinal;
            Square square;

            intOrdinal += directionOffset;
            while ((square = Board.GetSquare(intOrdinal)) != null)
            {
                if (square == this)
                {
                    return true;
                }

                if (square.Piece != null)
                {
                    return false;
                }

                intOrdinal += directionOffset;
            }

            throw new ApplicationException("CanSlideToHereFrom: Hit edge of board!");
        }

        /// <summary>
        /// Calculates defense points for the player on this square. Returns the value of the cheapest piece defending the square.
        /// If no pieces are defending, then returns a high value (15,000).
        /// </summary>
        /// <param name="player">
        /// The defending player.
        /// </param>
        /// <returns>
        /// Defense points.
        /// </returns>
        public int DefencePointsForPlayer(Player player)
        {
            /*************************************************REFACTOR*******************************************/
            Piece piece;
            int value = 0;
            int bestValue = 0;

            // Pawn
            piece = Board.GetPiece(this.Ordinal - player.PawnAttackLeftOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - player.PawnAttackRightOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            // Knight
            piece = Board.GetPiece(this.Ordinal + 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal + 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal + 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal + 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            // Bishop & Queen
            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 15);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 17);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -15);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -17);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            // Rook & Queen
            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 1);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -1);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 16);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -16);
            value = piece != null ? piece.Value : 0;
            if (value > 0 && value < 9000)
            {
                return value;
            }

            if (value > 0)
            {
                bestValue = value;
            }

            if (bestValue > 0)
            {
                return bestValue; // This means a queen was found, but not a Bishop or Rook
            }

            // King!
            piece = Board.GetPiece(this.Ordinal + 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal + 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal + 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal - 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            piece = Board.GetPiece(this.Ordinal + 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece.Value;
            }

            return 15000;
        }

        /// <summary>
        /// Gets the cheapest piece defending this square.
        /// </summary>
        /// <param name="player">
        /// Defending player who pieces should be listed.
        /// </param>
        /// <returns>
        /// List of pieces.
        /// </returns>
        public Piece CheapestPieceDefendingThisSquare(Player player)
        {
            /*************************************************REFACTOR*******************************************/
            Piece piece;
            Piece pieceBest = null;

            // Pawn
            piece = Board.GetPiece(this.Ordinal - player.PawnAttackLeftOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - player.PawnAttackRightOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            // Knight
            piece = Board.GetPiece(this.Ordinal + 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal + 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 33);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 18);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal + 14);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal + 31);
            if (piece != null && piece.Name == Piece.PieceNames.Knight && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            // Bishop & Queen
            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 15);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Bishop:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, 17);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Bishop:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -15);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Bishop:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, -17);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Bishop:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            // Rook & Queen
            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 1);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Rook:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -1);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Rook:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, 16);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Rook:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            piece = Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, -16);
            if (piece != null)
            {
                switch (piece.Name)
                {
                    case Piece.PieceNames.Rook:
                        return piece;
                    case Piece.PieceNames.Queen:
                        pieceBest = piece;
                        break;
                }
            }

            if (pieceBest != null)
            {
                return pieceBest; // This means a queen was found, but not a Bishop or Rook
            }

            // King!
            piece = Board.GetPiece(this.Ordinal + 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal + 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal + 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 16);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 17);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal - 1);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            piece = Board.GetPiece(this.Ordinal + 15);
            if (piece != null && piece.Name == Piece.PieceNames.King && piece.Player.Colour == player.Colour)
            {
                return piece;
            }

            return null;
        }

        #endregion

        #region Private Methods
        /// <summary>
        ///     Check for Pawn attacker.
        /// </summary>
        /// <param name="player">Enemy Player</param>
        /// <returns>true if attacker, false otherwise</returns>
        private bool checkForPawnAttacker(Player player)
        {
            Piece piece = Board.GetPiece(this.Ordinal - player.PawnAttackLeftOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn &&
                piece.Player.Colour == player.Colour)
            {
                return true;
            }

            piece = Board.GetPiece(this.Ordinal - player.PawnAttackRightOffset);
            if (piece != null && piece.Name == Piece.PieceNames.Pawn &&
                piece.Player.Colour == player.Colour)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Check for an attacker in the spots that a Knight
        ///     could attack from.
        /// </summary>
        /// <param name="player">Enemy Player</param>
        /// <returns>true if attacker, false otherwise</returns>
        private bool checkForKnightAttacker(Player player)
        {
            int[] move_offsets = new int[] { -14, 14, -18, 18, -31, 31, -33, 33 };
            foreach (int offset in move_offsets)
            {
                //Check each offset spot for a Knight attacker.
                Piece piece = Board.GetPiece(this.Ordinal + offset);
                if (piece != null && piece.Name == Piece.PieceNames.Knight &&
                    piece.Player.Colour == player.Colour)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///     Check for attackers that go along horizontal/vertical lines,
        ///     like Rooks and Queens.
        /// </summary>
        /// <param name="player">Enemy player</param>
        /// <returns>true if there is an attacker, false otherwise</returns>
        private bool checkForRookLineAttacker(Player player)
        {
            int[] move_offsets = new int[] { -1, 1, -16, 16 };
            foreach (int offset in move_offsets)
            {
                //Check the line aligned with this offset for an attacker.
                if (Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Rook, this, offset) != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Check for attackers that go along diagonal lines,
        ///     like Bishops and Queens.
        /// </summary>
        /// <param name="player">Enemy Player</param>
        /// <returns>true if attacker, false otherwise</returns>
        private bool checkForBishopLineAttacker(Player player)
        {
            int[] move_offsets = new int[] { -15, 15, -17, 17 };
            foreach (int offset in move_offsets)
            {
                //Check the line aligned with this offset for an attacker.
                if (Board.LinesFirstPiece(player.Colour, Piece.PieceNames.Bishop, this, offset) != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Check to see if a Concealed piece can attack this square.
        /// </summary>
        /// <param name="player">Enemy Player</param>
        /// <returns>true if attacker, false otherwise</returns>
        private bool checkForConcealedAttacker(Player player)
        {
            //List of move offsets for a Concealed piece.
            int[] move_offsets = new int[] { -1, 1, -15, 15, -16, 16, -17, 17 };
            foreach (int offset in move_offsets)
            {
                //Check the first square of a Concealed piece's move.
                Piece piece = Board.GetPiece(this.Ordinal + offset);
                if (piece != null && piece.Name == Piece.PieceNames.Concealed &&
                    piece.Player.Colour == player.Colour)
                {
                    return true;
                }

                //If the first square isn't blocked, check the second square.
                if (piece == null)
                {
                    piece = Board.GetPiece(this.Ordinal + 2 * offset);
                    if (piece != null && piece.Name == Piece.PieceNames.Concealed &&
                        piece.Player.Colour == player.Colour)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///     Check for King attacker.
        /// </summary>
        /// <param name="player">Enemy Player</param>
        /// <returns>true if attacker, false otherwise</returns>
        private bool checkForKingAttacker(Player player)
        {
            int[] move_offset = new int[] { -1, 1, 15, -15, 16, -16, 17, -17 };
            foreach (int offset in move_offset)
            {
                Piece piece = Board.GetPiece(this.Ordinal + offset);
                if (piece != null && piece.Name == Piece.PieceNames.King &&
                    piece.Player.Colour == player.Colour)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}