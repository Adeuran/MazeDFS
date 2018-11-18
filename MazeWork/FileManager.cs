using System;
using System.IO;

namespace MazeWork
{
    class FileManager
    {
        /* FIELD & PROPERTY */

        //입출력 파일 이름
        public const string ReadFile = ".\\maze.txt";
        public const string WriteFile = ".\\mazeOut.txt";

        //행
        public int Col
        {
            get;
            private set;
        }

        //열
        public int Row
        {
            get;
            private set;
        }

        //맵
        private Map map;

        /* CONSTRUCTOR */
        public FileManager(Map map)
        {
            this.map = map;
        }

        /* METHOD */

        //맵을 불러옵니다.
        public void LoadMap()
        {
            string[] tempmap;

            try
            {
                tempmap = File.ReadAllLines(ReadFile);

                Row = tempmap[0].Length;
                Col = tempmap.Length;
                map.CreateMap(Row, Col);
                map.StringToMap(tempmap);
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("미로 파일을 찾을 수 없습니다.");
                Environment.Exit(0);
            }
        }

        //맵을 저장합니다
        public void SaveMap()
        {
            string[] tempmap;
            tempmap = map.MapToString();

            using (StreamWriter outputFile = new StreamWriter(WriteFile))
            {
                foreach (string line in tempmap)
                {
                    outputFile.WriteLine(line);
                }
            }
        }
    }
}
