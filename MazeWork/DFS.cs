using System;
using System.Collections.Generic;

namespace MazeWork
{
    class DFS : Map, IMazeSolution
    {
        private readonly Stack<Point> locationStack;
        private readonly Stack<Point> shortestStack;
        public LinkedList<Point> BranchPoint
        {
            get;
            private set;
        }
        public readonly LinkedList<Point> moveHistory;

        public DFS():base()
        {
            locationStack = new Stack<Point>();
            shortestStack = new Stack<Point>();
            BranchPoint = new LinkedList<Point>();
            moveHistory = new LinkedList<Point>();
        }

        public void FindExit()
        {
            //입구 스택에 삽입
            locationStack.Push(StartPoint);
            //종료지점이 있다면 삽입
            if (!EndPoint.IsNull())
                EditMap(EndPoint, '4');

            Point prev = new Point(0,0); //이전 이동
            while (locationStack.Count != 0)
            {
                Point here = locationStack.Pop();   //현재위치 삽입
                EditMap(here, '2');	//이동경로 남기기
                moveHistory.AddLast(new Point(here)); //이동 기록 남기기

                //출구라면
                if(!EndPoint.IsNull() && EndPoint == here)
                {
                    var lastest = BranchPoint.Last;
                    Stack<Point> reverse = new Stack<Point>();
                    while (shortestStack.Count != 0)
                        reverse.Push(shortestStack.Pop());
                    while(reverse.Count != 0)
                        BranchPoint.AddLast(reverse.Pop());
                    BranchPoint.AddLast(new Point(here));

                    //전체 이동경로 넣을 위치
                    return;
                }
                //출구가 아님
                else
                {
                    //분기점을 만났다면
                    if (IsBranchPoint(ref here))
                    {
                        if (!prev.IsNull() && !here.IsNearby(prev))
                            shortestStack.Clear();
                        else
                        {
                            Stack<Point> reverse = new Stack<Point>();
                            while (shortestStack.Count != 0)
                                reverse.Push(shortestStack.Pop());
                            while (reverse.Count != 0)
                                BranchPoint.AddLast(reverse.Pop());
                        }
                        BranchPoint.AddLast(new Point(here));

                        //현재 분기점까지 최단거리 출력
                        Console.WriteLine("[입구부터 현재 분기점까지] ");
                        Console.Write("ENTRANCE");
                        LinkedListNode<Point> nowPrint = BranchPoint.First;
                        for (int now = 0; now < BranchPoint.Count; now++)
                        {
                            Console.Write(" -> ");
                            nowPrint.Value.Display();
                            nowPrint = nowPrint.Next;
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        shortestStack.Push(new Point(here));    //최단거리 검색용 스택에 삽입

                        //막다른 길을 만났다면
                        if (!prev.IsNull() && !here.IsNearby(prev))
                        {
                            shortestStack.Clear();  //최단거리 스택 비우기
                            shortestStack.Push(new Point(here));   //최단거리 스택에 현재 삽입
                        }
                    }
                    
                    //이동 가능한 위치 검색

                    //좌
                    Point temp = here;
                    temp.x -= 1;
                    if (IsValidLocation(temp))
                        locationStack.Push(new Point(temp));
                    //하
                    temp = here;
                    temp.y += 1;
                    if (IsValidLocation(temp))
                        locationStack.Push(new Point(temp));
                    //상
                    temp = here;
                    temp.y -= 1;
                    if (IsValidLocation(temp))
                        locationStack.Push(new Point(temp));
                    //우
                    temp = here;
                    temp.x += 1;
                    if (IsValidLocation(temp))
                        locationStack.Push(new Point(temp));
                }
                prev = here;    //이전 경로를 현재로 변경
            }
            //현재 분기점까지 이동 기록 출력
            Console.WriteLine();
            Console.WriteLine("[전체 이동경로] ");
            Console.Write("START");
            LinkedListNode<Point> nowNode = moveHistory.First;
            for (int nowCount = 0; nowCount < moveHistory.Count; nowCount++)
            {
                Console.Write(" -> ");
                nowNode.Value.Display();
                nowNode = nowNode.Next;

            }
            Console.Write(" -> ");

            Console.WriteLine("FINISH");
            return;
        }
    }
}
