using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnakeWithTimer
{
    class Wall : GameObject
    {
        public Wall(char sign, ConsoleColor color, string path) : base(sign, color)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    int rowNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        for (int columnNumber = 0; columnNumber < line.Length; ++columnNumber)
                        {
                            if (line[columnNumber] == '#')
                            {
                                body.Add(new Point { X = columnNumber, Y = rowNumber });
                            }
                        }

                        rowNumber++;
                    }
                }

            }
            Draw();
        }
    }
}
