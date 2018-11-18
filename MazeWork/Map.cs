using System;

namespace MazeWork
{
    class Map
    {
        /* FIELD & PROPERTY */

        //맵 크기
        public int Width
        {
            get;
            private set;
        }
        public int Height
        {
            get;
            private set;
        }
        //맵 저장
        public char[][] CharMap
        {
            get;
            set;
        }
        //입구
        public Point StartPoint
        {
            get;
            private set;
        }
        //출구
        public Point EndPoint
        {
            get;
            private set;
        }

        /* METHOD */

        //이동할 수 있는 위치인지 확인
        public bool IsValidLocation(Point point)
        {
            if (point.x < 0 || point.y < 0 || point.x > Width - 1 || point.y > Height - 1)
                return false;
            else if (CharMap[point.y][point.x] == '0'|| CharMap[point.y][point.x] == '3'|| CharMap[point.y][point.x] == '4') //해당 좌표에 벽이 없으면
                return true;
            else
                return false;
        }
        
        //분기점인지 확인
        public bool IsBranchPoint(ref Point point)
        {
            int count = 0;

            //상
            Point temp = point;
            temp.y--;
            if (IsValidLocation(temp)) count++;
            //하
            temp = point;
            temp.y++;
            if (IsValidLocation(temp)) count++;
            //좌
            temp = point;
            temp.x--;
            if (IsValidLocation(temp)) count++;
            //우
            temp = point;
            temp.x++;
            if (IsValidLocation(temp)) count++;
                
            //결과 리턴
            if (count > 1)
                return true;
            else
                return false;
        }

        //맵 타일을 생성
        public void CreateMap(int width, int height)
        {
            Width = width;
            Height = height;
            CharMap = new char[height][];
        }

        //string 타입을 맵으로 저장
        public void StringToMap(string[] map)
        {
            int num = 0;
            foreach (string charArray in map)
                CharMap[num++] = charArray.ToCharArray();
        }

        //맵을 string 타입으로 리턴
        public string[] MapToString()
        {
            string[] map = new string[Height];

            for(int height = 0; height < Height; height++)
            {
                map[height] = new string(CharMap[height]);
            }

            return map;
        }

        //입출구 탐색
        //입구 찾기 (우선순위 좌>상>하)
        //출구 찾기 (우선순위 우>하>상)
        public void FindInOut()
        {
            //이미 입구와 출구가 있으면
            if (!(StartPoint.IsNull() && EndPoint.IsNull()))
                return; //작업 취소

            for (int y = 0; y < Height; y++)
            {
                //좌 입구
                if (CharMap[y][0] == '0')
                {
                    Point start = new Point(0, y);
                    StartPoint = start;
                }
                //우 출구
                if(CharMap[y][Width-1] == '0')
                {
                    Point end = new Point(Width - 1, y);
                    EndPoint = end;
                }
            }

            for(int x = 0; x < Width; x++)
            {
                //상
                if (CharMap[0][x] == '0')
                    //입구
                    if(StartPoint.IsNull())
                    {
                        Point start = new Point(x, 0);
                        StartPoint = start;
                    }
                    //출구
                    else if (EndPoint.IsNull())
                    {
                        Point end = new Point(x, 0);
                        EndPoint = end;
                    }

                //하
                if (CharMap[Height-1][x] == '0')
                    //출구
                    if (EndPoint.IsNull())
                    {
                        Point end = new Point(x, Height - 1);
                        EndPoint = end;
                    }
                //입구
                else if (StartPoint.IsNull())
                    {
                        Point start = new Point(x, Height - 1);
                        StartPoint = start;
                    }
                }
            }
        
        public void EditMap(Point point, char value)
        {
            CharMap[point.y][point.x] = value;
        }

        //맵에 적절한 아이콘을 반환합니다.
        public char DisplayIcon(int num)
        {
            switch (num) {
                case '0':
                    return '○';
                case '1':
                    return '■';
                case '2':
                    return '◎';
                case '3':
                    return '◐';
                case '4':
                    return '◑';
                default:
                    return '?';
            }

        }

        //맵 Display
        public void Display()
        {
            for (int height = 0; height < Height; height++)
            {
                for (int width = 0; width < Width; width++)
                {
                    Console.Write(DisplayIcon(CharMap[height][width]));
                }
                Console.WriteLine();
            }
        }
        public void Display(Point point)
        {
            for (int height = 0; height < Height; height++)
            {
                for (int width = 0; width < Width; width++)
                {
                    if (point.x == width && point.y == height)
                        Console.Write("●");
                    else
                        Console.Write(DisplayIcon(CharMap[height][width]));
                }
                Console.WriteLine();
            }
        }
    }
}