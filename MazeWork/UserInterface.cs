using System;
using System.Collections.Generic;

namespace MazeWork
{
    class UserInterface
    {
        /* FIELD & PROPERTY */
        private DFS map;

        /* CONSTRUCTOR */
        public UserInterface(DFS map)
        {
            this.map = map;
        }
        
        /* METHOD */
        public void DisplayMainMenu()
        {
            while (true)
            {
                //메뉴 출력
                Console.WriteLine("---------- 메인메뉴 ----------");
                Console.WriteLine("1. 전체 이동경로 좌표 보기");
                Console.WriteLine("2. 전체 이동경로 그림 보기");
                Console.WriteLine("3. 전체 이동경로 애니메이션 보기");
                Console.WriteLine("4. 최단경로 좌표 보기");
                Console.WriteLine("5. 최단경로 애니메이션 보기");
                Console.WriteLine();
                Console.WriteLine("출력 방법을 선택하세요 >> ");

                Int32.TryParse(Console.ReadLine(), out int select);//입력 받음


                Console.WriteLine();
                switch (select)
                {
                    //전체 이동경로 좌표
                    case 1:
                        //현재 분기점까지 이동 기록 출력
                        Console.WriteLine();
                        Console.WriteLine("[전체 이동경로] ");
                        Console.Write("START");
                        {
                            LinkedListNode<Point> nowPrint = map.moveHistory.First;
                            for (int now = 0; now < map.moveHistory.Count; now++)
                            {
                                Console.Write(" -> ");
                                nowPrint.Value.Display();
                                nowPrint = nowPrint.Next;

                            }
                            Console.Write(" -> ");

                            Console.WriteLine("FINISH");
                        }
                        break;
                    case 2:
                        //전체 이동경로 그림
                        map.Display();
                        break;
                    case 3:
                        //전체 이동경로 애니메이션
                        {
                            LinkedListNode<Point> nowNode = map.moveHistory.First;
                            for (int count = 0; count < map.moveHistory.Count; count++)
                            {
                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                map.Display(nowNode.Value);
                                nowNode = nowNode.Next;
                            }
                        }
                        break;
                    case 4:
                        //최단경로 좌표
                        {
                            Console.WriteLine("[최단 이동경로] ");
                            Console.Write("ENTRANCE");
                            LinkedListNode<Point> nowPrint = map.BranchPoint.First;
                            for (int now = 0; now < map.BranchPoint.Count; now++)
                            {
                                Console.Write(" -> ");
                                nowPrint.Value.Display();
                                nowPrint = nowPrint.Next;
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        //최단경로 애니메이션
                        {
                            LinkedListNode<Point> nowNode = map.BranchPoint.First;
                            for (int count = 0; count < map.BranchPoint.Count; count++)
                            {
                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                map.Display(nowNode.Value);
                                nowNode = nowNode.Next;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
                Console.WriteLine();
            }
        }

    }
}
