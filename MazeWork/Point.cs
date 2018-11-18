namespace MazeWork
{
    struct Point
    {
        //좌표값 저장
        public int x;
        public int y;

        //생성자
        public Point(Point point)
        {
            x = point.x;
            y = point.y;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //붙어있는지 여부 반환
        public bool IsNearby(Point point)
        {
            if(point.x == x)
                if (point.y == y + 1 || point.y == y - 1)
                    return true;

            else if (point.y == y)
                if (point.x == x + 1 || point.x == x - 1)
                    return true;

            return false;
        }

        //값이 초기화되었는지 확인
        public bool IsNull()
        {
            if (x == 0 && y == 0)
                return true;
            else
                return false;
        }

        //좌표 출력
        public void Display()
        {
            System.Console.Write($"({x},{y})");
        }

        //같은 포인트 비교
        public bool Equals(Point point)
        {
            if (point.x == x || point.y == y)
                return true;
            else
                return false;
        }
        public static bool operator ==(Point a, Point b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    };
}
