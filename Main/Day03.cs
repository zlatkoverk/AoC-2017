using System;
using System.Collections.Generic;

namespace Main
{
    class Day03
    {
        public static int GetFirstResult(String input)
        {
            int number = int.Parse(input);

            int width = (int)Math.Sqrt(number);
            width = width % 2 == 0 ? width - 1 : width;

            number = (number - (int)Math.Pow(width, 2)) % (((int)(Math.Pow(width + 2, 2) - Math.Pow(width, 2))) / 4);
            width += 2;
            if (number <= width / 2)
            {
                return width / 2 + width / 2 - number;
            }
            else
            {
                return width / 2 + number - width / 2;
            }
        }

        public static int GetSecondResult(String input)
        {
            int number = int.Parse(input);

            return new Spiral().GetGreaterElement(number);
        }

        private class Spiral
        {
            public IDictionary<Coordinate, int> spiral = new Dictionary<Coordinate, int>();
            private int _offset;

            public int GetGreaterElement(int value)
            {
                spiral.Add(new Coordinate(0, 0), 1);
                _offset = 1;
                while (true)
                {
                    for (int j = 1 - _offset; j <= _offset; j++)
                    {
                        if (AddCoordinate(new Coordinate(_offset, j)) > value)
                        {
                            return spiral[new Coordinate(_offset, j)];
                        }
                    }
                    for (int i = _offset - 1; i >= -_offset; i--)
                    {
                        if (AddCoordinate(new Coordinate(i, _offset)) > value)
                        {
                            return spiral[new Coordinate(i, _offset)];
                        }
                    }
                    for (int j = _offset - 1; j >= -_offset; j--)
                    {
                        if (AddCoordinate(new Coordinate(-_offset, j)) > value)
                        {
                            return spiral[new Coordinate(-_offset, j)];
                        }
                    }
                    for (int i = 1 - _offset; i <= _offset; i++)
                    {
                        if (AddCoordinate(new Coordinate(i, -_offset)) > value)
                        {
                            return spiral[new Coordinate(i, -_offset)];
                        }
                    }
                    _offset++;
                }
            }

            public int AddCoordinate(Coordinate coordinate)
            {
                int value = 0;
                if (spiral.ContainsKey(new Coordinate(coordinate.X - 1, coordinate.Y)))
                {
                    value += spiral[new Coordinate(coordinate.X - 1, coordinate.Y)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X - 1, coordinate.Y + 1)))
                {
                    value += spiral[new Coordinate(coordinate.X - 1, coordinate.Y + 1)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X, coordinate.Y + 1)))
                {
                    value += spiral[new Coordinate(coordinate.X, coordinate.Y + 1)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X + 1, coordinate.Y + 1)))
                {
                    value += spiral[new Coordinate(coordinate.X + 1, coordinate.Y + 1)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X + 1, coordinate.Y)))
                {
                    value += spiral[new Coordinate(coordinate.X + 1, coordinate.Y)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X + 1, coordinate.Y - 1)))
                {
                    value += spiral[new Coordinate(coordinate.X + 1, coordinate.Y - 1)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X, coordinate.Y - 1)))
                {
                    value += spiral[new Coordinate(coordinate.X, coordinate.Y - 1)];
                }
                if (spiral.ContainsKey(new Coordinate(coordinate.X - 1, coordinate.Y - 1)))
                {
                    value += spiral[new Coordinate(coordinate.X - 1, coordinate.Y - 1)];
                }

                spiral.Add(coordinate, value);
                return value;
            }
        }

        private class Coordinate
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Coordinate))
                {
                    return false;
                }

                Coordinate other = (Coordinate)obj;
                return other.X == X && other.Y == Y;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() + Y.GetHashCode();
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
    }
}
